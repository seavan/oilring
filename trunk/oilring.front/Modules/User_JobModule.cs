using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class User_JobModule : OilringModule<User_JobController, User_JobObject, User_JobModule>
    {
        public User_JobModule()
        {
            Relation = "User_JobObject_ManyToOne";
        }

        public User_JobModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "User_JobObject_ManyToOne";
        }
    }
}