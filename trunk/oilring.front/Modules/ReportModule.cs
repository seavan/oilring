using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class ReportModule : OilringModule<ReportController, ReportObject, ReportModule>
    {
        public ReportModule()
        {
            
        }

        public ReportModule(IDatabaseEntity _related)
            : base(_related)
        {
            
        }
    }
}