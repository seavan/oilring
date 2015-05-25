
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Discussion
    File name: 	Discussion.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class DiscussionController : OilringBaseUniversalController<DiscussionObject>
    {
    protected IDiscussionService m_DiscussionService;

    protected IDiscussionService DiscussionService
    {
    get
    {
    if (m_DiscussionService == null)
    {
    m_DiscussionService = GetService() as IDiscussionService;
    }

    return m_DiscussionService;
    }
    }
    protected override IDataService<DiscussionObject> GetService()
    {
        return DataServiceLocator.DiscussionService;
    }
    }
    }
  