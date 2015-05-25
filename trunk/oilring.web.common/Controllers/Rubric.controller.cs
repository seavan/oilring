
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Rubric
    File name: 	Rubric.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class RubricController : OilringBaseUniversalController<RubricObject>
    {
    protected IRubricService m_RubricService;

    protected IRubricService RubricService
    {
    get
    {
    if (m_RubricService == null)
    {
    m_RubricService = GetService() as IRubricService;
    }

    return m_RubricService;
    }
    }
    protected override IDataService<RubricObject> GetService()
    {
        return DataServiceLocator.RubricService;
    }
    }
    }
  