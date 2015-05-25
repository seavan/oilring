
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	User
    File name: 	User.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Xml.Serialization;
using System.Configuration;
using System.IO;
using System.Security.Principal;
using Microsoft.Practices.Unity;
using Database.Entities;
using Database;
using Common;
using Common.Security;

namespace admin.db
{
    public partial class UserService : IUserService
    {

        #region constructor
        public UserService()
        {
            RegisterManyToManyRelation<_ObjectAuthorLink>("ObjectAuthor",
                        CreateExpector<UserObject>(
                        () => DataServiceLocator.NotificationService.AddAuthor)
                );

            //  докладчик конференции/семинара
            RegisterManyToManyRelation<_ObjectAuthorReaderLink>("ObjectAuthorReader");

            // человек подал запрос на участие в конференции/семинаре в качестве слушател€
            RegisterManyToManyRelation<_ObjectJoinRequestLink>("ObjectJoinRequest",
                                        CreateExpector<UserObject>(
                        () => DataServiceLocator.NotificationService.JoinRequest)
                );

            // человеку отказали в участии в конференции/семинаре
            RegisterManyToManyRelation<_ObjectJoinRejectLink>("ObjectJoinReject",
                                        CreateExpector<UserObject>(
                        () => DataServiceLocator.NotificationService.RejectJoinRequest)
                );

            // читатель журнала
            RegisterManyToManyRelation<_ObjectUserReaderLink>("ObjectUserReader"
                );

            // todo - используем стандартный ObjectUserVisitor
            // человек участвует в гранте
            //RegisterManyToManyRelation<_GrantMemberLink>("GrantMember");

            // человек участвует в гранте
            //RegisterManyToManyRelation<_GrantMemberRequestLink>("GrantMemberRequest");

            // человек участвует в семинаре/конференции в качестве слушател€
            RegisterManyToManyRelation<_ObjectUserVisitorLink>("ObjectUserVisitor",
                                        CreateExpector<UserObject>(
                        () => DataServiceLocator.NotificationService.AcceptJoinRequest)                
                );


            // человек €вл€етс€ представителем журнала/организации
            RegisterManyToManyRelation<_ObjectUserDelegateLink>("ObjectUserDelegate");

            // контакты пользовател€. нахера они вообще здесь, непон€тно
            RegisterManyToManyRelation<_ContactUserLink>("ContactUser");

            // человек входит в друзь€ кого-то там
            RegisterManyToManyRelation<_FriendLink>("FriendLink",
                                        CreateExpector<UserObject, UserObject>(
                        () => DataServiceLocator.NotificationService.AddToFriendsAccept)                
                );

            RegisterRelation("GroupFriendLink", new RelationOperand
            {
                Select = (id, otype) =>
                    otype == "user" ?
                    GetRelatedDb<_FriendLink>(typeof(User), new DummyEntity(id, otype), (link) => link.REL_User_Group_Id == null)
                    :
                    GetRelatedDb<_FriendLink>(typeof(User), null, (link) => link.REL_User_Group_Id.Equals(id)),
//                SelectBy = () => typeof(_UserFavouriteLink),
                Delete = (id, otype, id2, otype2) =>
                             {
                                 TraceContext.Transaction(
                                     s =>
                                         {
                                             if (otype == "user")
                                             {
                                                 var friendLink = s.GetTable<_FriendLink>().Where(fl => fl.REL_Id2.Equals(id)
                                                                           && fl.REL_ObjectType2.Equals(otype)).
                                                    FirstOrDefault();
                                                 if( friendLink.REL_User_Group_Id.Equals(id2))
                                                 {
                                                     friendLink.REL_User_Group_Id = null;
                                                     var newgroup =
                                                    s.GetTable<User_Group>().Where(
                                                        ug => ug.Id.Equals(id2)).FirstOrDefault();
                                                     if (newgroup != null)
                                                     {
                                                         newgroup.AUTO_User_Count--;
                                                     }
                                                 }
                                                 
                                             }
                                         }
                                     );
                             },
                DeleteAll = (id, otype) => 
                {
                    /*TraceContext.Transaction(
                        s =>
                        {
                            
                        }); */
                },
                Insert = (id, otype, id2, otype2) =>
                             {
                                 if(otype == "user")
                                 {
                                    TraceContext.Transaction(
                                        s =>
                                            {
                                                var friendLink = s.GetTable<_FriendLink>().Where(fl => fl.REL_Id2.Equals(id)
                                                                           && fl.REL_ObjectType2.Equals(otype)).
                                                    FirstOrDefault();
                                                if( friendLink != null )
                                                {
                                                    if(friendLink.REL_User_Group_Id != null)
                                                    {
                                                        var fgroup =
                                                            s.GetTable<User_Group>().Where(
                                                                ug => ug.Id.Equals(friendLink.REL_User_Group_Id.Value)).FirstOrDefault();
                                                        if( fgroup != null)
                                                        {
                                                            fgroup.AUTO_User_Count--;
                                                        }
                                                    }
                                                    friendLink.REL_User_Group_Id = id2;
                                                }

                                                var newgroup =
                                                    s.GetTable<User_Group>().Where(
                                                        ug => ug.Id.Equals(id2)).FirstOrDefault();

                                                if (newgroup != null)
                                                {
                                                    newgroup.AUTO_User_Count++;
                                                }
                                            }
                                        );   
                                 }
                             }

            });

            RegisterRelation("UserFavourites", new RelationOperand
            {
                Select = (id, otype) =>
                    GetThisRelatedModel<_UserFavouriteLink>(new DummyEntity(id, otype)),
                SelectBy = () => typeof(_UserFavouriteLink),
                Delete = (id, otype, id2, otype2) => { DeleteRelation<_UserFavouriteLink>(new DummyEntity(id, otype), new DummyEntity(id2, otype2)); },
                DeleteAll = (id, otype) => { DeleteAllRelation<_UserFavouriteLink>(new DummyEntity(id, otype)); },
                Insert = (id, otype, id2, otype2) => { CreateRelation<_UserFavouriteLink>(new DummyEntity(id, otype), new DummyEntity(id2, otype2)); }

            });
        }
        #endregion //constructor

