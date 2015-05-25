
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Patent
    File name: 	Patent.object.cs
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


    [MetadataTypeAttribute(typeof(PatentMeta
  ))]
    public partial class PatentObject : DatabaseEntity, IDatabaseEntity
    {
    public PatentObject()
    {
      ObjectType = "patent";
      Title = "";
        CreationDate = DateTime.Now;
        Number = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Title { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.String Number { get; set; }
    

    public class Converter : IConvertibleFactory<Patent, PatentObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Patent, PatentObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Patent, PatentObject>> GetConverter()
    {
    return (db) => new PatentObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Title = db.Title,
    CreationDate = db.CreationDate,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Number = db.Number,
    

    };
    }

    public Action<PatentObject, Patent> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "patent"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Title = param.Title;
      
        target.CreationDate = param.CreationDate;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Number = param.Number;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Patent, PatentObject> CONVERT;
    public static Action<PatentObject, Patent> MODEL_CONVERT;

    }
    }
    }
  