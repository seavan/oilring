
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Contact
    File name: 	Contact.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class ContactController : OilringBaseUniversalController<ContactObject>
    {
    protected IContactService m_ContactService;

    protected IContactService ContactService
    {
    get
    {
    if (m_ContactService == null)
    {
    m_ContactService = GetService() as IContactService;
    }

    return m_ContactService;
    }
    }
    protected override IDataService<ContactObject> GetService()
    {
        return DataServiceLocator.ContactService;
    }
    }
    }
  