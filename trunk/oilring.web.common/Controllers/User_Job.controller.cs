
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Job
    File name: 	User_Job.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class User_JobController : OilringBaseUniversalController<User_JobObject>
    {
    protected IUser_JobService m_User_JobService;

    protected IUser_JobService User_JobService
    {
    get
    {
    if (m_User_JobService == null)
    {
    m_User_JobService = GetService() as IUser_JobService;
    }

    return m_User_JobService;
    }
    }
    protected override IDataService<User_JobObject> GetService()
    {
        return DataServiceLocator.User_JobService;
    }
    }
    }
  