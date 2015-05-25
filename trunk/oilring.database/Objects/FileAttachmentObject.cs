
/*
Business Objects code generation
Author: Samvel Avanesov
Mailto: seavan@gmail.com
Table alias:	FileAttachment
File name: 	FileAttachment.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Configuration;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{

    public partial class FileAttachmentObject: IManyToOne 
    {
        public static string[] SIZES = new string[] { "á", "Êá", "Ìá", "Ãá" };

        public string PrettyFileSize
        {
            get 
            { 
                float sz = this.OrigFileSize;
                int step = 1024;
                int csize = 0;
                while( (sz > step) && (csize < SIZES.Length) )
                {
                    sz /= step;
                    csize++;
                }

                string res = String.Format("{0} {1}", sz.ToString( csize > 0 ? "F1" : "F0"), SIZES[csize]);
                return res;

            }
        }

        public string FullPath {
            get 
            { 
                var uploadDir = ConfigurationManager.AppSettings["filesLocalUploadPath"];

                return String.Format(@"{0}\{1}\{2}\{3}.{4}", uploadDir, REL_ObjectType, REL_Id, Guid.ToString(), "dat");
            }
        }
    }
}
