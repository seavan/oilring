
/*
    User controller code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Generated on: Fri Jun 17 03:15:56 UTC+0400 2011
    Table alias:	Article
    File name: 	Article.controller.cs
*/

using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace Notamedia.Oilring
{
    public class ArticleController : admin.web.common.ArticleController
    {
        public ArticleController()
        {
            Behaviour.OnlyPublished = true;
        }

        protected IArticleService m_ArticleService;

        private IArticleService ArticleService
        {
            get
            {
                if (m_ArticleService == null)
                {
                    m_ArticleService = GetService() as IArticleService;
                }

                return m_ArticleService;
            }
        }

        public string AutoCompleteSearch(string searchString)
        {
            var tags = ArticleService.GetAllArticles(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Title, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }

        public ActionResult GetHtmlItemList(long searchId)
        {
            return null;
        }

        public ActionResult SearchHtmlItemList(string searchName)
        {
            return null;
        }
    }
}
