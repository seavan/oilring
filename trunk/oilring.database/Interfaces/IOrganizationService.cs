	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Organization
	File name: 	IOrganizationService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IOrganizationService : IDataService<OrganizationObject>
    {
        IEnumerable<OrganizationObject> GetAllOrganizations(string searchString);
    }
}	
