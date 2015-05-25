
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Discussion
    File name: 	Discussion.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using Database.Implementation;
namespace admin.db
{
    public partial class DiscussionService : DataService<Discussion, DiscussionObject, DiscussionObject.Converter>, IDiscussionService
    {
        public DiscussionService()
        {
            RegisterManyToManyRelation<_ObjectAuthorLink>("DiscussionAuthorObject", null, true);
        }
    }
}
