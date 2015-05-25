
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Journal
    File name: 	Journal.object.cs
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


    [MetadataTypeAttribute(typeof(JournalMeta
  ))]
    public partial class JournalObject : DatabaseEntity, IDatabaseEntity
    {
    public JournalObject()
    {
      ObjectType = "journal";
      Title = "";
        ShortDescription = "";
        CreationDate = DateTime.Now;
        
    }



    
    [ScaffoldColumn(false)]
    public 
      IEnumerable<CommentObject>
     Comments
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<FileAttachmentObject>
     FileAttachments
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<PhotoObject>
     Photos
     { get; set; }
  
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64? Owner_User_ID { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String ShortDescription { get; set; }
    
      public System.String PdfFile { get; set; }
    
      public System.String Image { get; set; }
    
      public System.String ISBN { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.Int32 AUTO_MaterialsCount { get; set; }
    
      public System.Int32 AUTO_CommentCount { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.DateTime? AUTO_Comment_LastDateTime { get; set; }
    
      public System.Int32 AUTO_ReadersCount { get; set; }
    
      public System.Guid? AUTO_DefaultPhoto_Guid { get; set; }
    
      public System.String AUTO_DefaultPhoto_Alt { get; set; }
    
      public System.Boolean PSEUDO_IsUserFavourite { get; set; }
    
      public System.Int32 PSEUDO_NewCommentCount { get; set; }
    

    public class Converter : IConvertibleFactory<Journal, JournalObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Journal, JournalObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<Journal>( s => s.Comments );
    
      dlo.LoadWith<Journal>( s => s.FileAttachments );
    
      dlo.LoadWith<Journal>( s => s.Photos );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Journal, JournalObject>> GetConverter()
    {
    return (db) => new JournalObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Owner_User_ID = db.Owner_User_ID,
    Title = db.Title,
    ShortDescription = db.ShortDescription,
    PdfFile = db.PdfFile,
    Image = db.Image,
    ISBN = db.ISBN,
    PublicationDate = db.PublicationDate,
    AUTO_MaterialsCount = db.AUTO_MaterialsCount,
    AUTO_CommentCount = db.AUTO_CommentCount,
    CreationDate = db.CreationDate,
    ModificationDate = db.ModificationDate,
    AUTO_Comment_LastDateTime = db.AUTO_Comment_LastDateTime,
    AUTO_ReadersCount = db.AUTO_ReadersCount,
    AUTO_DefaultPhoto_Guid = db.AUTO_DefaultPhoto_Guid,
    AUTO_DefaultPhoto_Alt = db.AUTO_DefaultPhoto_Alt,
    PSEUDO_IsUserFavourite = db.PSEUDO_IsUserFavourite,
    PSEUDO_NewCommentCount = db.PSEUDO_NewCommentCount,
    

    };
    }

    public Action<JournalObject, Journal> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "journal"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Title = param.Title;
      
        target.ShortDescription = param.ShortDescription;
      
        target.PdfFile = param.PdfFile;
      
        target.Image = param.Image;
      
        target.ISBN = param.ISBN;
      
        target.PublicationDate = param.PublicationDate;
      
        target.AUTO_MaterialsCount = param.AUTO_MaterialsCount;
      
        target.AUTO_CommentCount = param.AUTO_CommentCount;
      
        target.CreationDate = param.CreationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_Comment_LastDateTime = param.AUTO_Comment_LastDateTime;
      
        target.AUTO_ReadersCount = param.AUTO_ReadersCount;
      
        target.AUTO_DefaultPhoto_Guid = param.AUTO_DefaultPhoto_Guid;
      
        target.AUTO_DefaultPhoto_Alt = param.AUTO_DefaultPhoto_Alt;
      
        target.PSEUDO_IsUserFavourite = param.PSEUDO_IsUserFavourite;
      
        target.PSEUDO_NewCommentCount = param.PSEUDO_NewCommentCount;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Journal, JournalObject> CONVERT;
    public static Action<JournalObject, Journal> MODEL_CONVERT;

    }
    }
    }
  