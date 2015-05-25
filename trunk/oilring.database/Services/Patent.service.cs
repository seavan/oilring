	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Patent
	File name: 	Patent.service.cs
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
  public partial class PatentService : DataService<Patent, PatentObject, PatentObject.Converter>, IPatentService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Patent>().Single( obj => obj.Id.Equals(_id) );
        
            if( thisObj.Techno != null )
              {
                //var convTechno = TechnoObject.Converter.FULL_CONVERT;
                //res.Add(convTechno(thisObj.Techno));

                res.Add(thisObj.Techno);
            }

          
        return res;
      }
    }
}	
