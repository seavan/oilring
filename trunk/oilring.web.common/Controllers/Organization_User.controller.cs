
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization_User
    File name: 	Organization_User.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class Organization_UserController : OilringBaseUniversalController<Organization_UserObject>
    {
    protected IOrganization_UserService m_Organization_UserService;

    protected IOrganization_UserService Organization_UserService
    {
    get
    {
    if (m_Organization_UserService == null)
    {
    m_Organization_UserService = GetService() as IOrganization_UserService;
    }

    return m_Organization_UserService;
    }
    }
    protected override IDataService<Organization_UserObject> GetService()
    {
        return DataServiceLocator.Organization_UserService;
    }
    }
    }
  