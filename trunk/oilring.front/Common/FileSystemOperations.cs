using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Notamedia.Oilring.Community.Common
{
    public static class FileSystemOperations
    {
        #region Static variable
        static private HttpContext Ctx = HttpContext.Current;
        public static string PATHDRAFTBILL 
        {
            get { return Ctx.Server.MapPath("~/Content/draftbilleditions/"); }
        }
        public static string PATHTEMP
        {
            get { return Ctx.Server.MapPath("~/Content/temp/"); }
        }
        public static string PATHPUBLICATION
        {
            get { return Ctx.Server.MapPath("~/Content/publication/"); }
        }
        public static string PATHLAWSUITACT
        {
            get { return Ctx.Server.MapPath("~/Content/lawsuitact/"); }
        }
        public static string PATHSTUDENTRECORDBOOK
        {
            get { return Ctx.Server.MapPath("~/Content/studentrecordbook/"); }
        }
        public static string PATHCUTAWAYS
        {
            get { return Ctx.Server.MapPath("~/Content/cutaways/"); }
        }
        public static string PATHENTRIES
        {
            get { return Ctx.Server.MapPath("~/Content/entriesattachments/"); }
        }
        #endregion

        private static void cleanUpTempFolder()
        {
            DirectoryInfo dirinfo = new DirectoryInfo(PATHTEMP);
            dirinfo.GetFiles().ToList().ForEach(s =>
            {
                if ((DateTime.Now - s.LastWriteTimeUtc) > new TimeSpan(12, 0, 0))
                {
                    s.Delete();
                }
            });
        }

        public static string UploadTempFile(HttpPostedFileBase _input)
        {
            cleanUpTempFolder();
            return _uploadFile(PATHTEMP, _input);            
        }     
   
        public static void DeleteFiles(string _path, IEnumerable<string> _files)
        {
            if (_files != null && !string.IsNullOrEmpty(_path))
            {
                foreach (var fname in _files)
                {
                    if(File.Exists(_path + fname))
                    {
                        File.Delete(_path + fname);
                    }
                }
            }
        }

        public static void MovieFileToConstantPath(string _path, string _tempfilename)
        {
            File.Move(PATHTEMP + _tempfilename, _path + _tempfilename);
        }

        public static string UploadPublication(HttpPostedFileBase _input)
        {
            if (_input != null)
            {
                return _uploadFile(PATHPUBLICATION, _input);                
            }

            return string.Empty;
        }

        public static void DeletePublication(string fileName)
        {
            if(!string.IsNullOrEmpty(fileName))
            {
                List<string> publ = new List<string>();
                publ.Add(fileName);
                DeleteFiles(PATHPUBLICATION, publ);
            }
        }

        public static string UploadLawsuitAct(HttpPostedFileBase _input)
        {
            if (_input != null)
            {
                return _uploadFile(PATHLAWSUITACT, _input);
            }

            return string.Empty;
        }

        public static string UploadCutaways(HttpPostedFileBase _input)
        {
            if (_input != null)
            {
                return _uploadFileWithExtension(PATHCUTAWAYS, _input);
            }

            return string.Empty;
        }

        public static string UploadStudentRecordbook(HttpPostedFileBase _input)
        {
            if (_input != null)
            {
                return _uploadFileWithExtension(PATHSTUDENTRECORDBOOK, _input);
            }

            return string.Empty;
        }

        public static string UploadEntriesAttachments(HttpPostedFileBase _input)
        {
            if (_input != null)
            {
                return _uploadFileWithExtension(PATHENTRIES, _input);
            }

            return string.Empty;
        }

        private static string _uploadFile(string _path, HttpPostedFileBase _input)
        {
            cleanUpTempFolder();
            var targetFName = Guid.NewGuid().ToString();
            FileStream stream = new FileStream(_path + targetFName, FileMode.Create);
            _input.InputStream.CopyTo(stream);
            stream.Close();
            return targetFName;
        }

        private static string _uploadFileWithExtension(string _path, HttpPostedFileBase _input)
        {
            cleanUpTempFolder();
            var expansion = _input.FileName.Remove(0, _input.FileName.LastIndexOf(".") + 1);
            var targetFName = Guid.NewGuid().ToString() + "." + expansion;
            FileStream stream = new FileStream(_path + targetFName, FileMode.Create);
            _input.InputStream.CopyTo(stream);
            stream.Close();
            return targetFName;
        }

        
    }
}