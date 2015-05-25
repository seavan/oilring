using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class ContactModule : OilringModule<ContactController, ContactObject, ContactModule>
    {
        public ContactModule()
        {
            Relation = "ContactObject_ManyToOne";
        }

        public ContactModule(IDatabaseEntity _related)
            : base(_related)
        {
            Relation = "ContactObject_ManyToOne";
        }
    }
}