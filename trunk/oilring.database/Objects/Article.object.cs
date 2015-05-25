
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Article
    File name: 	Article.object.cs
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


    [MetadataTypeAttribute(typeof(ArticleMeta
  ))]
    public partial class ArticleObject : DatabaseEntity, IDatabaseEntity
    {
    public ArticleObject()
    {
      ObjectType = "article";
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
    

    public class Converter : IConvertibleFactory<Article, ArticleObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Article, ArticleObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<Article>( s => s.Comments );
    
      dlo.LoadWith<Article>( s => s.FileAttachments );
    
      dlo.LoadWith<Article>( s => s.Photos );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Article, ArticleObject>> GetConverter()
    {
    return (db) => new ArticleObject()
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
    

    };
    }

    public Action<ArticleObject, Article> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "article"; }
      
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
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Article, ArticleObject> CONVERT;
    public static Action<ArticleObject, Article> MODEL_CONVERT;

    }
    }
    }
  