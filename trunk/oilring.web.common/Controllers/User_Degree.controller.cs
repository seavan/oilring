
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Degree
    File name: 	User_Degree.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class User_DegreeController : OilringBaseUniversalController<User_DegreeObject>
    {
    protected IUser_DegreeService m_User_DegreeService;

    protected IUser_DegreeService User_DegreeService
    {
    get
    {
    if (m_User_DegreeService == null)
    {
    m_User_DegreeService = GetService() as IUser_DegreeService;
    }

    return m_User_DegreeService;
    }
    }
    protected override IDataService<User_DegreeObject> GetService()
    {
        return DataServiceLocator.User_DegreeService;
    }
    }
    }
  