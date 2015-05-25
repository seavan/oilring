	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Degree
	File name: 	User_Degree.service.cs
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
  public partial class User_DegreeService : DataService<User_Degree, User_DegreeObject, User_DegreeObject.Converter>, IUser_DegreeService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<User_Degree>().Single( obj => obj.Id.Equals(_id) );
        
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
