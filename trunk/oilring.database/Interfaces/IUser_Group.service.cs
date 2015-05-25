	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Group
	File name: 	IUser_GroupService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;

namespace admin.db
{
    public partial interface IUser_GroupService : IDataService<User_GroupObject>
    {
    }
}	
