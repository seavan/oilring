
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Notification
    File name: 	Notification.object.cs
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


    [MetadataTypeAttribute(typeof(NotificationMeta
  ))]
    public partial class NotificationObject : DatabaseEntity, IDatabaseEntity
    {
    public NotificationObject()
    {
      ObjectType = "notification";
      CreationDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Text { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_UsageCount { get; set; }
    
      public System.Boolean IsEmailSent { get; set; }
    
      public System.Int32 NotificationType { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.Int64? REL_Entity_ID { get; set; }
    
      public System.String REL_Entity_ObjectType { get; set; }
    
      public System.Int64? REL_User_ID { get; set; }
    
      public System.String REL_User_ObjectType { get; set; }
    
      public System.Boolean? IsAccepted { get; set; }
    
      public System.Boolean? IsDenied { get; set; }
    

    public class Converter : IConvertibleFactory<Notification, NotificationObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Notification, NotificationObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Notification, NotificationObject>> GetConverter()
    {
    return (db) => new NotificationObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Text = db.Text,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    AUTO_UsageCount = db.AUTO_UsageCount,
    IsEmailSent = db.IsEmailSent,
    NotificationType = db.NotificationType,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    REL_Entity_ID = db.REL_Entity_ID,
    REL_Entity_ObjectType = db.REL_Entity_ObjectType,
    REL_User_ID = db.REL_User_ID,
    REL_User_ObjectType = db.REL_User_ObjectType,
    IsAccepted = db.IsAccepted,
    IsDenied = db.IsDenied,
    

    };
    }

    public Action<NotificationObject, Notification> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "notification"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Text = param.Text;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_UsageCount = param.AUTO_UsageCount;
      
        target.IsEmailSent = param.IsEmailSent;
      
        target.NotificationType = param.NotificationType;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.REL_Entity_ID = param.REL_Entity_ID;
      
        target.REL_Entity_ObjectType = param.REL_Entity_ObjectType;
      
        target.REL_User_ID = param.REL_User_ID;
      
        target.REL_User_ObjectType = param.REL_User_ObjectType;
      
        target.IsAccepted = param.IsAccepted;
      
        target.IsDenied = param.IsDenied;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Notification, NotificationObject> CONVERT;
    public static Action<NotificationObject, Notification> MODEL_CONVERT;

    }
    }
    }
  