        public IEnumerable<UserObject> GetAllUsers(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return GetAll().OrderBy(u => u.LastName);

            List<UserObject> users = new List<UserObject>();
            var words = searchString.Split(' ');
            var allUsers = GetAll();
            int startRange = 0;
            foreach (var word in words)
            {
                startRange = users.Count();
                users.InsertRange(startRange, allUsers.Where(u => u.LastName.StartsWith(word) || u.FirstName.StartsWith(word)));
            }
            return users.Distinct().OrderBy(u => u.LastName);
        }

        #region Authorization
        private UserObject Authenticate(string _login, string _password, out string _message)
        {
            _message = null;
            UserObject user = GetAll().Where(u => u.UserLogin == _login).FirstOrDefault();

            if ((user == null) || (user.Password != CalculateHash(_password)))
            {
                _message = "Ќеверное им€ пользовател€ или пароль";
                return null;
            }

            return user;
        }

        public bool SignIn(string _login, string _password, bool _persist, out string _message, out HttpCookie _cookie)
        {
            UserObject user = Authenticate(_login, _password, out _message);
            _cookie = null;

            if (user == null) return false;

            if (!user.IsActivate)
            {
                _message = "¬аш аккаунт не активирован";
                return false;
            }

            List<string> roles = GetRoles(user);

            SetAuthenticationCookie(user, _persist, roles, out _cookie);

            user.IsOnline = true;
            user.LastVisitDate = DateTime.Now;
            Update(user);

            //            HttpContext.Current.Session.Remove("User_" + user.Id);
            //            HttpContext.Current.Session.Add("User_" + user.Id, user);

            return true;
        }

