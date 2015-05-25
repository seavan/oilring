
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Techno
    File name: 	Techno.object.cs
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


    [MetadataTypeAttribute(typeof(TechnoMeta
  ))]
    public partial class TechnoObject : DatabaseEntity, IDatabaseEntity
    {
    public TechnoObject()
    {
      ObjectType = "techno";
      Title = "";
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
      IEnumerable<PatentObject>
     Patents
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
    
      public System.String Text { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_CommentCount { get; set; }
    
      public System.DateTime? AUTO_Comment_LastDateTime { get; set; }
    
      public System.Guid? AUTO_DefaultPhoto_Guid { get; set; }
    
      public System.String AUTO_DefaultPhoto_Alt { get; set; }
    
      public System.Boolean PSEUDO_IsUserFavourite { get; set; }
    
      public System.Int32 PSEUDO_NewCommentCount { get; set; }
    
      public System.String DevelopmentStage { get; set; }
    
      public System.String InnovativeFeatures { get; set; }
    
      public System.String CompetitiveAdvantages { get; set; }
    
      public System.String Scope { get; set; }
    
      public System.String ResourcesDevelopment { get; set; }
    
      public System.String WayCommercialization { get; set; }
    
      public System.String RestrictionsCommercialization { get; set; }
    
      public System.String ExpectedMarket { get; set; }
    
      public System.String CommercialExperience { get; set; }
    
      public System.String AdditionalInformation { get; set; }
    

    public class Converter : IConvertibleFactory<Techno, TechnoObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Techno, TechnoObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<Techno>( s => s.Comments );
    
      dlo.LoadWith<Techno>( s => s.FileAttachments );
    
      dlo.LoadWith<Techno>( s => s.Patents );
    
      dlo.LoadWith<Techno>( s => s.Photos );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Techno, TechnoObject>> GetConverter()
    {
    return (db) => new TechnoObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Owner_User_ID = db.Owner_User_ID,
    Title = db.Title,
    ShortDescription = db.ShortDescription,
    Text = db.Text,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    AUTO_CommentCount = db.AUTO_CommentCount,
    AUTO_Comment_LastDateTime = db.AUTO_Comment_LastDateTime,
    AUTO_DefaultPhoto_Guid = db.AUTO_DefaultPhoto_Guid,
    AUTO_DefaultPhoto_Alt = db.AUTO_DefaultPhoto_Alt,
    PSEUDO_IsUserFavourite = db.PSEUDO_IsUserFavourite,
    PSEUDO_NewCommentCount = db.PSEUDO_NewCommentCount,
    DevelopmentStage = db.DevelopmentStage,
    InnovativeFeatures = db.InnovativeFeatures,
    CompetitiveAdvantages = db.CompetitiveAdvantages,
    Scope = db.Scope,
    ResourcesDevelopment = db.ResourcesDevelopment,
    WayCommercialization = db.WayCommercialization,
    RestrictionsCommercialization = db.RestrictionsCommercialization,
    ExpectedMarket = db.ExpectedMarket,
    CommercialExperience = db.CommercialExperience,
    AdditionalInformation = db.AdditionalInformation,
    

    };
    }

    public Action<TechnoObject, Techno> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "techno"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Title = param.Title;
      
        target.ShortDescription = param.ShortDescription;
      
        target.Text = param.Text;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_CommentCount = param.AUTO_CommentCount;
      
        target.AUTO_Comment_LastDateTime = param.AUTO_Comment_LastDateTime;
      
        target.AUTO_DefaultPhoto_Guid = param.AUTO_DefaultPhoto_Guid;
      
        target.AUTO_DefaultPhoto_Alt = param.AUTO_DefaultPhoto_Alt;
      
        target.PSEUDO_IsUserFavourite = param.PSEUDO_IsUserFavourite;
      
        target.PSEUDO_NewCommentCount = param.PSEUDO_NewCommentCount;
      
        target.DevelopmentStage = param.DevelopmentStage;
      
        target.InnovativeFeatures = param.InnovativeFeatures;
      
        target.CompetitiveAdvantages = param.CompetitiveAdvantages;
      
        target.Scope = param.Scope;
      
        target.ResourcesDevelopment = param.ResourcesDevelopment;
      
        target.WayCommercialization = param.WayCommercialization;
      
        target.RestrictionsCommercialization = param.RestrictionsCommercialization;
      
        target.ExpectedMarket = param.ExpectedMarket;
      
        target.CommercialExperience = param.CommercialExperience;
      
        target.AdditionalInformation = param.AdditionalInformation;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Techno, TechnoObject> CONVERT;
    public static Action<TechnoObject, Techno> MODEL_CONVERT;

    }
    }
    }
  