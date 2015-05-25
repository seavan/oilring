
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_FriendRequest
    File name: 	User_FriendRequest.object.cs
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


    [MetadataTypeAttribute(typeof(User_FriendRequestMeta
  ))]
    public partial class User_FriendRequestObject : DatabaseEntity, IDatabaseEntity
    {
    public User_FriendRequestObject()
    {
      ObjectType = "user_friendrequest";
      
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 Target_User_ID { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    

    public class Converter : IConvertibleFactory<User_FriendRequest, User_FriendRequestObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User_FriendRequest, User_FriendRequestObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User_FriendRequest, User_FriendRequestObject>> GetConverter()
    {
    return (db) => new User_FriendRequestObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Target_User_ID = db.Target_User_ID,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    

    };
    }

    public Action<User_FriendRequestObject, User_FriendRequest> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user_friendrequest"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Target_User_ID = param.Target_User_ID;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User_FriendRequest, User_FriendRequestObject> CONVERT;
    public static Action<User_FriendRequestObject, User_FriendRequest> MODEL_CONVERT;

    }
    }
    }
  