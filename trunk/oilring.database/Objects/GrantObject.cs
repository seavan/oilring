using Notamedia.Oilring.Database.DataAccess;
using System;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial class GrantObject : IPublishedItem, IDefaultPhotoable, ICommentable, IRubricFilterable, ITagFilterable, IUserEnhancable, IAutoUpdateable
, IFullTextSearchable, ITitleable, IJoinableEventEnhancable, IFavorable
    {
        public override void UpdateAuto()
        {
            base.UpdateAuto();

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