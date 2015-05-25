using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class SeminarModule : OilringModule<SeminarController, SeminarObject, SeminarModule>
    {
        public SeminarModule()
        {
            UserFilter = 1;
            this.SetOrder(OrderList.Coming);
        }

        public SeminarModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Ajax = true;
            Relation = "SeminarObject_ManyToOne";
        }
    }
}