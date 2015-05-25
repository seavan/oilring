using System.Web.Mvc;

namespace System
{
    public class CustomGroup : CustomTagControl<CustomGroup>, IControl
    {
        public string Title { get; set; }
        public string DDClass { get; set; }

        private CustomForm m_Parent;

        public CustomGroup(HtmlHelper htmlHelper, CustomForm parent)
            : base(htmlHelper)
        {
            m_Parent = parent;
        }

        public override void OpenTag()
        {
            Writer.WriteLine("<dt>{0:d2}.&nbsp;<span>{1}</span></dt>", m_Parent.GroupIndex++, Title);
            //Writer.WriteLine("<dd class='{0}' style='display: block'>", DDClass);
            Writer.WriteLine("<dd class='{0}' >", DDClass);
        }

        public override void CloseTag()
        {
            Writer.WriteLine("</dd>");
        }
    }
}