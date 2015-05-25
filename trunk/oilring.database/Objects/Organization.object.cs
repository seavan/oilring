
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Organization
    File name: 	Organization.object.cs
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


    [MetadataTypeAttribute(typeof(OrganizationMeta
  ))]
    public partial class OrganizationObject : DatabaseEntity, IDatabaseEntity
    {
    public OrganizationObject()
    {
      ObjectType = "organization";
      Address = "";
        Title = "";
        CreationDate = DateTime.Now;
        
    }



    
    [ScaffoldColumn(false)]
    public 
      IEnumerable<ContactObject>
     Contacts
     { get; set; }
  
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.String Title_RU_I18N { get; set; }
    
      public System.String Title_EN_I18N { get; set; }
    
      public System.Boolean IsApproved { get; set; }
    
      public System.String Logo { get; set; }
    
      public System.String Address { get; set; }
    
      public System.String Phone { get; set; }
    
      public System.String Email { get; set; }
    
      public System.String Website { get; set; }
    
      public System.String Title { get; set; }
    
      public System.String Description { get; set; }
    
      public System.DateTime CreationDate { get; set; }
    
      public System.DateTime? ModificationDate { get; set; }
    
      public System.Int32 AUTO_ScholarCount { get; set; }
    
      public System.Int32 AUTO_WorkerCount { get; set; }
    
      public System.String ShortDescription { get; set; }
    
      public System.String ImportCode { get; set; }
    

    public class Converter : IConvertibleFactory<Organization, OrganizationObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<Organization, OrganizationObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<Organization>( s => s.Contacts );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<Organization, OrganizationObject>> GetConverter()
    {
    return (db) => new OrganizationObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    Title_RU_I18N = db.Title_RU_I18N,
    Title_EN_I18N = db.Title_EN_I18N,
    IsApproved = db.IsApproved,
    Logo = db.Logo,
    Address = db.Address,
    Phone = db.Phone,
    Email = db.Email,
    Website = db.Website,
    Title = db.Title,
    Description = db.Description,
    CreationDate = db.CreationDate,
    ModificationDate = db.ModificationDate,
    AUTO_ScholarCount = db.AUTO_ScholarCount,
    AUTO_WorkerCount = db.AUTO_WorkerCount,
    ShortDescription = db.ShortDescription,
    ImportCode = db.ImportCode,
    

    };
    }

    public Action<OrganizationObject, Organization> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "organization"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.Title_RU_I18N = param.Title_RU_I18N;
      
        target.Title_EN_I18N = param.Title_EN_I18N;
      
        target.IsApproved = param.IsApproved;
      
        target.Logo = param.Logo;
      
        target.Address = param.Address;
      
        target.Phone = param.Phone;
      
        target.Email = param.Email;
      
        target.Website = param.Website;
      
        target.Title = param.Title;
      
        target.Description = param.Description;
      
        target.CreationDate = param.CreationDate;
      
        target.ModificationDate = param.ModificationDate;
      
        target.AUTO_ScholarCount = param.AUTO_ScholarCount;
      
        target.AUTO_WorkerCount = param.AUTO_WorkerCount;
      
        target.ShortDescription = param.ShortDescription;
      
        target.ImportCode = param.ImportCode;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<Organization, OrganizationObject> CONVERT;
    public static Action<OrganizationObject, Organization> MODEL_CONVERT;

    }
    }
    }
  