
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Job
    File name: 	User_Job.object.cs
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


    [MetadataTypeAttribute(typeof(User_JobMeta
  ))]
    public partial class User_JobObject : DatabaseEntity, IDatabaseEntity
    {
    public User_JobObject()
    {
      ObjectType = "user_job";
      StartYear = DateTime.Now;
        Title = "";
        Position = "";
        
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
    
      public System.String Division1 { get; set; }
    
      public System.String Division2 { get; set; }
    
      public System.String Division3 { get; set; }
    
      public System.String Position { get; set; }
    
      public System.Boolean State { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    

    public class Converter : IConvertibleFactory<User_Job, User_JobObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User_Job, User_JobObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User_Job, User_JobObject>> GetConverter()
    {
    return (db) => new User_JobObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    StartYear = db.StartYear,
    EndYear = db.EndYear,
    Title = db.Title,
    Division1 = db.Division1,
    Division2 = db.Division2,
    Division3 = db.Division3,
    Position = db.Position,
    State = db.State,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    

    };
    }

    public Action<User_JobObject, User_Job> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user_job"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.StartYear = param.StartYear;
      
        target.EndYear = param.EndYear;
      
        target.Title = param.Title;
      
        target.Division1 = param.Division1;
      
        target.Division2 = param.Division2;
      
        target.Division3 = param.Division3;
      
        target.Position = param.Position;
      
        target.State = param.State;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User_Job, User_JobObject> CONVERT;
    public static Action<User_JobObject, User_Job> MODEL_CONVERT;

    }
    }
    }
  