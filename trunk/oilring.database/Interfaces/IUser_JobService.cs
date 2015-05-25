	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Job
	File name: 	IUser_JobService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IUser_JobService : IDataService<User_JobObject>
    {
        IEnumerable<string> GetAllJobs(string searchString);
    }
}	
