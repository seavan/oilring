
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Tag
    File name: 	Tag.object.cs
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


    [MetadataTypeAttribute(typeof(TagMeta
  ))]
    public partial class TagObject : DatabaseEntity, IDatabaseEntity
    {
    public TagObject()
    {
      ObjectType = "tag";
      CreationDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Owner_User_ID { get; set; }
    
      public System.String Text { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_UsageCount { get; set; }
    

    public class Converter : IConvertibleFactory<Tag, TagObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Tag, TagObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Tag, TagObject>> GetConverter()
    {
    return (db) => new TagObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Owner_User_ID = db.Owner_User_ID,
    Text = db.Text,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    AUTO_UsageCount = db.AUTO_UsageCount,
    

    };
    }

    public Action<TagObject, Tag> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "tag"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Text = param.Text;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_UsageCount = param.AUTO_UsageCount;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Tag, TagObject> CONVERT;
    public static Action<TagObject, Tag> MODEL_CONVERT;

    }
    }
    }
  