using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public class I18N
    {
        public I18N()
        {
            Add(new RuLocale());
            Add(new EnLocale());
        }

        public ILocale this[int _id]
        {
            get { return m_IdLocales[_id];  }
        }

        public ILocale this[string _id]
        {
            get { return m_CodeLocales[_id]; }
        }

        protected void Add(ILocale _locale)
        {
            m_IdLocales[_locale.LANG_ID] = _locale;
            m_CodeLocales[_locale.LANG_CODE] = _locale;
        }

        public ILocale[] GetLocales()
        {
            return m_IdLocales.Values.ToArray();
        }

        private SortedList<int, ILocale> m_IdLocales = new SortedList<int, ILocale>();
        private SortedList<string, ILocale> m_CodeLocales = new SortedList<string, ILocale>();

        public static I18N D = new I18N();

        public static ILocale C { get { return D[0]; } }
    }
}