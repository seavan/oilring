	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	PrivateMessage
	File name: 	PrivateMessage.service.cs
*/
		

  using System;
  using System.Linq;
  using System.Data.Linq;
  using System.ComponentModel.DataAnnotations;
  using Notamedia.Oilring.Database;
  using System.Collections.Generic;
  using Notamedia.Oilring.Database.DataAccess;
  namespace admin.db
  {
  public partial class PrivateMessageService : DataService<PrivateMessage, PrivateMessageObject, PrivateMessageObject.Converter>, IPrivateMessageService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<PrivateMessage>().Single( obj => obj.Id.Equals(_id) );
        
        return res;
      }
    }
}	
