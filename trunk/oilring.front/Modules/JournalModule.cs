using admin.db;
using System.Web;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class JournalModule : OilringModule<JournalController, JournalObject, JournalModule>
    {
        public JournalModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}
