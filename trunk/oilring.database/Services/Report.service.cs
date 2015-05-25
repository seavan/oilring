	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Report
	File name: 	Report.service.cs
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
  public partial class ReportService : DataService<Report, ReportObject, ReportObject.Converter>, IReportService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Report>().Single( obj => obj.Id.Equals(_id) );
        
            if( thisObj.Conference != null )
              {
                //var convConference = ConferenceObject.Converter.FULL_CONVERT;
                //res.Add(convConference(thisObj.Conference));

                res.Add(thisObj.Conference);
            }

          
            if( thisObj.Seminar != null )
              {
                //var convSeminar = SeminarObject.Converter.FULL_CONVERT;
                //res.Add(convSeminar(thisObj.Seminar));

                res.Add(thisObj.Seminar);
            }

          
        return res;
      }
    }
}	
