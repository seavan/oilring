
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Grant
    File name: 	Grant.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class GrantController : OilringBaseUniversalController<GrantObject>
    {
    protected IGrantService m_GrantService;

    protected IGrantService GrantService
    {
    get
    {
    if (m_GrantService == null)
    {
    m_GrantService = GetService() as IGrantService;
    }

    return m_GrantService;
    }
    }
    protected override IDataService<GrantObject> GetService()
    {
        return DataServiceLocator.GrantService;
    }
    }
    }
  