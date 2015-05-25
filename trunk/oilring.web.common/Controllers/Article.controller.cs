
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Article
    File name: 	Article.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class ArticleController : OilringBaseUniversalController<ArticleObject>
    {
    protected IArticleService m_ArticleService;

    protected IArticleService ArticleService
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
    protected override IDataService<ArticleObject> GetService()
    {
        return DataServiceLocator.ArticleService;
    }
    }
    }
  