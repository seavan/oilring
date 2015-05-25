	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User
	File name: 	IUserService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using System.Security.Principal;
using Notamedia.Oilring.Database.DataAccess;
using System.Linq;
using System.Web;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial interface IUserService : IDataService<UserObject>
    {
        IEnumerable<UserObject> GetAllUsers(string searchString);
        bool SignIn(string _login, string _password, bool _persist, out string _message, out HttpCookie _cookie);
        void SignOut();
        UserObject GetIsLoginUser();
        IQueryable<IUserEnhancable> ApplyEnhancement(IQueryable<IUserEnhancable> _src, string _otype, long _userId, bool _isAdmin);
        IQueryable<IOwnerUserEnhancable> ApplyOwnerUserEnhancement(IQueryable<IOwnerUserEnhancable> _src);
        IQueryable<ISenderUserEnhancable> ApplySenderUserEnhancement(IQueryable<ISenderUserEnhancable> _src);

        IQueryable<IRelatedUserEnhancable> ApplyRelatedUserEnhancement(IQueryable<IRelatedUserEnhancable> _src);
        IQueryable<IFriendEnhancable> ApplyFriendRelationEnhancement(IQueryable<IFriendEnhancable> _src, long _currentUserId);
        IQueryable<IJoinableEventEnhancable> ApplyJoinableEventEnhancement(IQueryable<IJoinableEventEnhancable> _src, long _currentUserId);
        void SetFavourites(long _userId, IDatabaseEntity _obj, bool _set = true);
        IPrincipal GetPrincipal();
        void RegisterUser(RegistrationModel _model);
        void AddFriendRequest(UserObject _requestor, UserObject _acceptor);
        bool ActivateUser(string guid);

        void AddFriendAccept(long _userId1, long _userId2);
        void AddFriendReject(long _userId1, long _userId2);
        void AddFriendRevoke(long _userId1, long _userId2);
        void AddFriendClean(long _userId1, long _userId2);

        void JoinEventRequest(UserObject _user1, IDatabaseEntity _event);
        void JoinEventAccept(long _userId, IDatabaseEntity _event);
        void JoinEventReject(long _userId, IDatabaseEntity _event);
        void JoinEventClean(long _userId, IDatabaseEntity _event);
        void JoinEventRevoke(long _userId, IDatabaseEntity _event);

        void JoinGrantRequest(UserObject _user1, IDatabaseEntity _event);
        void JoinGrantAccept(long _userId, IDatabaseEntity _event);
        void JoinGrantReject(long _userId, IDatabaseEntity _event);

        IEnumerable<UserObject> GetAllAuthors(IDatabaseEntity _entity);
        bool RecoveryPassword(string userEmail);
        void RecoveryPasswordConfirm(long Id, string CheckLink, out string result);
    }
}	
