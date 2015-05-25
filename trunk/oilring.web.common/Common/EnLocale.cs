using System.Collections.Generic;
namespace System.Web
{
    public class EnLocale : ILocale
    {
        public EnLocale()
        {
            m_LangTitles["ru"] = "Russian";
            m_LangTitles["en"] = "English";
        }
        private SortedList<string, string> m_LangTitles = new SortedList<string, string>();
 
        public string LANG_CODE
        {
            get { return "en"; }
        }

        public string LANG_TITLE
        {
            get { return "English"; }
        }

        public int LANG_ID
        {
            get { return 1; }
        }

        public string GetLangTitle(string _code)
        {
            return m_LangTitles.IndexOfKey(_code) != -1 ? m_LangTitles[_code] : "";
        }


        #region ILocale Members


        public string ShortTitle
        {
            get { return "Eng"; }
        }

        #endregion

        #region ILocale Members


        public string Footer_Copyright
        {
            get { return "© 2011 Oil Ring All rights reserved"; }
        }

        public string Footer_Copyright_Developer
        {
            get { return "Design by Notamedia"; }
        }

        public string Command_Save
        {
            get { return "Save"; }
        }

        public string Command_Cancel
        {
            get { return "Cancel"; }
        }

        public string Command_Add
        {
            get { return "Add"; }
        }

        public string Command_Remove
        {
            get { return "Remove"; }
        }

        public string Search_Search
        {
            get { return "Search"; }
        }

        public string Search_All
        {
            get { return "search all materials"; }
        }

        public string Menu_Users
        {
            get { return "Users"; }
        }

        public string Menu_Content
        {
            get { return "Content"; }
        }

        public string Menu_Organizations
        {
            get { return "Organizations"; }
        }

        public string Menu_AboutProject
        {
            get { return "About"; }
        }

        public string Selector_EditTitle
        {
            get { return "Edit selection"; }
        }

        public string Selector_My
        {
            get { return "My selection"; }
        }

        public string Selector_Classification
        {
            get { return "VAK classification"; }
        }

        public string Selector_CanUseTags
        {
            get { return "You can use tags"; }
        }



        public string Entities_All
        {
            get { return "All"; }
        }

        public string Entities_Materials
        {
            get { return "Materials"; }
        }

        public string Entities_Seminars
        {
            get { return "Seminars"; }
        }

        public string Entities_Conferences
        {
            get { return "Conferences"; }
        }

        public string Entities_Discussions
        {
            get { return "Discussions"; }
        }

        public string Entities_Grants
        {
            get { return "Grants"; }
        }

        public string Entities_Journals
        {
            get { return "Journals"; }
        }

        public string Entities_Technologies
        {
            get { return "Technologies"; }
        }

        public string Entities_Events
        {
            get { return "News"; }
        }

        public string Entities_Materials_All
        {
            get { return "All materials"; }
        }

        public string Entities_Seminars_All
        {
            get { return "All seminars"; }
        }

        public string Entities_Conferences_All
        {
            get { return "All conferences"; }
        }

        public string Entities_Discussions_All
        {
            get { return "All discussions"; }
        }

        public string Entities_Grants_All
        {
            get { return "Все гранты"; }
        }

        public string Entities_Journals_All
        {
            get { return "All journals"; }
        }

        public string Entities_Technologies_All
        {
            get { return "All technologies"; }
        }

        public string Entities_Events_All
        {
            get { return "All news"; }
        }

        #endregion

        #region ILocale Members


        public string Selector_Field
        {
            get { return "Field"; }
        }

        public string Selector_Category
        {
            get { return "Category"; }
        }

        public string Selector_Clear
        {
            get { return "Clear my selection"; }
        }

        #endregion

        #region ILocale Members


        public string Entities_Materials_Last
        {
            get { return "Fresh materials"; }
        }

        public string Entities_Events_More
        {
            get { return "More news"; }
        }

        #endregion
    }
}