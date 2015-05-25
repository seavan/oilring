
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization
    File name: 	Organization.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class OrganizationController : OilringBaseUniversalController<OrganizationObject>
    {
    protected IOrganizationService m_OrganizationService;

    protected IOrganizationService OrganizationService
    {
    get
    {
    if (m_OrganizationService == null)
    {
    m_OrganizationService = GetService() as IOrganizationService;
    }

    return m_OrganizationService;
    }
    }
    protected override IDataService<OrganizationObject> GetService()
    {
        return DataServiceLocator.OrganizationService;
    }
    }
    }
  