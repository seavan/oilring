	
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
using System.Linq;
using Notamedia.Oilring.Database.DataAccess;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial interface IDummy_SearchObjectService : IDataService<Dummy_SearchObjectObject>
    {
        IQueryable<IDatabaseEntity> SearchByTagId(long _tagId);
        IQueryable<IDatabaseEntity> SearchByRubricId(long _rubricId);
    }
}	