        public void SignOut()
        {
            //            HttpContext.Current.Session.RemoveAll();

            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            UserObject user = null;

            try
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var xs = new XmlSerializer(typeof(TicketUserData));
                StringReader sr = new StringReader(authTicket.UserData);
                TicketUserData data = (TicketUserData)xs.Deserialize(sr);

                user = GetAll().Where(u => u.Id == data.UserId).FirstOrDefault();
            }
            catch (System.Exception)
            {
            }
            finally
            {
                FormsAuthentication.SignOut();

                authCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                authCookie.Expires = DateTime.Now.AddDays(-1);
                authCookie.Domain = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
                HttpContext.Current.Response.Cookies.Add(authCookie);

                if (user != null)
                {
                    user.IsOnline = false;
                    user.LastVisitDate = DateTime.Now;
                    Update(user);
                }
            }
        }

        private void SetAuthenticationCookie(UserObject _user, bool _persist, List<string> _roles, out HttpCookie _cookie)
        {
            HttpCookiesSection cookieSection = (HttpCookiesSection)ConfigurationManager.GetSection("system.web/httpCookies");
            AuthenticationSection authenticationSection = (AuthenticationSection)ConfigurationManager.GetSection("system.web/authentication");

            var xs = new XmlSerializer(typeof(TicketUserData));
            StringWriter stringWriter = new StringWriter();

            TicketUserData data = new TicketUserData
            {
                Roles = _roles,
                UserId = _user.Id,
                Login = _user.UserLogin
            };

            xs.Serialize(stringWriter, data);

            FormsAuthenticationTicket authTicket =
                new FormsAuthenticationTicket(
                1, _user.UserLogin, DateTime.Now, DateTime.Now.AddMinutes(authenticationSection.Forms.Timeout.TotalMinutes),
                _persist, stringWriter.ToString());

            String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            authCookie.Domain = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            if (cookieSection.RequireSSL || authenticationSection.Forms.RequireSSL)
            {
                authCookie.Secure = true;
            }

            // если не установить врем€ дл€ куки, пользователю придетс€ перелогиниватьс€ после закрыти€ браузера
            if (authTicket.IsPersistent)
            {
                authCookie.Expires = authTicket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(authCookie);
            _cookie = authCookie;
        }
        #endregion //Authorization

        public UserObject GetIsLoginUser()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return null;

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            var xs = new XmlSerializer(typeof(TicketUserData));
            StringReader sr = new StringReader(authTicket.UserData);
            TicketUserData data = (TicketUserData)xs.Deserialize(sr);

            /*if (HttpContext.Current.Session["User_" + data.UserId] != null)
            {
                return (UserObject)HttpContext.Current.Session["User_" + data.UserId];
            }*/
            return GetAll().Where(u => u.Id == data.UserId).FirstOrDefault();
        }

        public IPrincipal GetPrincipal()
        {

            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return null;

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            var xs = new XmlSerializer(typeof(TicketUserData));
            StringReader sr = new StringReader(authTicket.UserData);
            TicketUserData data = (TicketUserData)xs.Deserialize(sr);

            UserObject user;
            if ( (HttpContext.Current != null) && (HttpContext.Current.Items["User_" + data.UserId] != null))
            {
                user = (UserObject)HttpContext.Current.Items["User_" + data.UserId];
            }
            else 
            {
                user = GetAll().Where(u => u.Id == data.UserId).FirstOrDefault();
            }

            FormsIdentity fi = (FormsIdentity)(HttpContext.Current.User.Identity);
            return new UserPrincipal(fi, user, data.Roles);
        }

        public void RegisterUser(RegistrationModel _model)
        {
            UserObject newUser = new UserObject
            {
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                Activation_guid = Guid.NewGuid(),
                UserLogin = _model.EMail,
                Password = CalculateHash(_model.Password),
                LastVisitDate = DateTime.Now,
                RegistrationDate = DateTime.Now

            };

            Insert(newUser);

            ContactObject userEmail = new ContactObject
            {
                ContactType = "mail",
                REL_Id = newUser.Id,
                REL_ObjectType = newUser.ObjectType,
                Value = _model.EMail,
                CreationDate = DateTime.Now
            };


            var ds = DataServiceLocator;
            ds.ContactService.Insert(userEmail);
            ds.NotificationService.RegistrationEmail(newUser);
        }

