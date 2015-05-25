using System.Web;
using Notamedia.Oilring.Database.DataAccess;
using admin.db;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class User_GroupModule : OilringModule<User_GroupController, User_GroupObject, User_GroupModule>
    {
        public User_GroupModule()
        {
            Ajax = true;
            Relation = "User_GroupObject_ManyToOne";
//            ParentID = 0;
        }

        public User_GroupModule(IDatabaseEntity _related)
            : base(_related)
        {
            Ajax = true;
            Relation = "User_GroupObject_ManyToOne";
//            ParentID = 0;
        }

 
    }
}