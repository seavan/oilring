
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Dummy_SearchObject
    File name: 	Dummy_SearchObject.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class Dummy_SearchObjectController : OilringBaseUniversalController<Dummy_SearchObjectObject>
    {
    protected IDummy_SearchObjectService m_Dummy_SearchObjectService;

    protected IDummy_SearchObjectService Dummy_SearchObjectService
    {
    get
    {
    if (m_Dummy_SearchObjectService == null)
    {
    m_Dummy_SearchObjectService = GetService() as IDummy_SearchObjectService;
    }

    return m_Dummy_SearchObjectService;
    }
    }
    protected override IDataService<Dummy_SearchObjectObject> GetService()
    {
        return DataServiceLocator.Dummy_SearchObjectService;
    }
    }
    }
  