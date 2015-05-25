	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Tag
	File name: 	ITagService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using Database.Interfaces;

namespace admin.db
{
    public partial interface ITagService : IDataService<TagObject>
    {
        IEnumerable<TagObject> GetAllTags(string searchString);
        void SetTagUserSelection(IEnumerable<long> _ids);
        IEnumerable<TagObject> GetTagUserSelection();

    }
}	
