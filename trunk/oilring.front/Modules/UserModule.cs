using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class UserModule : OilringModule<UserController, UserObject, UserModule>
    {
        public UserModule()
        {
            //Relation = "Tags";
            PageSize = 3;
            this.SetOrder(OrderList.LastName);
        }
        public UserModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}