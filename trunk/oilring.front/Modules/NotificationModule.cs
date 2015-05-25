using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class NotificationModule : OilringModule<NotificationController, NotificationObject, NotificationModule>
    {
        public NotificationModule()
        {
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public NotificationModule(IDatabaseEntity _related)
            : base(_related)
        {
            this.SetOrder(OrderList.PublicationDateDesc);
            Relation = "NotificationObject_ManyToOne";
        }
    }
}