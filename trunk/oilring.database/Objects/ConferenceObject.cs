using Notamedia.Oilring.Database.DataAccess;
using System.Globalization;
using System;
using Database.Entities;
using Database.Interfaces;

namespace admin.db
{
    public partial class ConferenceObject : IPublishedItem, IDefaultPhotoable, IRubricFilterable, ITagFilterable, IAutoUpdateable, ICommentable, IUserEnhancable, IFullTextSearchable, ITitleable, IManyToOne, IDateRangeItem, IFavorable, IJoinableEventEnhancable
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