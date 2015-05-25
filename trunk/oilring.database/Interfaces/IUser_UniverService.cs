	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Univer
	File name: 	IUser_UniverService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IUser_UniverService : IDataService<User_UniverObject>
    {
        IEnumerable<string> GetAllUnivers(string searchString);
        IEnumerable<string> GetAllFaculties(string searchString);
        IEnumerable<string> GetAllDepartments(string searchString);
        IEnumerable<string> GetAllGroups(string searchString);
    }
}	
