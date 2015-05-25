
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	PrivateMessageItem
File name: 	PrivateMessageItem.object.cs
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
    public partial class PrivateMessageItemObject : ISenderUserEnhancable
    {
        #region ISenderUserEnhancable Members


        public UserObject SenderUser
        {
            get; set;
        }

        #endregion
    }
}
