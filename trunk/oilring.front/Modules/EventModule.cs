using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class EventModule: OilringModule<EventController, EventObject, EventModule>
    {
        public EventModule()
        {
            PageSize = 10;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}