
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PrivateMessageItem
    File name: 	PrivateMessageItem.object.cs
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


    [MetadataTypeAttribute(typeof(PrivateMessageItemMeta
  ))]
    public partial class PrivateMessageItemObject : DatabaseEntity, IDatabaseEntity
    {
    public PrivateMessageItemObject()
    {
      ObjectType = "privatemessageitem";
      CreationDate = DateTime.Now;
        EmailType = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 Owner_User_ID { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Boolean IsEmailSent { get; set; }
    
      public System.String EmailType { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.String Subject { get; set; }
    
      public System.String Text { get; set; }
    
      public System.Int64 REL_SenderUserId { get; set; }
    
      public System.Int64 REL_ReceiverUserId { get; set; }
    

    public class Converter : IConvertibleFactory<PrivateMessageItem, PrivateMessageItemObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<PrivateMessageItem, PrivateMessageItemObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<PrivateMessageItem, PrivateMessageItemObject>> GetConverter()
    {
    return (db) => new PrivateMessageItemObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Owner_User_ID = db.Owner_User_ID,
    CreationDate = db.CreationDate,
    PublicationDate = db.PublicationDate,
    ModificationDate = db.ModificationDate,
    IsEmailSent = db.IsEmailSent,
    EmailType = db.EmailType,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Subject = db.Subject,
    Text = db.Text,
    REL_SenderUserId = db.REL_SenderUserId,
    REL_ReceiverUserId = db.REL_ReceiverUserId,
    

    };
    }

    public Action<PrivateMessageItemObject, PrivateMessageItem> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "privatemessageitem"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Owner_User_ID = param.Owner_User_ID;
      
        target.CreationDate = param.CreationDate;
      
        target.PublicationDate = param.PublicationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.IsEmailSent = param.IsEmailSent;
      
        target.EmailType = param.EmailType;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Subject = param.Subject;
      
        target.Text = param.Text;
      
        target.REL_SenderUserId = param.REL_SenderUserId;
      
        target.REL_ReceiverUserId = param.REL_ReceiverUserId;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<PrivateMessageItem, PrivateMessageItemObject> CONVERT;
    public static Action<PrivateMessageItemObject, PrivateMessageItem> MODEL_CONVERT;

    }
    }
    }
  