using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class PublicationLinkModule : OilringModule<PublicationLinkController, PublicationLinkObject, PublicationLinkModule>
    {
        public PublicationLinkModule()
        {
            //Relation = "Tags";
        }
        public PublicationLinkModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }
    }
}