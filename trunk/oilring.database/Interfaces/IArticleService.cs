	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Article
	File name: 	IArticleService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IArticleService : IDataService<ArticleObject>
    {
        IEnumerable<ArticleObject> GetAllArticles(string searchString);
    }
}	
