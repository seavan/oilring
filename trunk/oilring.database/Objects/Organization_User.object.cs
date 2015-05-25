
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization_User
    File name: 	Organization_User.object.cs
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


    [MetadataTypeAttribute(typeof(Organization_UserMeta
  ))]
    public partial class Organization_UserObject : DatabaseEntity, IDatabaseEntity
    {
    public Organization_UserObject()
    {
      ObjectType = "organization_user";
      
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 Organization_ID { get; set; }
    
      public System.Int64 User_ID { get; set; }
    

    public class Converter : IConvertibleFactory<Organization_User, Organization_UserObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Organization_User, Organization_UserObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Organization_User, Organization_UserObject>> GetConverter()
    {
    return (db) => new Organization_UserObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Organization_ID = db.Organization_ID,
    User_ID = db.User_ID,
    

    };
    }

    public Action<Organization_UserObject, Organization_User> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "organization_user"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Organization_ID = param.Organization_ID;
      
        target.User_ID = param.User_ID;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Organization_User, Organization_UserObject> CONVERT;
    public static Action<Organization_UserObject, Organization_User> MODEL_CONVERT;

    }
    }
    }
  