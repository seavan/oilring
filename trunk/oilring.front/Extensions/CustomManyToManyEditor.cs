using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace System
{
    public class CustomManyToManyEditor : CustomTagControl<CustomManyToManyEditor>, IControl
    {
        public string Wrap { get; set; }

        public CustomManyToManyEditor(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public override void OpenTag()
        {

        }

        public override void CloseTag()
        {
            Writer.WriteLine("</div>");
        }
    }
}