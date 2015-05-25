
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PublicationLink
    File name: 	PublicationLink.object.cs
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


    [MetadataTypeAttribute(typeof(PublicationLinkMeta
  ))]
    public partial class PublicationLinkObject : DatabaseEntity, IDatabaseEntity
    {
    public PublicationLinkObject()
    {
      ObjectType = "publicationlink";
      PublicationTitle = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String PublicationTitle { get; set; }
    
      public System.String ISBN { get; set; }
    
      public System.String Publisher { get; set; }
    
      public System.String Editor { get; set; }
    
      public System.Int64? REF_Journal_Id { get; set; }
    
      public System.String ISSN { get; set; }
    
      public System.String TypePublication { get; set; }
    
      public System.DateTime? DatePublication { get; set; }
    
      public System.Int32? NumberEdition { get; set; }
    

    public class Converter : IConvertibleFactory<PublicationLink, PublicationLinkObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<PublicationLink, PublicationLinkObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<PublicationLink, PublicationLinkObject>> GetConverter()
    {
    return (db) => new PublicationLinkObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    PublicationTitle = db.PublicationTitle,
    ISBN = db.ISBN,
    Publisher = db.Publisher,
    Editor = db.Editor,
    REF_Journal_Id = db.REF_Journal_Id,
    ISSN = db.ISSN,
    TypePublication = db.TypePublication,
    DatePublication = db.DatePublication,
    NumberEdition = db.NumberEdition,
    

    };
    }

    public Action<PublicationLinkObject, PublicationLink> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "publicationlink"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.PublicationTitle = param.PublicationTitle;
      
        target.ISBN = param.ISBN;
      
        target.Publisher = param.Publisher;
      
        target.Editor = param.Editor;
      
        target.REF_Journal_Id = param.REF_Journal_Id;
      
        target.ISSN = param.ISSN;
      
        target.TypePublication = param.TypePublication;
      
        target.DatePublication = param.DatePublication;
      
        target.NumberEdition = param.NumberEdition;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<PublicationLink, PublicationLinkObject> CONVERT;
    public static Action<PublicationLinkObject, PublicationLink> MODEL_CONVERT;

    }
    }
    }
  