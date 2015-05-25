
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization_Dept
    File name: 	Organization_Dept.object.cs
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


    [MetadataTypeAttribute(typeof(Organization_DeptMeta
  ))]
    public partial class Organization_DeptObject : DatabaseEntity, IDatabaseEntity
    {
    public Organization_DeptObject()
    {
      ObjectType = "organization_dept";
      Title = "";
        
    }



    
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.Int64 OrganizationId { get; set; }
    
      public System.String Title { get; set; }
    
      public System.Int64? Parent_OrganizationDept_ID { get; set; }
    

    public class Converter : IConvertibleFactory<Organization_Dept, Organization_DeptObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Organization_Dept, Organization_DeptObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Organization_Dept, Organization_DeptObject>> GetConverter()
    {
    return (db) => new Organization_DeptObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    OrganizationId = db.OrganizationId,
    Title = db.Title,
    Parent_OrganizationDept_ID = db.Parent_OrganizationDept_ID,
    

    };
    }

    public Action<Organization_DeptObject, Organization_Dept> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "organization_dept"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.OrganizationId = param.OrganizationId;
      
        target.Title = param.Title;
      
        target.Parent_OrganizationDept_ID = param.Parent_OrganizationDept_ID;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Organization_Dept, Organization_DeptObject> CONVERT;
    public static Action<Organization_DeptObject, Organization_Dept> MODEL_CONVERT;

    }
    }
    }
  