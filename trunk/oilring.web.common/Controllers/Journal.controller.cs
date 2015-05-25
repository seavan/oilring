
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Journal
    File name: 	Journal.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class JournalController : OilringBaseUniversalController<JournalObject>
    {
    protected IJournalService m_JournalService;

    protected IJournalService JournalService
    {
    get
    {
    if (m_JournalService == null)
    {
    m_JournalService = GetService() as IJournalService;
    }

    return m_JournalService;
    }
    }
    protected override IDataService<JournalObject> GetService()
    {
        return DataServiceLocator.JournalService;
    }
    }
    }
  