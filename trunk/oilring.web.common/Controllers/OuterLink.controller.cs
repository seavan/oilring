
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	OuterLink
    File name: 	OuterLink.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class OuterLinkController : OilringBaseUniversalController<OuterLinkObject>
    {
    protected IOuterLinkService m_OuterLinkService;

    protected IOuterLinkService OuterLinkService
    {
    get
    {
    if (m_OuterLinkService == null)
    {
    m_OuterLinkService = GetService() as IOuterLinkService;
    }

    return m_OuterLinkService;
    }
    }
    protected override IDataService<OuterLinkObject> GetService()
    {
        return DataServiceLocator.OuterLinkService;
    }
    }
    }
  