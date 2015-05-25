	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Journal
	File name: 	IJournalService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IJournalService : IDataService<JournalObject>
    {
        IEnumerable<JournalObject> GetAllJournal(string searchString);
    }
}	
