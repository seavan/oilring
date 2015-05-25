using System.IO;
using System.Web.Mvc;

namespace System
{
    public abstract class CustomTagControl<_T> : IDisposable, IControl where _T : class, IControl
    {
        private readonly HtmlHelper m_Helper;
        private readonly TextWriter m_Writer;

        public HtmlHelper Helper { get { return m_Helper; } }
        public TextWriter Writer { get { return m_Writer; } }

        public CustomTagControl(HtmlHelper _helper)
        {
            m_Helper = _helper;
            m_Writer = _helper.ViewContext.Writer;
        }

        public _T Open()
        {
            OpenTag();
            return this as _T;
        }

        public abstract void OpenTag();
        public abstract void CloseTag();



        #region IDisposable Members

        public void Dispose()
        {
            CloseTag();
        }

        #endregion
    }
}