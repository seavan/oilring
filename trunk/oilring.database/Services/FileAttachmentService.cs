	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	FileAttachment
	File name: 	FileAttachment.service.cs
*/
		

using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Web;
using System.IO;
using Database.Implementation;
using Common.ContentProcessing;

namespace admin.db
{
    public partial class FileAttachmentService : DataService<FileAttachment, FileAttachmentObject, FileAttachmentObject.Converter>, IFileAttachmentService
    {
        public FileAttachmentObject UploadFile(IFileProcessor _processor, System.IO.Stream _file, string _originalFileName, string _title, long _ownerUserId, long _relObjectId, string _relObjectType)
        {
            var userPath = "";

            if (!String.IsNullOrEmpty(_relObjectType))
            {
                userPath = _relObjectType + "\\" + _relObjectId.ToString();
            }

            var guid = Guid.NewGuid();

            var fileObject = CreateItem();
            fileObject.ModificationDate = DateTime.Now;
            fileObject.CreationDate = DateTime.Now;
            fileObject.PublicationDate = DateTime.Now;
            fileObject.FileType = _processor.GetFileFormat();
            fileObject.Title = _title;

            long origSize;
            _processor.ProcessTo(_file, guid, m_Directories, userPath, out origSize);

            fileObject.OrigFileSize = origSize;
            fileObject.Published = true;

            fileObject.Approved = true;
            fileObject.Guid = guid;

            fileObject.UserFileName = _originalFileName;

            fileObject.REL_Id = _relObjectId;
            fileObject.REL_ObjectType = _relObjectType;

            fileObject.Owner_User_ID = _ownerUserId;

            fileObject.IsInText = false;

            if (fileObject.REL_Id > 0)
            {
                Insert(fileObject);
            }

            return fileObject;

        }

        public void SetTargetDirectories(string[] _directories)
        {
            m_Directories = _directories;
        }

        private string[] m_Directories = new string[] { };
       

        public string GetFileRealPath(FileAttachmentObject obj)
        {
            string _userPath = obj.REL_ObjectType + "\\" + obj.REL_Id.ToString();
            string DirName = string.Empty;

            foreach (var dir in m_Directories)
            {
                var tgDirName = Path.Combine(dir, _userPath);
                if (Directory.Exists(tgDirName))
                {
                    DirName = tgDirName;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(DirName))
            {
                var ext = new DefaultFileProcessor().GetFileFormat();
                var targetFName = String.Format("{0}.{1}", obj.Guid, ext);
                return Path.Combine(DirName, targetFName);
            }

            return null;
        }
    }
}	
