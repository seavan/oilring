
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Techno
    File name: 	Techno.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class TechnoController : OilringBaseUniversalController<TechnoObject>
    {
    protected ITechnoService m_TechnoService;

    protected ITechnoService TechnoService
    {
    get
    {
    if (m_TechnoService == null)
    {
    m_TechnoService = GetService() as ITechnoService;
    }

    return m_TechnoService;
    }
    }
    protected override IDataService<TechnoObject> GetService()
    {
        return DataServiceLocator.TechnoService;
    }
    }
    }
  