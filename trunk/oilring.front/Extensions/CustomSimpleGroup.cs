using System.Web.Mvc;

namespace System
{
    public class CustomSimpleGroup : CustomTagControl<CustomSimpleGroup>, IControl
    {
        public string Title { get; set; }
        public string DDClass { get; set; }

        public CustomSimpleGroup(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public override void OpenTag()
        {
            Writer.WriteLine("<dt>{0}</dt>", Title);
            Writer.WriteLine("<dd class='{0}' >", DDClass);
        }

        public override void CloseTag()
        {
            Writer.WriteLine("</dd>");
        }
    }
}