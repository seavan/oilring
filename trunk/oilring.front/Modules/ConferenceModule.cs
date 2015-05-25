using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class ConferenceModule : OilringModule<ConferenceController, ConferenceObject, ConferenceModule>
    {
        public ConferenceModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public ConferenceModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Ajax = true;
            Relation = "ConferenceObject_ManyToOne";
        }
    }
}
