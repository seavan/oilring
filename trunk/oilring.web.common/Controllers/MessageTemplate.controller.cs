
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	MessageTemplate
    File name: 	MessageTemplate.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class MessageTemplateController : OilringBaseUniversalController<MessageTemplateObject>
    {
    protected IMessageTemplateService m_MessageTemplateService;

    protected IMessageTemplateService MessageTemplateService
    {
    get
    {
    if (m_MessageTemplateService == null)
    {
    m_MessageTemplateService = GetService() as IMessageTemplateService;
    }

    return m_MessageTemplateService;
    }
    }
    protected override IDataService<MessageTemplateObject> GetService()
    {
        return DataServiceLocator.MessageTemplateService;
    }
    }
    }
  