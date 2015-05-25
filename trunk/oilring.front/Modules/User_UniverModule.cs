using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class User_UniverModule : OilringModule<User_UniverController, User_UniverObject, User_UniverModule>
    {
        public User_UniverModule()
        {
            Relation = "User_UniverObject_ManyToOne";
        }

        public User_UniverModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "User_UniverObject_ManyToOne";
        }
    }
}