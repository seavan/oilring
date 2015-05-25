
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	PrivateMessage
File name: 	PrivateMessage.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Database.Entities;

namespace admin.db
{
    public partial class PrivateMessageObject : DatabaseEntity, IDatabaseEntity, ISenderUserEnhancable, IOwnerUserEnhancable
    {
        #region ISenderUserEnhancable Members


        public UserObject SenderUser
        {
            get;
            set;
        }

        #endregion
    }
}
