
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PrivateMessageItem
    File name: 	PrivateMessageItem.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class PrivateMessageItemController : OilringBaseUniversalController<PrivateMessageItemObject>
    {
    protected IPrivateMessageItemService m_PrivateMessageItemService;

    protected IPrivateMessageItemService PrivateMessageItemService
    {
    get
    {
    if (m_PrivateMessageItemService == null)
    {
    m_PrivateMessageItemService = GetService() as IPrivateMessageItemService;
    }

    return m_PrivateMessageItemService;
    }
    }
    protected override IDataService<PrivateMessageItemObject> GetService()
    {
        return DataServiceLocator.PrivateMessageItemService;
    }
    }
    }
  