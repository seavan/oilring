
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	ViewMaterial
    File name: 	ViewMaterial.object.cs
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


    [MetadataTypeAttribute(typeof(ViewMaterialMeta
  ))]
    public partial class ViewMaterialObject : DatabaseEntity, IDatabaseEntity
    {
    public ViewMaterialObject()
    {
      ObjectType = "viewmaterial";
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
    

    public class Converter : IConvertibleFactory<ViewMaterial, ViewMaterialObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<ViewMaterial, ViewMaterialObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<ViewMaterial, ViewMaterialObject>> GetConverter()
    {
    return (db) => new ViewMaterialObject()
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
    

    };
    }

    public Action<ViewMaterialObject, ViewMaterial> GetModelConverter()
    {
    return (param, target) =>
    {
    
        target.Id = param.Id;
      
        target.ObjectType = param.ObjectType;
      
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "viewmaterial"; }
      
        target.Lang = param.Lang;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Title = param.Title;
      
        target.ShortDescription = param.ShortDescription;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<ViewMaterial, ViewMaterialObject> CONVERT;
    public static Action<ViewMaterialObject, ViewMaterial> MODEL_CONVERT;

    }
    }
    }
  