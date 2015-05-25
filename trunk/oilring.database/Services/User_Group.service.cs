	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Group
	File name: 	User_Group.service.cs
*/
		

  using System;
  using System.Linq;
  using System.Data.Linq;
  using System.ComponentModel.DataAnnotations;
  using Notamedia.Oilring.Database;
  using System.Collections.Generic;
  using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
  namespace admin.db
  {
  public partial class User_GroupService : OilringDataService<User_Group, User_GroupObject, User_GroupObject.Converter>, IUser_GroupService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<User_Group>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
