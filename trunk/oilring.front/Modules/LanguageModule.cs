using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class LanguageModule : OilringModule<LanguageController, LanguageObject, LanguageModule>
    {
        public LanguageModule()
        {
            
        }
        public LanguageModule(IDatabaseEntity _related)
            : base(_related)
        {
            
        }
    }
}