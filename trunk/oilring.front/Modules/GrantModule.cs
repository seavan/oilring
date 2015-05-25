using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{    
    public class GrantModule : OilringModule<GrantController, GrantObject, GrantModule>
    {
        public GrantModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
        public GrantModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}
