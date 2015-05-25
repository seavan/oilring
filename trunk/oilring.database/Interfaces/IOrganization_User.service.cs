	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Organization_User
	File name: 	IOrganization_UserService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IOrganization_UserService : IDataService<Organization_UserObject>
    {
    }
}	
