
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Notification
    File name: 	Notification.service.cs
*/


using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Net.Mail;
using System.Web;
using Database.Entities;
using Common;
namespace admin.db
{
    public enum NotificationTypes
    {
        ntFriendRequest = 0,
        ntAddAuthor = 1,
        ntFriendsAccept = 2,
        ntAddAuthorReader = 3,
        ntJoinRequest = 4,
        ntJoinReject = 5,
        ntJoinAccept = 6,
        ntRecoverPasswordRequest = 7,
        ntRecoveryPasswordConfirm = 8,
        ntJoinGrantRequest = 9,
        ntJoinGrantReject = 10,
        ntJoinGrantAccept = 11,
        ntDefault = 20
    }

    public class NotificationAction
    {
        public Action<NotificationObject> Delete { get; set; }
        public Action<NotificationObject> Confirm { get; set; }
        public Action<NotificationObject> Reject { get; set; }
        public Action<NotificationObject> Revoke { get; set; }
    }

    public partial class NotificationService : INotificationService
    {
        public NotificationService()
        {
            m_NotificationActions[NotificationTypes.ntFriendRequest] =
                new NotificationAction()
                    {
                        Confirm = (no) =>
                                      {
                                          if (no.REL_User_ID.HasValue)
                                          {
                                              DataServiceLocator.UserService.AddFriendAccept(no.REL_Id, no.REL_User_ID.Value);
                                              no.IsAccepted = true;
                                              no.IsDenied = false;
                                              Update(no);
                                          }
                                      },
                        Delete = (no) =>
                                      {
                                          if (no.REL_User_ID.HasValue)
                                          {
                                              DataServiceLocator.UserService.AddFriendClean(no.REL_Id, no.REL_User_ID.Value);
                                              Delete(no);
                                          }
                                      },
                        Reject = (no) =>
                                      {
                                          if (no.REL_User_ID.HasValue)
                                          {
                                              DataServiceLocator.UserService.AddFriendReject(no.REL_Id, no.REL_User_ID.Value);
                                              no.IsAccepted = false;
                                              no.IsDenied = true;
                                              Update(no);
                                          }
                                      },
                        Revoke = (no) =>
                                      {
                                          if (no.REL_User_ID.HasValue)
                                          {
                                              DataServiceLocator.UserService.AddFriendRevoke(no.REL_Id, no.REL_User_ID.Value);
                                              no.IsAccepted = null;
                                              no.IsDenied = null;
                                              Update(no);
                                          }
                                      }
                    };

            m_NotificationActions[NotificationTypes.ntJoinRequest] =
                new NotificationAction()
                {
                    Confirm = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinEventAccept(no.REL_User_ID.Value, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = true;
                            no.IsDenied = false;
                            Update(no);
                        }
                    },
                    Delete = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinEventClean(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            Delete(no);
                        }
                    },
                    Reject = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinEventReject(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = false;
                            no.IsDenied = true;
                            Update(no);
                        }
                    },
                    Revoke = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinEventRevoke(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = null;
                            no.IsDenied = null;
                            Update(no);
                        }
                    }
                };

            m_NotificationActions[NotificationTypes.ntJoinGrantRequest] =
                new NotificationAction()
                {
                    Confirm = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinGrantAccept(no.REL_User_ID.Value, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = true;
                            no.IsDenied = false;
                            Update(no);
                        }
                    },
                    Delete = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
