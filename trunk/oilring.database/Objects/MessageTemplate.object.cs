
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	MessageTemplate
    File name: 	MessageTemplate.object.cs
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


    [MetadataTypeAttribute(typeof(MessageTemplateMeta
  ))]
    public partial class MessageTemplateObject : DatabaseEntity, IDatabaseEntity
    {
    public MessageTemplateObject()
    {
      ObjectType = "messagetemplate";
      Alias = "";
        Title = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Text { get; set; }
    
      public System.String Alias { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String NotificationText { get; set; }
    

    public class Converter : IConvertibleFactory<MessageTemplate, MessageTemplateObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<MessageTemplate, MessageTemplateObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<MessageTemplate, MessageTemplateObject>> GetConverter()
    {
    return (db) => new MessageTemplateObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Lang = db.Lang,
    Published = db.Published,
    Approved = db.Approved,
    Text = db.Text,
    Alias = db.Alias,
    Title = db.Title,
    NotificationText = db.NotificationText,
    

    };
    }

    public Action<MessageTemplateObject, MessageTemplate> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "messagetemplate"; }
      
        target.Lang = param.Lang;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Text = param.Text;
      
        target.Alias = param.Alias;
      
        target.Title = param.Title;
      
        target.NotificationText = param.NotificationText;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<MessageTemplate, MessageTemplateObject> CONVERT;
    public static Action<MessageTemplateObject, MessageTemplate> MODEL_CONVERT;

    }
    }
    }
  