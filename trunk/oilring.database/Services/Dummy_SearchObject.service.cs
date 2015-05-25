	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Dummy_SearchObject
	File name: 	Dummy_SearchObject.service.cs
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
      public partial class Dummy_SearchObjectService : DataService<Dummy_SearchObject, Dummy_SearchObjectObject, Dummy_SearchObjectObject.Converter>, IDummy_SearchObjectService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Dummy_SearchObject>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
