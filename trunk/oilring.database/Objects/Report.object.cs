
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Report
    File name: 	Report.object.cs
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


    [MetadataTypeAttribute(typeof(ReportMeta
  ))]
    public partial class ReportObject : DatabaseEntity, IDatabaseEntity
    {
    public ReportObject()
    {
      ObjectType = "report";
      Title = "";
        CreationDate = DateTime.Now;
        StartDate = DateTime.Now;
        EndDate = DateTime.Now;
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 REL_Id { get; set; }
    
      public System.String REL_ObjectType { get; set; }
    
      public System.String Title { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.String Text { get; set; }
    
      public System.DateTime StartDate { get; set; }
    
      public System.DateTime EndDate { get; set; }
    

    public class Converter : IConvertibleFactory<Report, ReportObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Report, ReportObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Report, ReportObject>> GetConverter()
    {
    return (db) => new ReportObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    REL_Id = db.REL_Id,
    REL_ObjectType = db.REL_ObjectType,
    Title = db.Title,
    CreationDate = db.CreationDate,
    Text = db.Text,
    StartDate = db.StartDate,
    EndDate = db.EndDate,
    

    };
    }

    public Action<ReportObject, Report> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "report"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.REL_Id = param.REL_Id;
      
        target.REL_ObjectType = param.REL_ObjectType;
      
        target.Title = param.Title;
      
        target.CreationDate = param.CreationDate;
      
        target.Text = param.Text;
      
        target.StartDate = param.StartDate;
      
        target.EndDate = param.EndDate;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Report, ReportObject> CONVERT;
    public static Action<ReportObject, Report> MODEL_CONVERT;

    }
    }
    }
  