using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class OrganizationModule : OilringModule<OrganizationController, OrganizationObject, OrganizationModule>
    {
        public OrganizationModule()
        {
            //Relation = "Tags";
            PageSize = 3;
            this.SetOrder(OrderList.Title);
        }
        public OrganizationModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}