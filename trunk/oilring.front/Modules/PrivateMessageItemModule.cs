using Notamedia.Oilring.Database.DataAccess;
using admin.db;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class PrivateMessageItemModule : OilringModule<PrivateMessageItemController, PrivateMessageItemObject, PrivateMessageItemModule>
    {
        public PrivateMessageItemModule()
        {
        }

        public PrivateMessageItemModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "PrivateMessageItemObject_ManyToOne";
        }
    }
}