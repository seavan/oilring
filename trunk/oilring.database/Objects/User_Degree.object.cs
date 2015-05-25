
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_Degree
    File name: 	User_Degree.object.cs
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


    [MetadataTypeAttribute(typeof(User_DegreeMeta
  ))]
    public partial class User_DegreeObject : DatabaseEntity, IDatabaseEntity
    {
    public User_DegreeObject()
    {
      ObjectType = "user_degree";
      Title = "";
        Specialty = "";
        IssueDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String Specialty { get; set; }
    
      public System.String IssuePlace { get; set; }
    
      public System.DateTime IssueDate { get; set; }
    
      public System.String WorkTitle { get; set; }
    
      public System.Int64? Article_ID { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    

    public class Converter : IConvertibleFactory<User_Degree, User_DegreeObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User_Degree, User_DegreeObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User_Degree, User_DegreeObject>> GetConverter()
    {
    return (db) => new User_DegreeObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Title = db.Title,
    Specialty = db.Specialty,
    IssuePlace = db.IssuePlace,
    IssueDate = db.IssueDate,
    WorkTitle = db.WorkTitle,
    Article_ID = db.Article_ID,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    

    };
    }

    public Action<User_DegreeObject, User_Degree> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user_degree"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Title = param.Title;
      
        target.Specialty = param.Specialty;
      
        target.IssuePlace = param.IssuePlace;
      
        target.IssueDate = param.IssueDate;
      
        target.WorkTitle = param.WorkTitle;
      
        target.Article_ID = param.Article_ID;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User_Degree, User_DegreeObject> CONVERT;
    public static Action<User_DegreeObject, User_Degree> MODEL_CONVERT;

    }
    }
    }
  