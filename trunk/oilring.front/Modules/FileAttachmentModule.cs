using admin.db;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class FileAttachmentModule : OilringModule<FileAttachmentController, FileAttachmentObject, FileAttachmentModule>
    {
        public FileAttachmentModule()
        {
            Ajax = true;
            Relation = "FileAttachmentObject_ManyToOne";
        }

        public FileAttachmentModule(IDatabaseEntity _related)
            : base(_related)
        {
            Ajax = true;
            Relation = "FileAttachmentObject_ManyToOne";
        }

    }
}