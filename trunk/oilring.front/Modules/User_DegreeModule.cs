using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class User_DegreeModule : OilringModule<User_DegreeController, User_DegreeObject, User_DegreeModule>
    {
        public User_DegreeModule()
        {
            Relation = "User_DegreeObject_ManyToOne";
        }

        public User_DegreeModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "User_DegreeObject_ManyToOne";
        }
    }
}