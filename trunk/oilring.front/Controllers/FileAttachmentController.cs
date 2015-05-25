	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	FileAttachment
	File name: 	FileAttachment.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.ContentProcessing;

namespace Notamedia.Oilring
{
    public class FileAttachmentController : admin.web.common.FileAttachmentController
    {
        protected IFileAttachmentService m_FileAttachmentService;

        private IFileAttachmentService FileAttachmentService
        {
            get
            {
                if (m_FileAttachmentService == null)
                {
                    m_FileAttachmentService = GetService() as IFileAttachmentService;
                }

                return m_FileAttachmentService;
            }
        }

		[HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase ffileUploadField, long? Id, string ObjectType)
		{
            if (Request.IsAuthenticated)
            {
                
                if ((ObjectType == null) && (Id == null))
                {
                    var processor = new AvatarProcessor();
                    var id = ((UserPrincipal)User).CurrentUser.Id;
                    DataServiceLocator.PhotoService.ImportPhoto(processor,
                        ffileUploadField.InputStream,
                        ffileUploadField.FileName,
                        ffileUploadField.FileName, false, id, id, "user");
                    return Content("");
                }
                else
                {
                    var processor = new DefaultFileProcessor();
                    var file = FileAttachmentService.UploadFile(processor, ffileUploadField.InputStream,
                                                                ffileUploadField.FileName,
                                                                ffileUploadField.FileName,
                                                                ((UserPrincipal) User).CurrentUser.Id,
                                                                Id.HasValue ? Id.Value : 0, ObjectType);
                    return View("RelatedListWidgetForEdit", new List<FileAttachmentObject> { file });
                }
                
            }
            else return null;
		}

        [HttpPost]
        public string ConvertFiles(HttpPostedFileBase fileImportField, long? Id, string ObjectType)
        {
            if (Request.IsAuthenticated)
            {
                var processor = new DefaultFileProcessor();
                var file = FileAttachmentService.UploadFile(processor, fileImportField.InputStream,
                                                            fileImportField.FileName,
                                                            fileImportField.FileName,
                                                            ((UserPrincipal)User).CurrentUser.Id,
                                                            Id.HasValue ? Id.Value : 0, ObjectType);
                file.IsConversionRequired = true;
                FileAttachmentService.Update(file);
                return file.Id.ToString();
            }
            else return "no auth";
        }

        public string GetFileState(long id)
        {
            var file = Service.GetById(id);
            if( file.IsConversionRequired.HasValue && file.IsConversionRequired.Value)
            {
                return "queue";
            }
            else if( file.IsConversionInProgress.HasValue && file.IsConversionInProgress.Value)
            {
                return "converting";
            }
            else if (file.IsConverted.HasValue && file.IsConverted.Value)
            {
                return "converted";
            }
            else if (file.IsError.HasValue && file.IsError.Value)
            {
                Service.Delete(file);
                return "error";
            }

            return "unknown";
        }

        public string GetFileContents(long id)
        {
            var file = Service.GetById(id);

            return file.Content;
        }

        public ActionResult DownloadFile(long id)
        {
            var file = FileAttachmentService.GetById(id);
            return new FileAttachmentController.DownloadResult() { FileDownloadName = file.Title, VirtualPath = FileAttachmentService.GetFileRealPath(file)};
        }

        public static string _getMymeType(string name)
        {
            switch (name.Substring(name.LastIndexOf("."), name.Length - name.LastIndexOf(".")))
            {
                case ".zip":
                    return "application/zip";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".jpeg":
                case ".jpg":
                case ".jpe":
                    return "image/jpeg";
                case ".wrl":
                case ".vrml":
                    return "model/vrml";
                case ".html":
                case ".htm":
                    return "text/html";
                case ".asc":
                case ".txt":
                    return "text/plain";
                case ".doc":
                case ".docx":
                    return "application/msword";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".ppt":
                case ".pptx":
                    return "application/vnd.ms-powerpoint";
                case ".pdf":
                    return "application/pdf";
                case ".swf":
                    return "application/x-shockwave-flash";
                default:
                    return "";
            }
        }

        public class DownloadResult : ActionResult
        {
            public DownloadResult() { }

            public DownloadResult(string virtualPath)
            {
                this.VirtualPath = virtualPath;
            }
            public DownloadResult(HttpRequestBase request)
            {
                this._request = request;
            }

            public string VirtualPath { get; set; }

            public string FileDownloadName { get; set; }

            public string MimeType { get; set; }

            public HttpRequestBase _request;

            public override void ExecuteResult(ControllerContext context)
            {
                try
                {
                    if (String.IsNullOrEmpty(MimeType))
                    {
                        MimeType = FileAttachmentController._getMymeType(FileDownloadName);
                    }

                    context.HttpContext.Response.ContentType = MimeType;

                    if (!String.IsNullOrEmpty(FileDownloadName))
                    {
                        if (context.HttpContext.Request.UserAgent.Contains("MSIE"))
                        {
                            FileDownloadName = HttpUtility.UrlPathEncode(FileDownloadName);
                        }
                        else if (context.HttpContext.Request.UserAgent.Contains("Firefox"))
                        {
                            FileDownloadName = "\"" + FileDownloadName + "\"";
                        }
                        context.HttpContext.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + this.FileDownloadName);
                    }

                    context.HttpContext.Response.TransmitFile(this.VirtualPath);
                }
                catch
                {
                    throw new HttpException(404, "Not Found");
                }
            }
        }
    }
}	
