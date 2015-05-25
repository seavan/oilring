using System.Collections.Generic;
namespace System.Web
{
    public class RuLocale : ILocale
    {
        public RuLocale()
        {
            m_LangTitles["RU"] = "Русский";
            m_LangTitles["EN"] = "Английский";
        }

        private SortedList<string, string> m_LangTitles = new SortedList<string, string>();
 
        public string LANG_CODE
        {
            get { return "ru"; }
        }

        public string LANG_TITLE
        {
            get { return "Русский"; }
        }

        public int LANG_ID
        {
            get { return 0; }
        }


        public string GetLangTitle(string _code)
        {
            return m_LangTitles.IndexOfKey(_code) != -1 ? m_LangTitles[_code] : "";
        }


        #region ILocale Members


        public string ShortTitle
        {
            get { return "Рус"; }
        }

        #endregion

        #region ILocale Members


        public string Footer_Copyright
        {
            get { return "© 2011 Oil Ring Все права защищены"; }
        }

        public string Footer_Copyright_Developer
        {
            get { return "Сайт создан компанией Notamedia"; }
        }

        public string Command_Save
        {
            get { return "Сохранить"; }
        }

        public string Command_Cancel
        {
            get { return "Отмена"; }
        }

        public string Search_Search
        {
            get { return "Поиск"; }
        }

        public string Search_All
        {
            get { return "поиск по всем материалам"; }
        }

        public string Menu_Users
        {
            get { return "Пользователи"; }
        }

        public string Menu_Content
        {
            get { return "Контент"; }
        }

        public string Menu_Organizations
        {
            get { return "Организации"; }
        }

        public string Menu_AboutProject
        {
            get { return "О проекте"; }
        }

        public string Selector_EditTitle
        {
            get { return "Редактирование содержимого"; }
        }

        public string Selector_My
        {
            get { return "Моя подборка"; }
        }

        public string Selector_Classification
        {
            get { return "Классификация ВАК"; }
        }

        public string Selector_CanUseTags
        {
            get { return "Можно использовать теги"; }
        }

        public string Entities_All
        {
            get { return "Все"; }
        }

        public string Entities_Materials
        {
            get { return "Материалы"; }
        }

        public string Entities_Seminars
        {
            get { return "Семинары"; }
        }

        public string Entities_Conferences
        {
            get { return "Конференции"; }
        }

        public string Entities_Discussions
        {
            get { return "Дискуссии"; }
        }

        public string Entities_Grants
        {
            get { return "Гранты"; }
        }

        public string Entities_Journals
        {
            get { return "Журналы"; }
        }

        public string Entities_Technologies
        {
            get { return "Технологии"; }
        }

        public string Entities_Events
        {
            get { return "Новости"; }
        }

        public string Entities_Materials_All
        {
            get { return "Все материалы"; }
        }

        public string Entities_Seminars_All
        {
            get { return "Все семинары"; }
        }

        public string Entities_Conferences_All
        {
            get { return "Все конференции"; }
        }

        public string Entities_Discussions_All
        {
            get { return "Все дискуссии"; }
        }

        public string Entities_Grants_All
        {
            get { return "Все гранты"; }
        }

        public string Entities_Journals_All
        {
            get { return "Все журналы"; }
        }

        public string Entities_Technologies_All
        {
            get { return "Все технологии"; }
        }

        public string Entities_Events_All
        {
            get { return "Все события"; }
        }

        #endregion

        #region ILocale Members


        public string Command_Add
        {
            get { return "Добавить"; }
        }

        public string Command_Remove
        {
            get { return "Удалить"; }
        }

        public string Selector_Field
        {
            get { return "Область"; }
        }

        public string Selector_Category
        {
            get { return "Категории"; }
        }

        public string Selector_Clear
        {
            get { return "Очистить мою подборку"; }
        }

        #endregion

        #region ILocale Members


        public string Entities_Materials_Last
        {
            get { return "Последние материалы"; }
        }

        public string Entities_Events_More
        {
            get { return "Еще новости"; }
        }

        #endregion
    }
}