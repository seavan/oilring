	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Dummy_SearchObject
	File name: 	IDummy_SearchObjectService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IDummy_SearchObjectService : IDataService<Dummy_SearchObjectObject>
    {
    }
}	
