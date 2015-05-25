using System.Web.Mvc;
using System.Web.Mvc.Html;
using Notamedia.Oilring.Database.DataAccess;
using System.Web;
using Database.Entities;

namespace System
{
    public class CustomUserForm : CustomForm
    {
        private IDatabaseEntity m_Entity = null;
        public CustomUserForm(HtmlHelper _helper, IDatabaseEntity _entity) : base(_helper)
        {
            m_Entity = _entity;
        }

        public override void OpenTag()
        {
            if (!String.IsNullOrEmpty(Action)) Writer.WriteLine("<form method='post' enctype='multipart/form-data' action='/{2}/{0}/{1}'>", Helper.ViewContext.Controller.ControllerContext.RouteData.Values["controller"].ToString(), Action, Helper.LC().LANG_CODE);
            Writer.WriteLine("<div class='{0}'>", BlockClass);
            if (!String.IsNullOrEmpty(Title)) Writer.WriteLine("<h2>{0}</h2>", Title);
            
            
            Writer.WriteLine(Helper.Hidden("Id", m_Entity.Id));
            Writer.WriteLine(Helper.Hidden("ObjectType", m_Entity.ObjectType.Trim()));
            Writer.WriteLine(Helper.Hidden("_command", ""));
        }

        public override void CloseTag()
        {
            
            Writer.WriteLine("</div>");
            if (!String.IsNullOrEmpty(Action)) Writer.WriteLine("</form>");
        }
    }
}