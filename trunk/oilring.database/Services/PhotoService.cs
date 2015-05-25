
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Photo
    File name: 	Photo.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Drawing;
using System.Web;
using Database.Implementation;
using Common.ContentProcessing;

namespace admin.db
{
    public partial class PhotoService : DataService<Photo, PhotoObject, PhotoObject.Converter>, IPhotoService
    {
        public void ImportPhoto(IImageProcessor _processor, System.IO.Stream _photo, string _originalFileName, string _title, bool _inText, long _ownerUserId, long _relObject, string _relObjectType)
        {
            var userPath = "";

            if (!String.IsNullOrEmpty(_relObjectType))
            {
                userPath = _relObjectType + "\\" + _relObject.ToString();
            }

            var guid = Guid.NewGuid();

            var photoObject = CreateItem();
            photoObject.ModificationDate = DateTime.Now;
            photoObject.CreationDate = DateTime.Now;
            photoObject.PublicationDate = DateTime.Now;
            photoObject.ImageFormat = _processor.GetImageFormat();
            photoObject.Title = _title;

            Size origSize, resultSize, thumbSize;

            _processor.ProcessTo(_photo, guid, m_Directories, userPath, out origSize, out resultSize, out thumbSize);

            photoObject.OrigHeight = origSize.Height;
            photoObject.OrigWidth = origSize.Width;
            photoObject.ThumbHeight = thumbSize.Height;
            photoObject.ThumbWidth = thumbSize.Width;
            photoObject.Width = resultSize.Width;
            photoObject.Height = resultSize.Height;

            photoObject.Approved = true;
            photoObject.Guid = guid;

            photoObject.UserFileName = _originalFileName;

            photoObject.REL_Id = _relObject;
            photoObject.REL_ObjectType = _relObjectType;

            photoObject.Owner_User_ID = _ownerUserId;

            photoObject.IsInText = _inText;

            if (photoObject.REL_Id > 0)
            {
                Insert(photoObject);
            }
        }

        public void SetTargetDirectories(string[] _directories)
        {
            m_Directories = _directories;
        }

        private string[] m_Directories = new string[] { };
    }
}
