using System.Web.Mvc;

namespace System
{
    public class CustomWrap : CustomTagControl<CustomWrap>, IControl
    {
        public string Wrap { get; set; }

        public CustomWrap(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public override void OpenTag()
        {
            Writer.WriteLine("<div class='{0}'>", Wrap);
        }

        public override void CloseTag()
        {
            Writer.WriteLine("</div>");
        }
    }
}

   