        public string CalculateHash(string _password)
        {
            return UserObject.CalculateHash(_password);
        }


        public List<string> GetRoles(UserObject _account)
        {
            List<string> roles = new List<string> { BasicRoles.USER };
            return roles;
        }

        public bool RecoveryPassword(string userEmail)
        {
            var user = GetAll().Where(u => u.UserLogin == userEmail).FirstOrDefault();
            if (user == null) return false;

            try
            {
                user.Recoverpass_guid = Guid.NewGuid();
                Update(user);

                var ds = DataServiceLocator;
                ds.NotificationService.RecoverPasswordRequest(user);

            }
            catch
            {
                return false;
            }

            return true;
        }

        public void RecoveryPasswordConfirm(long Id, string CheckLink, out string result)
        {
            if (GetAll().Where(u=>u.Recoverpass_guid.HasValue).Any(u => (u.Id == Id) && ((u.Recoverpass_guid.Value.ToString()) == CheckLink)))
            {
                var user = GetAll().Where(u => u.Id == Id).Single();

                try
                {
                    string newPassword = StringExtensions.RandomString();
                    user.Password = CalculateHash(newPassword);
                    user.Recoverpass_guid = null;
                    Update(user);

                    var ds = DataServiceLocator;
                    ds.NotificationService.RecoveryPasswordConfirm(user, newPassword);

                    result = "Ќа ваш электронный адрес был выслан ваш новый пароль.";
                }
                catch
                {
                    result = "ѕроизошла ошибка сервера.";
                }
            }
            else
            {
                result = "Ќеверна€ ссылка. —брос парол€ невозможен.";
            }
        }

        private class DummyEnhancable<_T> where _T : IIdentifiedTyped
        {
            public _T Target { get; set; }
            public long Id { 
                get { return Target.Id; }
                set { Target.Id = value; }
            }

            public string ObjectType {
                get { return Target.ObjectType; }
                set { Target.ObjectType = value; }

            }
        }

        private class DummyUserEnhancable : IUserEnhancable
        {
            #region IUserEnhancable Members

            public long Id { get; set; }

            public string ObjectType { get; set; }

            public IUserEnhancable Target { get; set; }

            public bool PSEUDO_IsUserFavourite
            {
                get { return Target.PSEUDO_IsUserFavourite; }
                set { Target.PSEUDO_IsUserFavourite = value; }
            }

            public int PSEUDO_NewCommentCount
            {
                get { return Target.PSEUDO_NewCommentCount;  }
                set { Target.PSEUDO_NewCommentCount = value; }
            }

            public int AUTO_CommentCount 
            {
                get { return Target.AUTO_CommentCount; }
                set { Target.AUTO_CommentCount = value; }
            }

            public bool PSEUDO_IsUserOwner 
            { 
                get { return Target.PSEUDO_IsUserOwner; }
                set { Target.PSEUDO_IsUserOwner = value; } 
            }

            public bool PSEUDO_IsUserAdmin
            {
                get { return Target.PSEUDO_IsUserAdmin; }
                set { Target.PSEUDO_IsUserAdmin = value; }
            }

            public bool PSEUDO_IsUserEditable
            {
                get { return Target.PSEUDO_IsUserEditable; }
                set { Target.PSEUDO_IsUserEditable = value; }
            }

            public long? Owner_User_ID
            {
                get { return Target.Owner_User_ID; }
                set { Target.Owner_User_ID = value; }
            }

            public DateTime? PSEUDO_PreviousVisitDateTime 
            {
                get { return Target.PSEUDO_PreviousVisitDateTime; }
                set { Target.PSEUDO_PreviousVisitDateTime = value; }
            }            
            #endregion
        }

        private class DummyOwnerUserEnhancable : IOwnerUserEnhancable
        {
            public IOwnerUserEnhancable Target { get; set; }

            public long? Owner_User_ID
            {
                get { return Target.Owner_User_ID; }
                set { Target.Owner_User_ID = value; }
            }

            public UserObject OwnerUser
            {
                get { return Target.OwnerUser; }
                set { Target.OwnerUser = value; }
            }

        }

