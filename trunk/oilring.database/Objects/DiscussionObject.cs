
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	Discussion
File name: 	Discussion.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Database.Entities;
using Database.Interfaces;

namespace admin.db
{
    public partial class DiscussionObject : DatabaseEntity, IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IRubricFilterable, ITagFilterable, IAutoUpdateable, IUserEnhancable,
IFullTextSearchable, IFavorable, ITitleable
    {
        public override void UpdateAuto()
        {
            base.UpdateAuto();

        }


        public string GetSafeTitle()
        {
            return String.IsNullOrEmpty(Title) ? "без названия" : Title;
        }
    }
}



