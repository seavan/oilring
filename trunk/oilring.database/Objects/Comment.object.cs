
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Comment
    File name: 	Comment.object.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using Notamedia.Oilring.Database.DataAccess;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Linq;
using Database.Entities;
using Database.Interfaces;

    namespace admin.db
    {


    [MetadataTypeAttribute(typeof(CommentMeta
  ))]
    public partial class CommentObject : DatabaseEntity, IDatabaseEntity
    {
    public CommentObject()
    {
      ObjectType = "comment";
      CreationDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.Int64 Parent_Comment_ID { get; set; }
    
      public System.Int64? Owner_User_ID { get; set; }
    
      public System.String Text { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_CommentCount { get; set; }
    

    public class Converter : IConvertibleFactory<Comment, CommentObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Comment, CommentObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Comment, CommentObject>> GetConverter()
    {
    return (db) => new CommentObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Parent_Comment_ID = db.Parent_Comment_ID,
    Owner_User_ID = db.Owner_User_ID,
    Text = db.Text,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    AUTO_CommentCount = db.AUTO_CommentCount,
    

    };
    }

    public Action<CommentObject, Comment> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "comment"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Parent_Comment_ID = param.Parent_Comment_ID;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Text = param.Text;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_CommentCount = param.AUTO_CommentCount;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Comment, CommentObject> CONVERT;
    public static Action<CommentObject, Comment> MODEL_CONVERT;

    }
    }
    }
  