        private class DummyFriendEnhancable : IFriendEnhancable
        {
            public IFriendEnhancable Target { get; set; }

            #region IFriendEnhancable Members

            public long Id
            {
                get { return Target.Id; }
                set { Target.Id = value; }
            }

            #endregion

            #region IFriendEnhancable Members


            public bool PSEUDO_IsInFriends
            {
                get { return Target.PSEUDO_IsInFriends; }
                set { Target.PSEUDO_IsInFriends = value; }
            }

            public bool PSEUDO_IsFriendRequestSent
            {
                get { return Target.PSEUDO_IsFriendRequestSent; }
                set { Target.PSEUDO_IsFriendRequestSent = value; }
            }

            public bool PSEUDO_Self
            {
                get { return Target.PSEUDO_Self; }
                set { Target.PSEUDO_Self = value; }
            }

            #endregion
        }

        private class DummyJoinableEventEnhancable : DummyEnhancable<IJoinableEventEnhancable>, IJoinableEventEnhancable
        {
            #region IJoinableEventEnhancable Members
            public bool PSEUDO_IsJoinRequestSent
            {
                get { return Target.PSEUDO_IsJoinRequestSent; }
                set { Target.PSEUDO_IsJoinRequestSent = value; }
            }

            public bool PSEUDO_IsJoinRequestAccepted
            {
                get { return Target.PSEUDO_IsJoinRequestAccepted; }
                set { Target.PSEUDO_IsJoinRequestAccepted = value; }
            }
            #endregion
        }

        private class DummyRelatedUserEnhancable : DummyEnhancable<IRelatedUserEnhancable>, IRelatedUserEnhancable
        {

            #region IRelatedUserEnhancable Members


            public UserObject RelatedUser
            {
                get { return Target.RelatedUser; }
                set { Target.RelatedUser = value; }
            }

            public long? REL_User_ID
            {
                get
                {
                    return Target.REL_User_ID;
                }
                set
                {
                    Target.REL_User_ID = value;
                }
            }

            public string REL_User_ObjectType
            {
                get
                {
                    return Target.REL_User_ObjectType;
                }
                set
                {
                    Target.REL_User_ObjectType = value;
                }
            }

            #endregion
        }

        private class DummySenderUserEnhancable : DummyEnhancable<ISenderUserEnhancable>, ISenderUserEnhancable
        {


            #region ISenderUserEnhancable Members

            public long REL_SenderUserId
            {
                get
                {
                    return Target.REL_SenderUserId;
                }
                set
                {
                    Target.REL_SenderUserId = value;
                }
            }

            public UserObject SenderUser
            {
                get
                {
                    return Target.SenderUser;
                }
                set
                {
                    Target.SenderUser = value;
                }
            }

            #endregion
        }

        public IQueryable<IUserEnhancable> ApplyEnhancement(IQueryable<IUserEnhancable> _src, string _otype, long _userId, bool _isAdmin)
        {
            var _ids = _src.Select(s => s.Id).ToArray();
            var r = DataContext.GetTable<_UserFavouriteLink>().Where(s => s.REL_Id2.Equals(_userId) && s.REL_ObjectType1.Equals(_otype) && _ids.Contains(s.REL_Id1)).ToArray();
            var r2 = DataContext.GetTable<_CommentableVisitLink>().Where(s => s.REL_Id2.Equals(_userId) && s.REL_ObjectType1.Equals(_otype) && _ids.Contains(s.REL_Id1)).ToArray();
            var r3 = DataContext.GetTable<_ObjectAuthorLink>().Where(s => s.REL_Id2.Equals(_userId) && s.REL_ObjectType1.Equals(_otype) && _ids.Contains(s.REL_Id1)).ToArray();
            var u = GetById(_userId);
            _isAdmin = _isAdmin || (u.IsAdmin.HasValue && u.IsAdmin.Value);
            var t = _src
                .GroupJoin(
                    r,
                    outer => outer.Id,
                    inner => inner.REL_Id1,
                    (id, ufl) => new DummyUserEnhancable() { Target = id, Id = id.Id, PSEUDO_IsUserFavourite = ufl.Count() > 0 })
                .GroupJoin(
                    r2,
                    outer => outer.Target.Id,
                    inner => inner.REL_Id1,
                    (mediator, cvl) => new DummyUserEnhancable()
                        {
                            Target = mediator.Target,
                            PSEUDO_NewCommentCount = mediator.Target.AUTO_CommentCount - cvl.Select(s => s.LastCommentCount).
                            FirstOrDefault(),
                            PSEUDO_PreviousVisitDateTime = cvl.Select(s => s.PreviousVisitDateTime).
                            FirstOrDefault(),
                        })
                .GroupJoin(
                    r3,
                    outer => outer.Target.Id,
                    inner => inner.REL_Id1,
                    (mediator, cvl) => new DummyUserEnhancable()
                                           {
                                               Target = mediator.Target,
                                               PSEUDO_IsUserAdmin = _isAdmin,
                                               PSEUDO_IsUserEditable = _isAdmin || (cvl.Count() > 0),
                                               PSEUDO_IsUserOwner = _isAdmin || mediator.Target.Owner_User_ID.Equals(_userId)
                                           }
                );
            return t.Select(s => s.Target).AsQueryable();
        }

