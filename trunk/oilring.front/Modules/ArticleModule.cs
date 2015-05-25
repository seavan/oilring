using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class ArticleModule : OilringModule<ArticleController, ArticleObject, ArticleModule>
    {
        public ArticleModule()
        {
            UserFilter = 1;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }

        public ArticleModule(IDatabaseEntity _related)
            : base(_related)
        {
            UserFilter = 1;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}