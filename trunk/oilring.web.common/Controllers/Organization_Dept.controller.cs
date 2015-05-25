
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization_Dept
    File name: 	Organization_Dept.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class Organization_DeptController : OilringBaseUniversalController<Organization_DeptObject>
    {
    protected IOrganization_DeptService m_Organization_DeptService;

    protected IOrganization_DeptService Organization_DeptService
    {
    get
    {
    if (m_Organization_DeptService == null)
    {
    m_Organization_DeptService = GetService() as IOrganization_DeptService;
    }

    return m_Organization_DeptService;
    }
    }
    protected override IDataService<Organization_DeptObject> GetService()
    {
        return DataServiceLocator.Organization_DeptService;
    }
    }
    }
  