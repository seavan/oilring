using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class PatentModule : OilringModule<PatentController, PatentObject, PatentModule>
    {
        public PatentModule()
        {
            Relation = "PatentObject_ManyToOne";
        }

        public PatentModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "PatentObject_ManyToOne";
        }
    }
}