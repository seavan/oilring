
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Conference
    File name: 	Conference.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class ConferenceController : OilringBaseUniversalController<ConferenceObject>
    {
    protected IConferenceService m_ConferenceService;

    protected IConferenceService ConferenceService
    {
    get
    {
    if (m_ConferenceService == null)
    {
    m_ConferenceService = GetService() as IConferenceService;
    }

    return m_ConferenceService;
    }
    }
    protected override IDataService<ConferenceObject> GetService()
    {
    return DataServiceLocator.ConferenceService;
    }
    }
    }
  