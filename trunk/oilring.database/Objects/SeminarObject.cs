
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	Seminar
File name: 	Seminar.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Globalization;
using Database.Entities;

namespace admin.db
{
    public partial class SeminarObject : IPublishedItem, IDefaultPhotoable, IRubricFilterable, ITagFilterable, IUserEnhancable, ICommentable, IAutoUpdateable,
        IFullTextSearchable, ITitleable, IManyToOne, IJoinableEventEnhancable, IDateRangeItem, IFavorable
    {
        public override void UpdateAuto()
        {
            base.UpdateAuto();

        }

        public string StartHour
        {
            get { return /*EventStartDate.Hour;*/ EventStartDate.ToString("HH", CultureInfo.CreateSpecificCulture("ru-RU")); }
        }
        public string StartMinute
        {
            get { return /*EventStartDate.Minute;*/EventStartDate.ToString("mm", CultureInfo.CreateSpecificCulture("ru-RU")); }
        }
        public string EndHour
        {
            get { return /*EventEndDate.Hour; */EventEndDate.ToString("HH", CultureInfo.CreateSpecificCulture("ru-RU")); }
        }
        public string EndMinute
        {
            get { return /*EventEndDate.Minute;*/EventEndDate.ToString("mm", CultureInfo.CreateSpecificCulture("ru-RU")); }
        }

        #region IJoinableEventEnhancable Members

        public bool PSEUDO_IsJoinRequestSent
        {
            get;
            set;
        }

        public bool PSEUDO_IsJoinRequestAccepted
        {
            get;
            set;
        }

        #endregion


        public string GetSafeTitle()
        {
            return String.IsNullOrEmpty(Title) ? "без названия" : Title;
        }
    }
}
