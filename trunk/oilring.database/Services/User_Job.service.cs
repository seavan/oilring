	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Job
	File name: 	User_Job.service.cs
*/
		

  using System;
  using System.Linq;
  using System.Data.Linq;
  using System.ComponentModel.DataAnnotations;
  using Notamedia.Oilring.Database;
  using System.Collections.Generic;
  using Notamedia.Oilring.Database.DataAccess;
using Database.Implementation;
using Database.Entities;
  namespace admin.db
  {
  public partial class User_JobService : DataService<User_Job, User_JobObject, User_JobObject.Converter>, IUser_JobService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<User_Job>().Single( obj => obj.Id.Equals(_id) );
        
            if( thisObj.User != null )
              {
                //var convUser = UserObject.Converter.FULL_CONVERT;
                //res.Add(convUser(thisObj.User));

                res.Add(thisObj.User);
            }

          
        return res;
      }
    }
}	
