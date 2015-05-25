using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomDiscussionModule : OilringModule<DiscussionController, DiscussionObject, RandomDiscussionModule>
    {
        public RandomDiscussionModule()
        {
        }

        public RandomDiscussionModule(DiscussionObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}