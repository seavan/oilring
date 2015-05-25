
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Seminar
    File name: 	Seminar.object.cs
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


    [MetadataTypeAttribute(typeof(SeminarMeta
  ))]
    public partial class SeminarObject : DatabaseEntity, IDatabaseEntity
    {
    public SeminarObject()
    {
      ObjectType = "seminar";
      EventStartDate = DateTime.Now;
        Place = "";
        Title = "";
        CreationDate = DateTime.Now;
        EventEndDate = DateTime.Now;
        
    }



    
    [ScaffoldColumn(false)]
    public 
      IEnumerable<CommentObject>
     Comments
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<ReportObject>
     Reports
     { get; set; }
  
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int32 State { get; set; }
    
      public System.DateTime EventStartDate { get; set; }
    
      public System.String Place { get; set; }
    
      public System.Int64? Owner_User_ID { get; set; }
    
      public System.String Title { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_CommentCount { get; set; }
    
      public System.String ShortDescription { get; set; }
    
      public System.String Text { get; set; }
    
      public System.DateTime EventEndDate { get; set; }
    
      public System.DateTime? AUTO_Comment_LastDateTime { get; set; }
    
      public System.Guid? AUTO_DefaultPhoto_Guid { get; set; }
    
      public System.String AUTO_DefaultPhoto_Alt { get; set; }
    
      public System.Int32 AUTO_ObjectUserVisitorCount { get; set; }
    
      public System.Boolean PSEUDO_IsUserFavourite { get; set; }
    
      public System.Int32 PSEUDO_NewCommentCount { get; set; }
    
      public System.Boolean IsCycle { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    

    public class Converter : IConvertibleFactory<Seminar, SeminarObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Seminar, SeminarObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<Seminar>( s => s.Comments );
    
      dlo.LoadWith<Seminar>( s => s.Reports );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Seminar, SeminarObject>> GetConverter()
    {
    return (db) => new SeminarObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    State = db.State,
    EventStartDate = db.EventStartDate,
    Place = db.Place,
    Owner_User_ID = db.Owner_User_ID,
    Title = db.Title,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    AUTO_CommentCount = db.AUTO_CommentCount,
    ShortDescription = db.ShortDescription,
    Text = db.Text,
    EventEndDate = db.EventEndDate,
    AUTO_Comment_LastDateTime = db.AUTO_Comment_LastDateTime,
    AUTO_DefaultPhoto_Guid = db.AUTO_DefaultPhoto_Guid,
    AUTO_DefaultPhoto_Alt = db.AUTO_DefaultPhoto_Alt,
    AUTO_ObjectUserVisitorCount = db.AUTO_ObjectUserVisitorCount,
    PSEUDO_IsUserFavourite = db.PSEUDO_IsUserFavourite,
    PSEUDO_NewCommentCount = db.PSEUDO_NewCommentCount,
    IsCycle = db.IsCycle,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    

    };
    }

    public Action<SeminarObject, Seminar> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "seminar"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.State = param.State;
      
        target.EventStartDate = param.EventStartDate;
      
        target.Place = param.Place;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.Title = param.Title;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_CommentCount = param.AUTO_CommentCount;
      
        target.ShortDescription = param.ShortDescription;
      
        target.Text = param.Text;
      
        target.EventEndDate = param.EventEndDate;
      
        target.AUTO_Comment_LastDateTime = param.AUTO_Comment_LastDateTime;
      
        target.AUTO_DefaultPhoto_Guid = param.AUTO_DefaultPhoto_Guid;
      
        target.AUTO_DefaultPhoto_Alt = param.AUTO_DefaultPhoto_Alt;
      
        target.AUTO_ObjectUserVisitorCount = param.AUTO_ObjectUserVisitorCount;
      
        target.PSEUDO_IsUserFavourite = param.PSEUDO_IsUserFavourite;
      
        target.PSEUDO_NewCommentCount = param.PSEUDO_NewCommentCount;
      
        target.IsCycle = param.IsCycle;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Seminar, SeminarObject> CONVERT;
    public static Action<SeminarObject, Seminar> MODEL_CONVERT;

    }
    }
    }
  