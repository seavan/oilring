	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Notification
	File name: 	Notification.service.cs
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
  public partial class NotificationService : OilringDataService<Notification, NotificationObject, NotificationObject.Converter>, INotificationService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Notification>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
