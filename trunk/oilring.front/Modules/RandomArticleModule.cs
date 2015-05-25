using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomArticleModule : OilringModule<ArticleController, ArticleObject, RandomArticleModule>
    {
        public RandomArticleModule()
        {
        }

        public RandomArticleModule(ArticleObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}