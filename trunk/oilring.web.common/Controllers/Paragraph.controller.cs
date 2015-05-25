
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Paragraph
    File name: 	Paragraph.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class ParagraphController : OilringBaseUniversalController<ParagraphObject>
    {
    protected IParagraphService m_ParagraphService;

    protected IParagraphService ParagraphService
    {
    get
    {
    if (m_ParagraphService == null)
    {
    m_ParagraphService = GetService() as IParagraphService;
    }

    return m_ParagraphService;
    }
    }
    protected override IDataService<ParagraphObject> GetService()
    {
        return DataServiceLocator.ParagraphService;
    }
    }
    }
  