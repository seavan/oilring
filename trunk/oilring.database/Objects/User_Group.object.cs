
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Group
    File name: 	User_Group.object.cs
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


    [MetadataTypeAttribute(typeof(User_GroupMeta
  ))]
    public partial class User_GroupObject : DatabaseEntity, IDatabaseEntity
    {
    public User_GroupObject()
    {
      ObjectType = "user_group";
      Title = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Title { get; set; }
    
      public System.Int32 AUTO_User_Count { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    

    public class Converter : IConvertibleFactory<User_Group, User_GroupObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User_Group, User_GroupObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User_Group, User_GroupObject>> GetConverter()
    {
    return (db) => new User_GroupObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Lang = db.Lang,
    Title = db.Title,
    AUTO_User_Count = db.AUTO_User_Count,
    Published = db.Published,
    Approved = db.Approved,
    

    };
    }

    public Action<User_GroupObject, User_Group> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user_group"; }
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Lang = param.Lang;
      
        target.Title = param.Title;
      
        target.AUTO_User_Count = param.AUTO_User_Count;
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User_Group, User_GroupObject> CONVERT;
    public static Action<User_GroupObject, User_Group> MODEL_CONVERT;

    }
    }
    }
  