using System.Web.Mvc;
using Notamedia.Oilring.Database.DataAccess;
using admin.db;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class UserActivityModule : OilringModule<ViewUserMaterialController, ViewUserMaterialObject, UserActivityModule>
    {
        public UserActivityModule()
        {
        }

        public UserActivityModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }

    }
}