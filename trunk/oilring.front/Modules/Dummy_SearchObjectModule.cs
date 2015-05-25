using Notamedia.Oilring.Database.DataAccess;
using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database;
using System.Web.Mvc;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class Dummy_SearchObjectModule : OilringModule<Dummy_SearchObjectController, Dummy_SearchObjectObject, Dummy_SearchObjectModule>
    {
        public Dummy_SearchObjectModule()
        {
            //Relation = "Tags";
        }
        public Dummy_SearchObjectModule(IDatabaseEntity _related)
            : base(_related)
        {
            //Relation = "Tags";
        }

        public Dummy_SearchObjectModule SphinxSearch(HtmlHelper _helper, string _view = null)
        {
            return List(_helper, "Search", _view);
        }
    }
}