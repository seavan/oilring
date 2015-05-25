
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	ViewUserMaterial
    File name: 	ViewUserMaterial.object.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using Notamedia.Oilring.Database.DataAccess;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Linq;
using Database.Interfaces;
using Database.Entities;

    namespace admin.db
    {


    [MetadataTypeAttribute(typeof(ViewUserMaterialMeta
  ))]
    public partial class ViewUserMaterialObject : DatabaseEntity, IDatabaseEntity
    {
    public ViewUserMaterialObject()
    {
      ObjectType = "viewusermaterial";
      Title = "";
        CreationDate = DateTime.Now;
        
    }



    
      public System.Int64 Id { get; set; }
    
      public System.String ObjectType { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String ShortDescription { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.Int64? ObjectAuthorId { get; set; }
    
      public System.String ObjectAuthorType { get; set; }
    

    public class Converter : IConvertibleFactory<ViewUserMaterial, ViewUserMaterialObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<ViewUserMaterial, ViewUserMaterialObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<ViewUserMaterial, ViewUserMaterialObject>> GetConverter()
    {
    return (db) => new ViewUserMaterialObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Lang = db.Lang,
    Published = db.Published,
    Approved = db.Approved,
    Title = db.Title,
    ShortDescription = db.ShortDescription,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ObjectAuthorId = db.ObjectAuthorId,
    ObjectAuthorType = db.ObjectAuthorType,
    

    };
    }

    public Action<ViewUserMaterialObject, ViewUserMaterial> GetModelConverter()
    {
    return (param, target) =>
    {
    
        target.Id = param.Id;
      
        target.ObjectType = param.ObjectType;
      
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "viewusermaterial"; }
      
        target.Lang = param.Lang;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Title = param.Title;
      
        target.ShortDescription = param.ShortDescription;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ObjectAuthorId = param.ObjectAuthorId;
      
        target.ObjectAuthorType = param.ObjectAuthorType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<ViewUserMaterial, ViewUserMaterialObject> CONVERT;
    public static Action<ViewUserMaterialObject, ViewUserMaterial> MODEL_CONVERT;

    }
    }
    }
  