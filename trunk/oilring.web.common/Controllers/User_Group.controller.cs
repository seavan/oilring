
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Group
    File name: 	User_Group.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class User_GroupController : OilringBaseUniversalController<User_GroupObject>
    {
    protected IUser_GroupService m_User_GroupService;

    protected IUser_GroupService User_GroupService
    {
    get
    {
    if (m_User_GroupService == null)
    {
    m_User_GroupService = GetService() as IUser_GroupService;
    }

    return m_User_GroupService;
    }
    }
    protected override IDataService<User_GroupObject> GetService()
    {
        return DataServiceLocator.User_GroupService;
    }
    }
    }
  