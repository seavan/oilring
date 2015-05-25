	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Grant
	File name: 	Grant.service.cs
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
      public partial class GrantService 
      {
            public GrantService()
            {
                RegisterManyToManyRelation<_ObjectAuthorLink>("GrantAuthorObject", null, true);
                RegisterManyToManyRelation<_TechnoGrantLink>("TechnoGrant");
            }

            public IEnumerable<GrantObject> GetAllGrants(string searchNumberString)
            {
                if (string.IsNullOrEmpty(searchNumberString)) return GetAll();

                return GetAll().Where(t => t.Number.ToString().StartsWith(searchNumberString));
            }
      }
  }	
