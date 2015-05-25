
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	OuterLink
    File name: 	OuterLink.object.cs
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


    [MetadataTypeAttribute(typeof(OuterLinkMeta
  ))]
    public partial class OuterLinkObject : DatabaseEntity, IDatabaseEntity
    {
    public OuterLinkObject()
    {
      ObjectType = "outerlink";
      Link = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Link { get; set; }
    
      public System.String Text { get; set; }
    

    public class Converter : IConvertibleFactory<OuterLink, OuterLinkObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<OuterLink, OuterLinkObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<OuterLink, OuterLinkObject>> GetConverter()
    {
    return (db) => new OuterLinkObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Link = db.Link,
    Text = db.Text,
    

    };
    }

    public Action<OuterLinkObject, OuterLink> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "outerlink"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Link = param.Link;
      
        target.Text = param.Text;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<OuterLink, OuterLinkObject> CONVERT;
    public static Action<OuterLinkObject, OuterLink> MODEL_CONVERT;

    }
    }
    }
  