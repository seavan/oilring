
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PublicationLink
    File name: 	PublicationLink.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class PublicationLinkController : OilringBaseUniversalController<PublicationLinkObject>
    {
    protected IPublicationLinkService m_PublicationLinkService;

    protected IPublicationLinkService PublicationLinkService
    {
    get
    {
    if (m_PublicationLinkService == null)
    {
    m_PublicationLinkService = GetService() as IPublicationLinkService;
    }

    return m_PublicationLinkService;
    }
    }
    protected override IDataService<PublicationLinkObject> GetService()
    {
        return DataServiceLocator.PublicationLinkService;
    }
    }
    }
  