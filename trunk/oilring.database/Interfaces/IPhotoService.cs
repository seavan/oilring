	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Photo
	File name: 	IPhotoService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.IO;
using Database.Interfaces;
using Common.ContentProcessing;

namespace admin.db
{
    public partial interface IPhotoService : IDataService<PhotoObject>
    {
        void ImportPhoto(IImageProcessor _processor, System.IO.Stream _photo, string _originalFileName,
                                string _title, bool _inText, long _ownerUserId, long _relObject, string _relObjectType);

        void SetTargetDirectories(string[] _directories);
    }
}	
