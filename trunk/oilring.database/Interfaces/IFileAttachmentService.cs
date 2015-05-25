	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	FileAttachment
	File name: 	IFileAttachmentService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;
using Common.ContentProcessing;

namespace admin.db
{
    public partial interface IFileAttachmentService : IDataService<FileAttachmentObject>
    {
        FileAttachmentObject UploadFile(IFileProcessor _processor, System.IO.Stream _file, string _originalFileName,
                        string _title, long _ownerUserId, long _relObjectId, string _relObjectType);
        void SetTargetDirectories(string[] _directories);
        string GetFileRealPath(FileAttachmentObject obj);
    }
}	
