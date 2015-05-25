	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Contact
	File name: 	Contact.service.cs
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
  public partial class ContactService : DataService<Contact, ContactObject, ContactObject.Converter>, IContactService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Contact>().Single( obj => obj.Id.Equals(_id) );
        
            if( thisObj.Organization != null )
              {
                //var convOrganization = OrganizationObject.Converter.FULL_CONVERT;
                //res.Add(convOrganization(thisObj.Organization));

                res.Add(thisObj.Organization);
            }

          
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