        public IQueryable<IOwnerUserEnhancable> ApplyOwnerUserEnhancement(IQueryable<IOwnerUserEnhancable> _src)
        {
            var _ownerIds = _src.Where(s => s.Owner_User_ID != null).Select(s => s.Owner_User_ID).Distinct().ToArray();
            var r4 = GetAll().Where(s => _ownerIds.Contains(s.Id));

            var t = _src
                .GroupJoin(
                    r4,
                    outer => outer.Owner_User_ID,
                    inner => inner.Id,
                    (mediator, uobj) => new DummyOwnerUserEnhancable()
                    {
                        Target = mediator,
                        OwnerUser = uobj.Count() > 0 ? uobj.First() : null
                    }
                );
            return t.Select(s => s.Target).AsQueryable();
        }

        public IQueryable<IRelatedUserEnhancable> ApplyRelatedUserEnhancement(IQueryable<IRelatedUserEnhancable> _src)
        {
            var _ownerIds = _src.Where(s => (s.REL_User_ID != null) && s.REL_User_ObjectType.Equals("user")).Select(s => s.REL_User_ID.Value).Distinct().ToArray();
            var r4 = GetAll().Where(s => _ownerIds.Contains(s.Id));

            var t = _src
                .GroupJoin(
                    r4,
                    outer => outer.REL_User_ID,
                    inner => inner.Id,
                    (mediator, uobj) => new DummyRelatedUserEnhancable()
                    {
                        Target = mediator,
                        RelatedUser = uobj.Count() > 0 ? uobj.First() : null
                    }
                );
            return t.Select(s => s.Target).AsQueryable();
        }
        public IQueryable<IFriendEnhancable> ApplyFriendRelationEnhancement(IQueryable<IFriendEnhancable> _src, long _currentUserId)
        {
            var ids = _src.Select( s => s.Id ).ToArray();
            var r1 = DataContext.GetTable<_FriendLink>().Where(s => ids.Contains(s.REL_Id1) && s.REL_Id2.Equals(_currentUserId));
            var r2 = DataContext.GetTable<User_FriendRequest>().Where(s => ids.Contains(s.Target_User_ID) && s.REL_Id.Equals(_currentUserId));

            var t = _src.GroupJoin(
                    r1,
                    outer => outer.Id,
                    inner => inner.REL_Id1,
                    (mediator, uobj) => new DummyFriendEnhancable()
                    {
                        Target = mediator,
                        PSEUDO_IsInFriends = uobj.Count() > 0
                    }
                )
                .GroupJoin(
                    r2,
                    outer => outer.Id,
                    inner => inner.Target_User_ID,
                    (mediator, uobj) => new DummyFriendEnhancable()
                    {
                        Target = mediator.Target,
                        PSEUDO_IsFriendRequestSent = uobj.Count() > 0
                    }
                ).Select( s => s.Target);


            var res = t.ToArray();
            foreach (var i in res)
            {
                i.PSEUDO_Self = _currentUserId == i.Id;
            }


            return res.AsQueryable();
        }

