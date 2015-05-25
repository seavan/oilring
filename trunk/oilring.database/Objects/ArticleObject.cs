/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	Article
File name: 	Article.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Database.Entities;
using Database.Interfaces;

namespace admin.db
{

    public partial class ArticleObject : IAutoUpdateable, IPublishedItem, IDefaultPhotoable, ICommentable, IUserEnhancable, IRubricFilterable, ITagFilterable,
        IFullTextSearchable, ITitleable, IFavorable
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