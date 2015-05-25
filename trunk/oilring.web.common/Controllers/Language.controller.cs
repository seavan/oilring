
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Language
    File name: 	Language.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class LanguageController : OilringBaseUniversalController<LanguageObject>
    {
    protected ILanguageService m_LanguageService;

    protected ILanguageService LanguageService
    {
    get
    {
    if (m_LanguageService == null)
    {
    m_LanguageService = GetService() as ILanguageService;
    }

    return m_LanguageService;
    }
    }
    protected override IDataService<LanguageObject> GetService()
    {
        return DataServiceLocator.LanguageService;
    }
    }
    }
  