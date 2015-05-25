
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Seminar
    File name: 	Seminar.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class SeminarController : OilringBaseUniversalController<SeminarObject>
    {
    protected ISeminarService m_SeminarService;

    protected ISeminarService SeminarService
    {
    get
    {
    if (m_SeminarService == null)
    {
    m_SeminarService = GetService() as ISeminarService;
    }

    return m_SeminarService;
    }
    }
    protected override IDataService<SeminarObject> GetService()
    {
        return DataServiceLocator.SeminarService;
    }
    }
    }
  