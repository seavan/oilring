using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class PrivateMessageModule : OilringModule<PrivateMessageController, PrivateMessageObject, PrivateMessageModule>
    {
        public PrivateMessageModule()
        {
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public PrivateMessageModule(IDatabaseEntity _related)
            : base(_related)
        {
            this.SetOrder(OrderList.PublicationDateDesc);
            Relation = "PrivateMessageObject_ManyToOne";
        }
    }
}