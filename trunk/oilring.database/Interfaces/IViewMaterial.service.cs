	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	ViewMaterial
	File name: 	IViewMaterialService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IViewMaterialService : IDataService<ViewMaterialObject>
    {
    }
}	