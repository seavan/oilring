
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	FileAttachment
    File name: 	FileAttachment.object.cs
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


    [MetadataTypeAttribute(typeof(FileAttachmentMeta
  ))]
    public partial class FileAttachmentObject : DatabaseEntity, IDatabaseEntity
    {
    public FileAttachmentObject()
    {
      ObjectType = "fileattachment";
      Title = "";
        CreationDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
      public System.String ObjectType { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64? Owner_User_ID { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String UserFileName { get; set; }
    
      public System.Guid? Guid { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int64 OrigFileSize { get; set; }
    
      public System.Boolean IsInText { get; set; }
    
      public System.String FileType { get; set; }
    
      public System.Boolean? IsConversionRequired { get; set; }
    
      public System.Boolean? IsConverted { get; set; }
    
      public System.Boolean? IsConversionInProgress { get; set; }
    
      public System.String Content { get; set; }
    
      public System.Boolean? IsError { get; set; }
    

    public class Converter : IConvertibleFactory<FileAttachment, FileAttachmentObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<FileAttachment, FileAttachmentObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<FileAttachment, FileAttachmentObject>> GetConverter()
    {
    return (db) => new FileAttachmentObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Owner_User_ID = db.Owner_User_ID,
    Title = db.Title,
    UserFileName = db.UserFileName,
    Guid = db.Guid,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    OrigFileSize = db.OrigFileSize,
    IsInText = db.IsInText,
    FileType = db.FileType,
    IsConversionRequired = db.IsConversionRequired,
    IsConverted = db.IsConverted,
    IsConversionInProgress = db.IsConversionInProgress,
    Content = db.Content,
    IsError = db.IsError,
    

    };
    }

    public Action<FileAttachmentObject, FileAttachment> GetModelConverter()
    {
    return (param, target) =>
    {
    
        target.ObjectType = param.ObjectType;
      
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "fileattachment"; }
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Title = param.Title;
      
        target.UserFileName = param.UserFileName;
      
        target.Guid = param.Guid;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.OrigFileSize = param.OrigFileSize;
      
        target.IsInText = param.IsInText;
      
        target.FileType = param.FileType;
      
        target.IsConversionRequired = param.IsConversionRequired;
      
        target.IsConverted = param.IsConverted;
      
        target.IsConversionInProgress = param.IsConversionInProgress;
      
        target.Content = param.Content;
      
        target.IsError = param.IsError;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<FileAttachment, FileAttachmentObject> CONVERT;
    public static Action<FileAttachmentObject, FileAttachment> MODEL_CONVERT;

    }
    }
    }
  