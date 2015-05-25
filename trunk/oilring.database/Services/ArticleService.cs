	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Article
	File name: 	Article.service.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using System.Linq;

namespace admin.db
{
    public partial class ArticleService
    {
        public ArticleService()
        {
            RegisterManyToManyRelation<_ObjectAuthorLink>("ArticleAuthorObject", null, true);
            RegisterManyToManyRelation<_JournalArticleLink>("JournalArticle");
        }

        public IEnumerable<ArticleObject> GetAllArticles(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return GetAll().OrderBy(u => u.Title);

            List<ArticleObject> orgs = new List<ArticleObject>();
            //var words = searchString.Split(' ');

            var allOrg = GetAll();
            var listName = allOrg.Select(n => n.Title).ToList();
            int startRange = 0;
            List<string> temp;
            //foreach (var word in words)
            //{
                startRange = orgs.Count();
                temp = listName.Where(a => a.ClearText().StartsWith(searchString.ClearText())).ToList();
                orgs.InsertRange(startRange, allOrg.Where(u => temp.Contains(u.Title)));
            //}

            return orgs.Distinct().OrderBy(u => u.Title);
        }
    }
}	
