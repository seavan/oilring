using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class OuterLinkModule : OilringModule<OuterLinkController, OuterLinkObject, OuterLinkModule>
    {
        public OuterLinkModule()
        {
            //Relation = "Tags";
        }
        public OuterLinkModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}