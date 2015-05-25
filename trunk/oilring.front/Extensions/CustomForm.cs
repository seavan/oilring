using System.Web.Mvc;
using System.Web;

namespace System
{
    public class CustomForm : CustomTagControl<CustomForm>, IControl
    {
        public string Title { get; set; }
        public string BlockClass { get; set; }
        public string ListClass { get; set; }
        public string Action { get; set; }
        public int GroupIndex { get; set; }
        public CustomForm(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
            GroupIndex = 1;
        }


        public override void OpenTag()
        {
            Writer.WriteLine("<form method='post' enctype='multipart/form-data' action='/{2}/{0}/{1}'>", Helper.ViewContext.Controller.ControllerContext.RouteData.Values["controller"].ToString(), Action, Helper.LC().LANG_CODE);
            if(!String.IsNullOrEmpty(Title)) Writer.WriteLine("<div class='{1}'><h1>{0}</h1>", Title, BlockClass);
            if(!String.IsNullOrEmpty(ListClass)) Writer.WriteLine("<dl class='{0}'>", ListClass);
        }

        public override void CloseTag()
        {
            if (!String.IsNullOrEmpty(ListClass)) Writer.WriteLine("</dl>");
            if(!String.IsNullOrEmpty(Title)) Writer.WriteLine("</div>");
            Writer.WriteLine("</form>");
        }
    }
}