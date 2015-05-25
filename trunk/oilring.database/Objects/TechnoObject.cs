using Notamedia.Oilring.Database.DataAccess;
using System;
using Database.Entities;

namespace admin.db
{
    public partial class TechnoObject : IPublishedItem, ICommentable, IRubricFilterable, ITagFilterable, IDefaultPhotoable, IUserEnhancable, IAutoUpdateable, IFullTextSearchable, ITitleable, IFavorable
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