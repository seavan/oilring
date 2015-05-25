	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Rubric
	File name: 	IRubricService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IRubricService : IDataService<RubricObject>
    {
        List<RubricObject> GetAllRubrics();
        IEnumerable<RubricObject> GetSelectedRubrics(IEnumerable<long> IDs);
        IEnumerable<RubricObject> GetSelectedRubrics(UserObject user);
        void SetUserRubrics(IEnumerable<long> RubricIds, UserObject user);
        //IEnumerable<RubricObject> GetRubrics();
        //List<RubricObject> GetTreeSelectedRubrics();
    }
}	
