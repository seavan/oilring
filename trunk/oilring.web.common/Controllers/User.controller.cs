
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User
    File name: 	User.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class UserController : OilringBaseUniversalController<UserObject>
    {
    protected IUserService m_UserService;

    protected IUserService UserService
    {
    get
    {
    if (m_UserService == null)
    {
    m_UserService = GetService() as IUserService;
    }

    return m_UserService;
    }
    }
    protected override IDataService<UserObject> GetService()
    {
    return DataServiceLocator.UserService;
    }
    }
    }
  