        public IQueryable<IJoinableEventEnhancable> ApplyJoinableEventEnhancement(IQueryable<IJoinableEventEnhancable> _src, long _currentUserId)
        {
            var ids = _src.Select(s => s.Id).ToArray();
            var r1 = DataContext.GetTable<_ObjectJoinRequestLink>().Where(s => s.REL_ObjectType1.Equals("user") && s.REL_Id1.Equals(_currentUserId));
            var r2 = DataContext.GetTable<_ObjectUserVisitorLink>().Where(s => s.REL_ObjectType1.Equals("user") && s.REL_Id1.Equals(_currentUserId));

            var t = _src.GroupJoin(
                    r1,
                    outer => new { id = outer.Id, otype = outer.ObjectType },
                    inner => new { id = inner.REL_Id2, otype = inner.REL_ObjectType2 },
                    (mediator, uobj) => new DummyJoinableEventEnhancable()
                    {
                        Target = mediator,
                        PSEUDO_IsJoinRequestSent = uobj.Count() > 0
                    }
                )
                .GroupJoin(
                    r2,
                    outer => new { id = outer.Id, otype = outer.ObjectType },
                    inner => new { id = inner.REL_Id2, otype = inner.REL_ObjectType2 },
                    (mediator, uobj) => new DummyJoinableEventEnhancable()
                    {
                        Target = mediator.Target,
                        PSEUDO_IsJoinRequestAccepted = uobj.Count() > 0
                    }
                ).Select(s => s.Target);

            return t;
        }

        public void SetFavourites(long _userId, IDatabaseEntity _obj, bool _set = true)
        {
            if (_set)
            {
                CreateRelation("UserFavourites", GetById(_userId), _obj.Id, _obj.ObjectType);
            }
            else
            {
                DeleteRelation("UserFavourites", GetById(_userId), _obj.Id, _obj.ObjectType);
            }
        }

        public void AddFriendRequest(UserObject _requestor, UserObject _acceptor)
        {
            var ufr = DataServiceLocator.User_FriendRequestService.CreateItem();
            ufr.Target_User_ID = _acceptor.Id;
            ufr.REL_Id = _requestor.Id;
            ufr.REL_ObjectType = _requestor.ObjectType;
            DataServiceLocator.User_FriendRequestService.Insert(ufr);
        }

        public IEnumerable<UserObject> GetAllAuthors(IDatabaseEntity _entity)
        {
            var objs = GetAllDb().Join
                (
                DataContext.GetTable<_ObjectAuthorLink>().Where(s => s.REL_Id2.Equals(_entity.Id) && s.REL_ObjectType2.Equals(_entity.ObjectType)),
                s => new { id = s.Id, otype = s.ObjectType },
                s => new { id = s.REL_Id1, otype = s.REL_ObjectType1 },
                (outer, inner) => outer).Select(m_ConverterExpression).ToList();

            // add owner

            if (typeof(IOwnerUserEnhancable).IsAssignableFrom(_entity.GetType()))
            {
                var res = _entity as IOwnerUserEnhancable;
                if ( res.Owner_User_ID != null && (objs.Count( s => s.Id.Equals(res.Owner_User_ID.Value) ) == 0))
                {
                    objs.Add(GetById(res.Owner_User_ID.Value));
                }
            }

            return objs;
                
        }

        public void JoinEventRequest(UserObject _requestor, IDatabaseEntity _event)
        {
            CreateRelation("ObjectJoinRequest", _requestor, _event.Id, _event.ObjectType);
        }

        public void JoinEventAccept(long _userId, IDatabaseEntity _event)
        {
            JoinEventClean(_userId, _event);
            var user = GetById(_userId);
            CreateRelation("ObjectUserVisitor", user, _event.Id, _event.ObjectType);
        }

