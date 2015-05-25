	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Notification
	File name: 	INotificationService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial interface INotificationService : IDataService<NotificationObject>
    {
        void AddToFriendsRequest(UserObject _thisUser, UserObject _otherUser);
        void AddAuthor(UserObject _targetUser, IDatabaseEntity _entity);
        void AddAuthorReader(UserObject _targetUser, IDatabaseEntity _entity);
        void JoinRequest(UserObject _targetUser, IDatabaseEntity _entity);
        void RejectJoinRequest(UserObject _targetUser, IDatabaseEntity _entity);
        void AcceptJoinRequest(UserObject _targetUser, IDatabaseEntity _entity);
        void AddToFriendsAccept(UserObject _targetUser, UserObject _fromUser);

        void RegistrationEmail(UserObject _targetUser);
        void RecoverPasswordRequest(UserObject _targetUser);
        void RecoveryPasswordConfirm(UserObject _targetUser, string newPassword);

        void ConfirmNotification(long _id, long _currentUserId);
        void RejectNotification(long _id, long _currentUserId);
        void RevokeNotification(long _id, long _currentUserId);
        void DeleteNotification(long _id, long _currentUserId);

        void SendPrivateMessageNotification(PrivateMessageItemObject _pmo);
    }
}	
