
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	PrivateMessage
    File name: 	PrivateMessage.object.cs
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


    [MetadataTypeAttribute(typeof(PrivateMessageMeta
  ))]
    public partial class PrivateMessageObject : DatabaseEntity, IDatabaseEntity
    {
    public PrivateMessageObject()
    {
      ObjectType = "privatemessage";
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
    
      public System.Int64? Owner_User_ID { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? PublicationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Boolean IsEmailSent { get; set; }
    
      public System.String EmailType { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.String AUTO_Subject { get; set; }
    
      public System.String AUTO_Text { get; set; }
    
      public System.Int64 REL_SenderUserId { get; set; }
    
      public System.Int64 REL_ReceiverUserId { get; set; }
    
      public System.Int64? REL_Adjoined { get; set; }
    
      public System.Int32 AUTO_Item_Count { get; set; }
    

    public class Converter : IConvertibleFactory<PrivateMessage, PrivateMessageObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<PrivateMessage, PrivateMessageObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<PrivateMessage, PrivateMessageObject>> GetConverter()
    {
    return (db) => new PrivateMessageObject()
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
    AUTO_Subject = db.AUTO_Subject,
    AUTO_Text = db.AUTO_Text,
    REL_SenderUserId = db.REL_SenderUserId,
    REL_ReceiverUserId = db.REL_ReceiverUserId,
    REL_Adjoined = db.REL_Adjoined,
    AUTO_Item_Count = db.AUTO_Item_Count,
    

    };
    }

    public Action<PrivateMessageObject, PrivateMessage> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "privatemessage"; }
      
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
      
        target.AUTO_Subject = param.AUTO_Subject;
      
        target.AUTO_Text = param.AUTO_Text;
      
        target.REL_SenderUserId = param.REL_SenderUserId;
      
        target.REL_ReceiverUserId = param.REL_ReceiverUserId;
      
        target.REL_Adjoined = param.REL_Adjoined;
      
        target.AUTO_Item_Count = param.AUTO_Item_Count;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<PrivateMessage, PrivateMessageObject> CONVERT;
    public static Action<PrivateMessageObject, PrivateMessage> MODEL_CONVERT;

    }
    }
    }
  