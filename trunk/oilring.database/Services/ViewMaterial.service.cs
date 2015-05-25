	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	ViewMaterial
	File name: 	ViewMaterial.service.cs
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
  public partial class ViewMaterialService : DataService<ViewMaterial, ViewMaterialObject, ViewMaterialObject.Converter>, IViewMaterialService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<ViewMaterial>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
