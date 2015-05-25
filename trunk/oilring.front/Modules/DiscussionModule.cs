using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class DiscussionModule : OilringModule<DiscussionController, DiscussionObject, DiscussionModule>
    {
        public DiscussionModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public DiscussionModule(IDatabaseEntity _related)
            : base(_related)
        {
        }
    }
}