//                            DataStore.UserService.Join(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            Delete(no);
                        }
                    },
                    Reject = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
                            DataServiceLocator.UserService.JoinGrantReject(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = false;
                            no.IsDenied = true;
                            Update(no);
                        }
                    },
                    Revoke = (no) =>
                    {
                        if (no.REL_User_ID.HasValue && no.REL_Entity_ID.HasValue)
                        {
//                            DataStore.UserService.JoinEventRevoke(no.REL_Id, new DummyEntity(no.REL_Entity_ID.Value, no.REL_Entity_ObjectType));
                            no.IsAccepted = null;
                            no.IsDenied = null;
                            Update(no);
                        }
                    }
                };

            m_NotificationActions[NotificationTypes.ntDefault] =
                            new NotificationAction()
                            {
                                Confirm = (no) =>
                                {
                                },
                                Delete = (no) =>
                                {
                                    Delete(no);
                                },
                                Reject = (no) =>
                                {
                                },
                                Revoke = (no) =>
                                {
                                }
                            };
            m_Host = GetAppSettings()["hostname"];
        }

        private SortedList<NotificationTypes, NotificationAction> m_NotificationActions = new SortedList<NotificationTypes, NotificationAction>();

        private Expression<Func<NotificationObject, bool>> GetEqualityComparer(NotificationObject _object)
        {
            return (obj1) =>
                       obj1.NotificationType.Equals(_object.NotificationType)
                               && obj1.REL_Id.Equals(_object.REL_Id)
                               && obj1.REL_ObjectType.Equals(_object.ObjectType);

        }


        #region INotificationService Members
        private NotificationObject CreateTemplate(UserObject _attached, IDatabaseEntity _relatedEntity, UserObject _relatedUser, NotificationTypes _type, string _text) 
        {
            var obj = new NotificationObject()
            {
                NotificationType = (int)_type,
                REL_Id = _attached.Id,
                REL_ObjectType = _attached.ObjectType,
                Text = _text
            };

            if (_relatedEntity != null)
            {
                obj.REL_Entity_ID = _relatedEntity.Id;
                obj.REL_Entity_ObjectType = _relatedEntity.ObjectType;
            }

            if (_relatedUser != null)
            {
                obj.REL_User_ID = _relatedUser.Id;
                obj.REL_User_ObjectType = _relatedUser.ObjectType;
            }

            return obj;
        }

        public void AddAuthorReader(UserObject _targetUser, IDatabaseEntity _entity)
        {
            Insert(CreateTemplate(_targetUser, _entity, null, NotificationTypes.ntAddAuthorReader, SendAuthorReaderEmail(_targetUser, _entity)));
        }

        public void JoinRequest(UserObject _targetUser, IDatabaseEntity _entity)
        {
            // send to all authors/owners
            var users = DataServiceLocator.UserService.GetAllAuthors(_entity);
            foreach (var user in users)
            {
                Insert(CreateTemplate(user, _entity, _targetUser, NotificationTypes.ntJoinRequest, SendJoinRequestEmail(user, _targetUser, _entity)));
            }
        }

        public void JoinGrantRequest(UserObject _targetUser, IDatabaseEntity _entity)
        {
            // send to all authors/owners
            var users = DataServiceLocator.UserService.GetAllAuthors(_entity);
            foreach (var user in users)
            {
                Insert(CreateTemplate(user, _entity, _targetUser, NotificationTypes.ntJoinGrantRequest, SendJoinGrantRequestEmail(user, _targetUser, _entity)));
            }
        }

        public void RejectJoinRequest(UserObject _targetUser, IDatabaseEntity _entity)
        {
            Insert(CreateTemplate(_targetUser, _entity, null, NotificationTypes.ntJoinReject, SendRejectRequestEmail(_targetUser, _entity)));
        }

        public void AcceptJoinRequest(UserObject _targetUser, IDatabaseEntity _entity)
        {
            Insert(CreateTemplate(_targetUser, _entity, null, NotificationTypes.ntJoinAccept, SendAcceptRequestEmail(_targetUser, _entity)));
        }

        public void AcceptJoinGrantRequest(UserObject _targetUser, IDatabaseEntity _entity)
        {
            Insert(CreateTemplate(_targetUser, _entity, null, NotificationTypes.ntJoinGrantAccept, SendAcceptJoinGrantRequestEmail(_targetUser, _entity)));
        }


        public void AddToFriendsAccept(UserObject _targetUser, UserObject _user)
        {
            Insert(CreateTemplate(_user, null, _targetUser, NotificationTypes.ntFriendsAccept,
            SendFriendAcceptEmail(_targetUser, _user)));
        }

        public void AddToFriendsRequest(UserObject _thisUser, UserObject _otherUser)
        {
            Insert(CreateTemplate(_otherUser, null, _thisUser, NotificationTypes.ntFriendRequest,
                           SendFriendRequestEmail(_thisUser, _otherUser)));
        }

        public void AddAuthor(UserObject _targetUser, IDatabaseEntity _entity)
        {
            var notify = SendAddAuthorEmail(_targetUser, _entity);
            if( notify != null )
            Insert(CreateTemplate(_targetUser, _entity, null, NotificationTypes.ntAddAuthor, notify));
        }

        public void RegistrationEmail(UserObject _targetUser)
        {
            Insert(CreateTemplate(_targetUser, null, null, NotificationTypes.ntRecoverPasswordRequest, SendRegistrationEmail(_targetUser)));
        }

        public void RecoverPasswordRequest(UserObject _targetUser)
        {
            Insert(CreateTemplate(_targetUser, null, null, NotificationTypes.ntRecoverPasswordRequest, SendRecoverPassRequest(_targetUser)));
        }

        public void RecoveryPasswordConfirm(UserObject _targetUser, string newPassword)
        {
            Insert(CreateTemplate(_targetUser, null, null, NotificationTypes.ntRecoveryPasswordConfirm, SendRecoverPassComplete(_targetUser, newPassword)));
        }


        public void NotificationAction(NotificationObject _notification, bool _accept)
        {
            throw new NotImplementedException();
        }

        #endregion

        private string m_Host = null;

        public string GetHost()
        {
            if( m_Host != null )
            {
                return m_Host;
            }
            if (HttpContext.Current != null)
            {
                var hname = HttpContext.Current.Request.Url.Host;
                var p = HttpContext.Current.Request.Url.Port;
                if ((p != 80) || (p != 8080))
                {
                    hname += ":" + p;
                }
                return "http://" + hname;
            }
            else
            {
                return "http://oilring.notamedia.ru";
            }
        }

        public SortedList<string, string> FormatEmailParams(UserObject _targetUser, UserObject _relatedUser, IDatabaseEntity _relatedDb, ITitleable _relatedTitleable, IDatabaseEntity _target, string _targetAction)
        {
            var res = new SortedList<string, string>();
            res["project_name"] = "Oilring.ru";
            res["project_title"] = "Oilring.ru :: Социальная сеть";
            res["host"] = GetHost();
            res["cabinet_options_uri"] = "/ru/User/Single/" + _targetUser.Id;

            if (_targetUser != null)
            {
                res["receiver_name"] = _targetUser.DisplayName;
            }

            if (_relatedUser != null)
            {
                res["rel_user_name"] = _relatedUser.DisplayName;
                res["rel_user_url"] = "/ru/User/Single/" + _relatedUser.Id;
            }

            if (_relatedDb != null)
            {
                res["rel_url"] = "/ru/" + Mapper.INST.GetUri(_relatedDb.GetType()) + "/Single/" + _relatedDb.Id;

            }

            if (_relatedTitleable != null)
            {
                res["rel_title"] = "«" + _relatedTitleable.Title + "»";
            }

            if (_target != null)
            {
                res["target_uri"] = "/ru/" + Mapper.INST.GetUri(_target.GetType()) + "/" + _targetAction + "/" + _target.Id;

            }


            return res;
        }

        public string SendRejectRequestEmail(UserObject _targetUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "visitorrejectrequest",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, null, _related, _related as ITitleable, _related, "Single")
                );
        }

        public string SendAcceptRequestEmail(UserObject _targetUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "visitoracceptrequest",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, null, _related, _related as ITitleable, _related, "Single")
                );
        }

        public string SendJoinRequestEmail(UserObject _targetUser, UserObject _relatedUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "visitorrequest",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, _relatedUser, _related, _related as ITitleable, _related, "Single"),
                _targetUser.Options_SubscribeJoin
                );
        }


        public string SendJoinGrantRequestEmail(UserObject _targetUser, UserObject _relatedUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "grantmembershiprequest",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, _relatedUser, _related, _related as ITitleable, _related, "Single"),
                _targetUser.Options_SubscribeJoin
                );
        }

        public string SendAcceptJoinGrantRequestEmail(UserObject _targetUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "grantmembershipaccept",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, null, _related, _related as ITitleable, _related, "Single")
                );
        }

        public string SendAuthorReaderEmail(UserObject _targetUser, IDatabaseEntity _related)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "addreader",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, null, _related, _related as ITitleable, _related, "Single")
                );
        }

        public string SendFriendAcceptEmail(UserObject _fromUser, UserObject _targetUser)
        {
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "friendrequestaccept",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, _fromUser, null, null, _targetUser, "Single")

                );
        }

        public string SendFriendRequestEmail(UserObject _fromUser, UserObject _targetUser)
        {

            return DataServiceLocator.MessageTemplateService.SendEmail(
                "friendrequest",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, _fromUser, null, null, _targetUser, "Single"), _targetUser.Options_SubscribeFriendRequest

                );
        }

        public string SendAddAuthorEmail(UserObject _targetUser, IDatabaseEntity _relatedEntity)
        {
            var titleable = _relatedEntity as ITitleable;
            if (String.IsNullOrEmpty(titleable.Title)) return null;
            return DataServiceLocator.MessageTemplateService.SendEmail(
                "addauthor",
                _targetUser.UserLogin,
                FormatEmailParams(_targetUser, null, _relatedEntity, titleable, _relatedEntity, "Single")

                );
        }

        public string SendRegistrationEmail(UserObject _targetUser)
        {
            var p = FormatEmailParams(_targetUser, null, null, null, null, null);
            p["rel_url"] = "/ru/User/Activate?guid=" + _targetUser.Activation_guid.ToString();

            return DataServiceLocator.MessageTemplateService.SendEmail(
                "register",
                _targetUser.UserLogin,
                p);
        }

        public string SendRecoverPassRequest(UserObject _targetUser)
        {
            var p = FormatEmailParams(_targetUser, null, null, null, null, null);
            p["rel_url"] = "/ru/User/RecoveryPasswordConfirm?Id=" + _targetUser.Id + "&CheckLink=" + _targetUser.Recoverpass_guid.ToString();

            return DataServiceLocator.MessageTemplateService.SendEmail(
                "recoverpassrequest",
                _targetUser.UserLogin,
                p);
        }

        public string SendRecoverPassComplete(UserObject _targetUser, string newPass)
        {
            var p = FormatEmailParams(_targetUser, null, null, null, null, null);
            p["new_password"] = newPass;
            p["user_login"] = _targetUser.UserLogin;

            return DataServiceLocator.MessageTemplateService.SendEmail(
                "recoverpasscomplete",
                _targetUser.UserLogin,
                p);
        }

        private void ActionIfRegistered(long _id, long _currentUserId, Func<NotificationAction, Action<NotificationObject>> _expr)
        {
            var obj = GetById(_id);
            if( obj.REL_Id != _currentUserId )
            {
                return;
            }

            var na = m_NotificationActions.IndexOfKey((NotificationTypes)obj.NotificationType) != -1
                ? m_NotificationActions[(NotificationTypes) obj.NotificationType] :
                (m_NotificationActions.IndexOfKey(NotificationTypes.ntDefault) != -1 ? m_NotificationActions[NotificationTypes.ntDefault] : null);

            if( na != null )
            {
                var action = na;
                var eaction = _expr(action);
                if ( (obj != null) && (eaction != null))
                {
                    eaction(obj);
                }
            }
        }


        public void ConfirmNotification(long _id, long _currentUserId)
        {
            ActionIfRegistered(_id, _currentUserId, (a) => a.Confirm);
        }

        public void RejectNotification(long _id, long _currentUserId)
        {
            ActionIfRegistered(_id, _currentUserId, (a) => a.Reject);
        }

        public void RevokeNotification(long _id, long _currentUserId)
        {
            ActionIfRegistered(_id, _currentUserId, (a) => a.Revoke);
        }

        public void DeleteNotification(long _id, long _currentUserId)
        {
            ActionIfRegistered(_id, _currentUserId, (a) => a.Delete);
        }

        public override void DeleteAllRelation(string _relation, NotificationObject _item)
        {
            // empty cause we have none;
        }

        public void SendPrivateMessageNotification(PrivateMessageItemObject _pmo)
        {
            var u = DataServiceLocator.UserService.GetById(_pmo.REL_ReceiverUserId);

            if (!u.Options_SubscribePrivateMessages) return;

            var s = DataServiceLocator.UserService.GetById(_pmo.REL_SenderUserId);

            var p = FormatEmailParams(u, s, null, null, null, null);
            p["text"] = _pmo.Text;


            DataServiceLocator.MessageTemplateService.SendEmail(
                "privatemessage",
                u.UserLogin,
                p);
        }
    }
}
