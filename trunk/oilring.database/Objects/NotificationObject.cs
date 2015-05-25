
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	Notification
File name: 	Notification.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace admin.db
{
    public partial class NotificationObject : IRelatedUserEnhancable
    {
        #region IRelatedUserEnhancable Members


        public UserObject RelatedUser
        {
            get;
            set;
        }

        #endregion

        public bool IsAcceptable
        {
            get
            {
                return IsAcceptActionAvailable && !(IsAccepted.HasValue && IsAccepted.Value);
            }
        }

        public bool IsDenyable
        {
            get { return IsAcceptActionAvailable && !(IsDenied.HasValue && IsDenied.Value); }
        }

        public bool IsRevokable
        {
            get
            {
                return IsAcceptable && !(IsAccepted.HasValue && IsAccepted.Value);
            }
        }

        public bool IsDeletable
        {
            get { return true; }
        }

        public bool IsAcceptActionAvailable
        {
            get
            {
                return AcceptableTypes.Contains((NotificationTypes)NotificationType);
            }
        }

        public static NotificationTypes[] AcceptableTypes = new NotificationTypes[] { NotificationTypes.ntFriendRequest, NotificationTypes.ntJoinRequest };
    }
}
