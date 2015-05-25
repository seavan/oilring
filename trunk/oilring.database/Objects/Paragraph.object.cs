
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Paragraph
    File name: 	Paragraph.object.cs
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


    [MetadataTypeAttribute(typeof(ParagraphMeta
  ))]
    public partial class ParagraphObject : DatabaseEntity, IDatabaseEntity
    {
    public ParagraphObject()
    {
      ObjectType = "paragraph";
      Text = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 Article_ID { get; set; }
    
      public System.Int32 ParagraphNo { get; set; }
    
      public System.String Text { get; set; }
    

    public class Converter : IConvertibleFactory<Paragraph, ParagraphObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Paragraph, ParagraphObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Paragraph, ParagraphObject>> GetConverter()
    {
    return (db) => new ParagraphObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Article_ID = db.Article_ID,
    ParagraphNo = db.ParagraphNo,
    Text = db.Text,
    

    };
    }

    public Action<ParagraphObject, Paragraph> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "paragraph"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Article_ID = param.Article_ID;
      
        target.ParagraphNo = param.ParagraphNo;
      
        target.Text = param.Text;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Paragraph, ParagraphObject> CONVERT;
    public static Action<ParagraphObject, Paragraph> MODEL_CONVERT;

    }
    }
    }
  