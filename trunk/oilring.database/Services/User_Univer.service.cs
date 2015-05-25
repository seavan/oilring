	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Univer
	File name: 	User_Univer.service.cs
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
  public partial class User_UniverService : DataService<User_Univer, User_UniverObject, User_UniverObject.Converter>, IUser_UniverService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<User_Univer>().Single( obj => obj.Id.Equals(_id) );
        
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
