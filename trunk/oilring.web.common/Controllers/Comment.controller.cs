
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Comment
    File name: 	Comment.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
        public partial class CommentController : OilringBaseUniversalController<CommentObject>
    {
    protected ICommentService m_CommentService;

    protected ICommentService CommentService
    {
    get
    {
    if (m_CommentService == null)
    {
    m_CommentService = GetService() as ICommentService;
    }

    return m_CommentService;
    }
    }
    protected override IDataService<CommentObject> GetService()
    {
        return DataServiceLocator.CommentService;
    }
    }
    }
  