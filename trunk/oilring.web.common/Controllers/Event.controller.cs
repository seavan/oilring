
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Event
    File name: 	Event.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class EventController : OilringBaseUniversalController<EventObject>
    {
    protected IEventService m_EventService;

    protected IEventService EventService
    {
    get
    {
    if (m_EventService == null)
    {
    m_EventService = GetService() as IEventService;
    }

    return m_EventService;
    }
    }
    protected override IDataService<EventObject> GetService()
    {
        return DataServiceLocator.EventService;
    }
    }
    }
  