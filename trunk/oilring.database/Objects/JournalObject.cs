using Notamedia.Oilring.Database.DataAccess;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial class JournalObject : IPublishedItem, IDefaultPhotoable, IRubricFilterable, ITagFilterable, IUserEnhancable, IAutoUpdateable, ICommentable, IFavorable
    {
        public override void UpdateAuto()
        {
            base.UpdateAuto();
        }
    }
}