	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Event
	File name: 	Event.service.cs
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
  public partial class EventService : DataService<Event, EventObject, EventObject.Converter>, IEventService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Event>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
