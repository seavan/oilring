
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	FileAttachment
    File name: 	FileAttachment.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class FileAttachmentController : OilringBaseUniversalController<FileAttachmentObject>
    {
    protected IFileAttachmentService m_FileAttachmentService;

    protected IFileAttachmentService FileAttachmentService
    {
    get
    {
    if (m_FileAttachmentService == null)
    {
    m_FileAttachmentService = GetService() as IFileAttachmentService;
    }

    return m_FileAttachmentService;
    }
    }
    protected override IDataService<FileAttachmentObject> GetService()
    {
        return DataServiceLocator.FileAttachmentService;
    }
    }
    }
  