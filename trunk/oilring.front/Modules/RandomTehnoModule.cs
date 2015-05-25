using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomTehnoModule: OilringModule<TechnoController, TechnoObject, RandomTehnoModule>
    {
        public RandomTehnoModule()
        {
        }

        public RandomTehnoModule(TechnoObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}