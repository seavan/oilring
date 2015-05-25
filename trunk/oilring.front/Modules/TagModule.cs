using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class TagModule : OilringModule<TagController, TagObject, TagModule>
    {
        public TagModule()
        {
            //Relation = "Tags";
        }
        public TagModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}