
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Univer
    File name: 	User_Univer.object.cs
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


    [MetadataTypeAttribute(typeof(User_UniverMeta
  ))]
    public partial class User_UniverObject : DatabaseEntity, IDatabaseEntity
    {
    public User_UniverObject()
    {
      ObjectType = "user_univer";
      StartYear = DateTime.Now;
        Title = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.DateTime StartYear { get; set; }
    
      public System.DateTime? EndYear { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String Faculty { get; set; }
    
      public System.String Department { get; set; }
    
      public System.String Group { get; set; }
    
      public System.String Specialty { get; set; }
    
      public System.Boolean State { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    

    public class Converter : IConvertibleFactory<User_Univer, User_UniverObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User_Univer, User_UniverObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User_Univer, User_UniverObject>> GetConverter()
    {
    return (db) => new User_UniverObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    StartYear = db.StartYear,
    EndYear = db.EndYear,
    Title = db.Title,
    Faculty = db.Faculty,
    Department = db.Department,
    Group = db.Group,
    Specialty = db.Specialty,
    State = db.State,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    

    };
    }

    public Action<User_UniverObject, User_Univer> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user_univer"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.StartYear = param.StartYear;
      
        target.EndYear = param.EndYear;
      
        target.Title = param.Title;
      
        target.Faculty = param.Faculty;
      
        target.Department = param.Department;
      
        target.Group = param.Group;
      
        target.Specialty = param.Specialty;
      
        target.State = param.State;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User_Univer, User_UniverObject> CONVERT;
    public static Action<User_UniverObject, User_Univer> MODEL_CONVERT;

    }
    }
    }
  