
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Photo
    File name: 	Photo.object.cs
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


    [MetadataTypeAttribute(typeof(PhotoMeta
  ))]
    public partial class PhotoObject : DatabaseEntity, IDatabaseEntity
    {
    public PhotoObject()
    {
      ObjectType = "photo";
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
    
      public System.String ImageFormat { get; set; }
    
      public System.Guid? Guid { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 OrigWidth { get; set; }
    
      public System.Int32 OrigHeight { get; set; }
    
      public System.Int32 Width { get; set; }
    
      public System.Int32 Height { get; set; }
    
      public System.Int32 ThumbWidth { get; set; }
    
      public System.Int32 ThumbHeight { get; set; }
    
      public System.Boolean IsInText { get; set; }
    

    public class Converter : IConvertibleFactory<Photo, PhotoObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Photo, PhotoObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Photo, PhotoObject>> GetConverter()
    {
    return (db) => new PhotoObject()
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
    ImageFormat = db.ImageFormat,
    Guid = db.Guid,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    OrigWidth = db.OrigWidth,
    OrigHeight = db.OrigHeight,
    Width = db.Width,
    Height = db.Height,
    ThumbWidth = db.ThumbWidth,
    ThumbHeight = db.ThumbHeight,
    IsInText = db.IsInText,
    

    };
    }

    public Action<PhotoObject, Photo> GetModelConverter()
    {
    return (param, target) =>
    {
    
        target.ObjectType = param.ObjectType;
      
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "photo"; }
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Title = param.Title;
      
        target.UserFileName = param.UserFileName;
      
        target.ImageFormat = param.ImageFormat;
      
        target.Guid = param.Guid;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.OrigWidth = param.OrigWidth;
      
        target.OrigHeight = param.OrigHeight;
      
        target.Width = param.Width;
      
        target.Height = param.Height;
      
        target.ThumbWidth = param.ThumbWidth;
      
        target.ThumbHeight = param.ThumbHeight;
      
        target.IsInText = param.IsInText;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Photo, PhotoObject> CONVERT;
    public static Action<PhotoObject, Photo> MODEL_CONVERT;

    }
    }
    }
  