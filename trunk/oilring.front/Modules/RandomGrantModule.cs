using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomGrantModule: OilringModule<GrantController, GrantObject, RandomGrantModule>
    {
        public RandomGrantModule()
        {
        }

        public RandomGrantModule(GrantObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}