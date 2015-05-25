
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Rubric
    File name: 	Rubric.object.cs
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


    [MetadataTypeAttribute(typeof(RubricMeta
  ))]
    public partial class RubricObject : DatabaseEntity, IDatabaseEntity
    {
    public RubricObject()
    {
      ObjectType = "rubric";
      Alias = "";
        Header = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 Parent_Rubric_ID { get; set; }
    
      public System.String Alias { get; set; }
    
      public System.String Header { get; set; }
    
      public System.String MenuTitle_RU_I18N { get; set; }
    
      public System.String MenuTitle_EN_I18N { get; set; }
    

    public class Converter : IConvertibleFactory<Rubric, RubricObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Rubric, RubricObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Rubric, RubricObject>> GetConverter()
    {
    return (db) => new RubricObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Parent_Rubric_ID = db.Parent_Rubric_ID,
    Alias = db.Alias,
    Header = db.Header,
    MenuTitle_RU_I18N = db.MenuTitle_RU_I18N,
    MenuTitle_EN_I18N = db.MenuTitle_EN_I18N,
    

    };
    }

    public Action<RubricObject, Rubric> GetModelConverter()
    {
    return (param, target) =>
    {
    
        target.ObjectType = param.ObjectType;
      
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "rubric"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Parent_Rubric_ID = param.Parent_Rubric_ID;
      
        target.Alias = param.Alias;
      
        target.Header = param.Header;
      
        target.MenuTitle_RU_I18N = param.MenuTitle_RU_I18N;
      
        target.MenuTitle_EN_I18N = param.MenuTitle_EN_I18N;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Rubric, RubricObject> CONVERT;
    public static Action<RubricObject, Rubric> MODEL_CONVERT;

    }
    }
    }
  