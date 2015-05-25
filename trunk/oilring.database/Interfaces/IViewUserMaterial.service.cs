	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	ViewUserMaterial
	File name: 	IViewUserMaterialService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IViewUserMaterialService : IDataService<ViewUserMaterialObject>
    {
    }
}	
