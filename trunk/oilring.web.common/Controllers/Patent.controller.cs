
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Patent
    File name: 	Patent.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class PatentController : OilringBaseUniversalController<PatentObject>
    {
    protected IPatentService m_PatentService;

    protected IPatentService PatentService
    {
    get
    {
    if (m_PatentService == null)
    {
    m_PatentService = GetService() as IPatentService;
    }

    return m_PatentService;
    }
    }
    protected override IDataService<PatentObject> GetService()
    {
        return DataServiceLocator.PatentService;
    }
    }
    }
  