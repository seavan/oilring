
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PrivateMessage
    File name: 	PrivateMessage.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class PrivateMessageController : OilringBaseUniversalController<PrivateMessageObject>
    {
    protected IPrivateMessageService m_PrivateMessageService;

    protected IPrivateMessageService PrivateMessageService
    {
    get
    {
    if (m_PrivateMessageService == null)
    {
    m_PrivateMessageService = GetService() as IPrivateMessageService;
    }

    return m_PrivateMessageService;
    }
    }
    protected override IDataService<PrivateMessageObject> GetService()
    {
        return DataServiceLocator.PrivateMessageService;
    }
    }
    }
  