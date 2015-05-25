	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Seminar
	File name: 	ISeminarService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface ISeminarService : IDataService<SeminarObject>
    {
        IEnumerable<SeminarObject> GetAllSeminars(string searchString);
        IEnumerable<SeminarObject> GetAllCycleSeminars(string searchString);
    }
}	
