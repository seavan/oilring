using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomConferenceModule : OilringModule<ConferenceController, ConferenceObject, RandomConferenceModule>
    {
        public RandomConferenceModule()
        {
        }

        public RandomConferenceModule(ConferenceObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}