
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User
    File name: 	User.object.cs
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


    [MetadataTypeAttribute(typeof(UserMeta
  ))]
    public partial class UserObject : DatabaseEntity, IDatabaseEntity
    {
    public UserObject()
    {
      ObjectType = "user";
      LastVisitDate = DateTime.Now;
        RegistrationDate = DateTime.Now;
        FirstName = "";
        LastName = "";
        UserLogin = "";
        Password = "";
        
    }



    
    [ScaffoldColumn(false)]
    public 
      IEnumerable<ContactObject>
     Contacts
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<FileAttachmentObject>
     FileAttachments
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<PhotoObject>
     Photos
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<User_DegreeObject>
     User_Degrees
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<User_FriendRequestObject>
     User_FriendRequests
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<User_JobObject>
     User_Jobs
     { get; set; }
  
    [ScaffoldColumn(false)]
    public 
      IEnumerable<User_UniverObject>
     User_Univers
     { get; set; }
  
        [Editable(false)]
      
      public System.Int64 Id { get; set; }
    
        [Editable(false)]
      
      public System.String ObjectType { get; set; }
    
      public System.Boolean Published { get; set; }
    
      public System.Boolean Approved { get; set; }
    
      public System.String Lang { get; set; }
    
      public System.DateTime LastVisitDate { get; set; }
    
      public System.DateTime RegistrationDate { get; set; }
    
      public System.Boolean IsOnline { get; set; }
    
      public System.String Photo { get; set; }
    
      public System.String FirstName { get; set; }
    
      public System.String LastName { get; set; }
    
      public System.DateTime? BirthDate { get; set; }
    
      public System.String City { get; set; }
    
      public System.String MiddleName { get; set; }
    
      public System.Guid? AUTO_DefaultPhoto_Guid { get; set; }
    
      public System.String AUTO_DefaultPhoto_Alt { get; set; }
    
      public System.String Specialty { get; set; }
    
      public System.String UserLogin { get; set; }
    
      public System.String Password { get; set; }
    
      public System.Guid? Activation_guid { get; set; }
    
      public System.Boolean Sex { get; set; }
    
      public System.Boolean Options_SubscribeNews { get; set; }
    
      public System.Boolean Options_SubscribePrivateMessages { get; set; }
    
      public System.Boolean Options_SubscribeNewComments { get; set; }
    
      public System.Boolean Options_SubscribeJoin { get; set; }
    
      public System.Boolean Options_SubscribeFriendRequest { get; set; }
    
      public System.Int32 Options_ShowAge { get; set; }
    
      public System.Int32 Options_ShowContacts { get; set; }
    
      public System.Int32 Options_ShowJobs { get; set; }
    
      public System.Int32 Options_ShowEducations { get; set; }
    
      public System.Int32 Options_ShowMiddleName { get; set; }
    
      public System.Int32 Options_ShowInterests { get; set; }
    
      public System.Guid? Recoverpass_guid { get; set; }
    
      public System.Boolean? IsAdmin { get; set; }
    
      public System.Boolean? UseSelectedRubrics { get; set; }
    
      public System.Int64? OneRubricSelection { get; set; }
    

    public class Converter : IConvertibleFactory<User, UserObject>
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory<User, UserObject> Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    
      dlo.LoadWith<User>( s => s.Contacts );
    
      dlo.LoadWith<User>( s => s.FileAttachments );
    
      dlo.LoadWith<User>( s => s.Photos );
    
      dlo.LoadWith<User>( s => s.User_Degrees );
    
      dlo.LoadWith<User>( s => s.User_FriendRequests );
    
      dlo.LoadWith<User>( s => s.User_Jobs );
    
      dlo.LoadWith<User>( s => s.User_Univers );
    
    return dlo;
    }


    public System.Linq.Expressions.Expression<Func<User, UserObject>> GetConverter()
    {
    return (db) => new UserObject()
    {
    Id = db.Id,
    ObjectType = db.ObjectType,
    Published = db.Published,
    Approved = db.Approved,
    Lang = db.Lang,
    LastVisitDate = db.LastVisitDate,
    RegistrationDate = db.RegistrationDate,
    IsOnline = db.IsOnline,
    Photo = db.Photo,
    FirstName = db.FirstName,
    LastName = db.LastName,
    BirthDate = db.BirthDate,
    City = db.City,
    MiddleName = db.MiddleName,
    AUTO_DefaultPhoto_Guid = db.AUTO_DefaultPhoto_Guid,
    AUTO_DefaultPhoto_Alt = db.AUTO_DefaultPhoto_Alt,
    Specialty = db.Specialty,
    UserLogin = db.UserLogin,
    Password = db.Password,
    Activation_guid = db.Activation_guid,
    Sex = db.Sex,
    Options_SubscribeNews = db.Options_SubscribeNews,
    Options_SubscribePrivateMessages = db.Options_SubscribePrivateMessages,
    Options_SubscribeNewComments = db.Options_SubscribeNewComments,
    Options_SubscribeJoin = db.Options_SubscribeJoin,
    Options_SubscribeFriendRequest = db.Options_SubscribeFriendRequest,
    Options_ShowAge = db.Options_ShowAge,
    Options_ShowContacts = db.Options_ShowContacts,
    Options_ShowJobs = db.Options_ShowJobs,
    Options_ShowEducations = db.Options_ShowEducations,
    Options_ShowMiddleName = db.Options_ShowMiddleName,
    Options_ShowInterests = db.Options_ShowInterests,
    Recoverpass_guid = db.Recoverpass_guid,
    IsAdmin = db.IsAdmin,
    UseSelectedRubrics = db.UseSelectedRubrics,
    OneRubricSelection = db.OneRubricSelection,
    

    };
    }

    public Action<UserObject, User> GetModelConverter()
    {
    return (param, target) =>
    {
    
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.ObjectType = "user"; }
      
        target.Published = param.Published;
      
        target.Approved = param.Approved;
      
        target.Lang = param.Lang;
      
        target.LastVisitDate = param.LastVisitDate;
      
        target.RegistrationDate = param.RegistrationDate;
      
        target.IsOnline = param.IsOnline;
      
        target.Photo = param.Photo;
      
        target.FirstName = param.FirstName;
      
        target.LastName = param.LastName;
      
        target.BirthDate = param.BirthDate;
      
        target.City = param.City;
      
        target.MiddleName = param.MiddleName;
      
        target.AUTO_DefaultPhoto_Guid = param.AUTO_DefaultPhoto_Guid;
      
        target.AUTO_DefaultPhoto_Alt = param.AUTO_DefaultPhoto_Alt;
      
        target.Specialty = param.Specialty;
      
        target.UserLogin = param.UserLogin;
      
        target.Password = param.Password;
      
        target.Activation_guid = param.Activation_guid;
      
        target.Sex = param.Sex;
      
        target.Options_SubscribeNews = param.Options_SubscribeNews;
      
        target.Options_SubscribePrivateMessages = param.Options_SubscribePrivateMessages;
      
        target.Options_SubscribeNewComments = param.Options_SubscribeNewComments;
      
        target.Options_SubscribeJoin = param.Options_SubscribeJoin;
      
        target.Options_SubscribeFriendRequest = param.Options_SubscribeFriendRequest;
      
        target.Options_ShowAge = param.Options_ShowAge;
      
        target.Options_ShowContacts = param.Options_ShowContacts;
      
        target.Options_ShowJobs = param.Options_ShowJobs;
      
        target.Options_ShowEducations = param.Options_ShowEducations;
      
        target.Options_ShowMiddleName = param.Options_ShowMiddleName;
      
        target.Options_ShowInterests = param.Options_ShowInterests;
      
        target.Recoverpass_guid = param.Recoverpass_guid;
      
        target.IsAdmin = param.IsAdmin;
      
        target.UseSelectedRubrics = param.UseSelectedRubrics;
      
        target.OneRubricSelection = param.OneRubricSelection;
      
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func<User, UserObject> CONVERT;
    public static Action<UserObject, User> MODEL_CONVERT;

    }
    }
    }
  