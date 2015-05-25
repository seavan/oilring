using System.Web.Mvc;

namespace System
{
    public class M2MRelation : CustomTagControl<M2MRelation>, IControl
    {
        public string Relation { get; set; }

        public M2MRelation(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public override void OpenTag()
        {
            Writer.WriteLine("<div class='{0}'>", Relation);
        }

        public override void CloseTag()
        {
            Writer.WriteLine("</div>");
        }
    }
}