        public void JoinEventReject(long _userId, IDatabaseEntity _event)
        {
            JoinEventClean(_userId, _event);
            var user = GetById(_userId);
            CreateRelation("ObjectJoinReject", user, _event.Id, _event.ObjectType);
        }

        public void JoinEventClean(long _userId, IDatabaseEntity _event)
        {
            DeleteRelation("ObjectJoinRequest", GetById(_userId), _event.Id, _event.ObjectType);
        }

        public void JoinEventRevoke(long _userId, IDatabaseEntity _event)
        {
            JoinEventClean(_userId, _event);
            var user = GetById(_userId);
            DeleteRelation("ObjectJoinReject", user, _event.Id, _event.ObjectType);
            JoinEventRequest(user, _event);
        }

        public void AddFriendAccept(long _userId1, long _userId2)
        {
            AddFriendClean(_userId1, _userId2);
            CreateRelation("FriendLink", GetById(_userId1), _userId2, Mapper.INST.GetTypeCode<User>());
        }

        public void AddFriendReject(long _userId1, long _userId2)
        {
            AddFriendRevoke(_userId1, _userId2);
        }

        public void AddFriendRevoke(long _userId1, long _userId2)
        {
            AddFriendClean(_userId1, _userId2);
            DeleteRelation("FriendLink", GetById(_userId1), _userId2, Mapper.INST.GetTypeCode<User>());
        }

        public void AddFriendClean(long _userId1, long _userId2)
        {
            TraceContext.Transaction(s =>
            {
                s.GetTable<User_FriendRequest>().DeleteAllOnSubmit(
                    s.GetTable<User_FriendRequest>().Where(ufr => ufr.REL_Id.Equals(_userId1)
                    && ufr.Target_User_ID.Equals(_userId2)));
            });
        }

        public void JoinGrantRequest(UserObject _requestor, IDatabaseEntity _Grant)
        {
            CreateRelation("GrantMemberRequest", _requestor, _Grant.Id, _Grant.ObjectType);
        }

        public void JoinGrantAccept(long _userId, IDatabaseEntity _Grant)
        {
            JoinGrantClean(_userId, _Grant);
            var user = GetById(_userId);
            CreateRelation("ObjectUserVisitor", user, _Grant.Id, _Grant.ObjectType);
        }

        public void JoinGrantReject(long _userId, IDatabaseEntity _Grant)
        {
            JoinGrantClean(_userId, _Grant);
            var user = GetById(_userId);
            CreateRelation("ObjectJoinReject", user, _Grant.Id, _Grant.ObjectType);
        }

        public void JoinGrantClean(long _userId, IDatabaseEntity _Grant)
        {
            DeleteRelation("ObjectJoinRequest", GetById(_userId), _Grant.Id, _Grant.ObjectType);
        }

        public bool ActivateUser(string guid)
        {
            var u = GetAll().Where(s => s.Activation_guid.Equals(Guid.Parse(guid))).FirstOrDefault();
            if (u != null)
            {
                u.Activation_guid = null;
                u.Published = true;
                u.Approved = true;
                Update(u);
                return true;
            }
            return false;
        }

        public override void AfterUpdate(User _dbItem, UserObject _model)
        {
            if (!String.IsNullOrEmpty(_model.NewPassword))
            {
                _dbItem.Password = CalculateHash(_model.NewPassword);
            }

            base.AfterUpdate(_dbItem, _model);
        }

        #region IUserService Members


        public IQueryable<ISenderUserEnhancable> ApplySenderUserEnhancement(IQueryable<ISenderUserEnhancable> _src)
        {
            var _ownerIds = _src.Select(s => s.REL_SenderUserId).Distinct().ToArray();
            var r4 = GetAll().Where(s => _ownerIds.Contains(s.Id));

            var t = _src
                .GroupJoin(
                    r4,
                    outer => outer.REL_SenderUserId,
                    inner => inner.Id,
                    (mediator, uobj) => new DummySenderUserEnhancable()
                    {
                        Target = mediator,
                        SenderUser = uobj.Count() > 0 ? uobj.First() : null
                    }
                );
            return t.Select(s => s.Target).AsQueryable();
        }

        #endregion
    }
}
