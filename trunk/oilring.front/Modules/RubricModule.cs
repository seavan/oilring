using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class RubricModule : OilringModule<RubricController, RubricObject, RubricModule>
    {
        public RubricModule()
        {
            Behave = "rubricBlock";
            //Relation = "Tags";
        }
        public RubricModule(IDatabaseEntity _related)
            : base(_related)
        {
            Behave = "rubricBlock";
            //Relation = "Tags";
        }
    }
}