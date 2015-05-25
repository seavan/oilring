using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class TechnoModule : OilringModule<TechnoController, TechnoObject, TechnoModule>
    {
        public TechnoModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public TechnoModule(IDatabaseEntity _related)
            : base(_related)
        {
        }
    }
}
