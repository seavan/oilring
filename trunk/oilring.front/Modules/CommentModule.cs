using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using admin.web.common;
using System.Web;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class CommentModule : OilringModule<CommentController, CommentObject, CommentModule>
    {
        public CommentModule()
        {
            Ajax = true;
            Relation = "CommentObject_ManyToOne";
            ParentID = 0;
        }

        public CommentModule(IDatabaseEntity _related)
            : base(_related)
        {
            Ajax = true;
            Relation = "CommentObject_ManyToOne";
            ParentID = 0;
        }

        public override CommentModule ListWidget(System.Web.Mvc.HtmlHelper _helper)
        {
            var oue = _helper.ViewData.Model as IUserEnhancable;
            if (oue != null)
            {
                _helper.LastVisitHook(oue);
            }
            _helper.ViewContext.Writer.WriteLine("<a name='comments' style='visibility: hidden'>comment list anchor</a>");

            return base.ListWidget(_helper);
        }

        public override CommentModule AddWidget(System.Web.Mvc.HtmlHelper _helper)
        {
            _helper.ViewContext.Writer.WriteLine("<a name='commentAdd' style='visibility: hidden'>comment add anchor</a>");
            return base.AddWidget(_helper);
        }
    }
}