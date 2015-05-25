
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Univer
    File name: 	User_Univer.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class User_UniverController : OilringBaseUniversalController<User_UniverObject>
    {
    protected IUser_UniverService m_User_UniverService;

    protected IUser_UniverService User_UniverService
    {
    get
    {
    if (m_User_UniverService == null)
    {
    m_User_UniverService = GetService() as IUser_UniverService;
    }

    return m_User_UniverService;
    }
    }
    protected override IDataService<User_UniverObject> GetService()
    {
        return DataServiceLocator.User_UniverService;
    }
    }
    }
  