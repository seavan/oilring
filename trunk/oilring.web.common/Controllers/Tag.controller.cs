
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Tag
    File name: 	Tag.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class TagController : OilringBaseUniversalController<TagObject>
    {
    protected ITagService m_TagService;

    protected ITagService TagService
    {
    get
    {
    if (m_TagService == null)
    {
    m_TagService = GetService() as ITagService;
    }

    return m_TagService;
    }
    }
    protected override IDataService<TagObject> GetService()
    {
    return DataServiceLocator.TagService;
    }
    }
    }
  