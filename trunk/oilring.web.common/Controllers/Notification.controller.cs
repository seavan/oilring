
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Notification
    File name: 	Notification.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class NotificationController : OilringBaseUniversalController<NotificationObject>
    {
    protected INotificationService m_NotificationService;

    protected INotificationService NotificationService
    {
    get
    {
    if (m_NotificationService == null)
    {
    m_NotificationService = GetService() as INotificationService;
    }

    return m_NotificationService;
    }
    }
    protected override IDataService<NotificationObject> GetService()
    {
        return DataServiceLocator.NotificationService;
    }
    }
    }
  