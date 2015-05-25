namespace System.Web
{
    public interface ILocale
    {
        int LANG_ID { get; }
        string LANG_CODE { get; }
        string ShortTitle { get; }

        string Footer_Copyright { get; }
        string Footer_Copyright_Developer { get; }

        string Command_Save { get; }
        string Command_Cancel { get; }
        string Command_Add { get; }
        string Command_Remove { get; }

        string Search_Search { get; }
        string Search_All { get; }

        string Menu_Users { get; }
        string Menu_Content { get; }
        string Menu_Organizations { get; }
        string Menu_AboutProject { get; }

        string Selector_EditTitle { get; }
        string Selector_My { get; }
        string Selector_Classification { get; }
        string Selector_CanUseTags { get; }
        string Selector_Field { get; }
        string Selector_Category { get; }
        string Selector_Clear { get; }

        string Entities_All { get; }
        string Entities_Materials { get; }
        string Entities_Seminars { get; }
        string Entities_Conferences { get; }
        string Entities_Discussions { get; }
        string Entities_Grants { get; }
        string Entities_Journals { get; }
        string Entities_Technologies { get; }
        string Entities_Events { get; }

        string Entities_Materials_All { get; }
        string Entities_Materials_Last { get; }
        string Entities_Seminars_All { get; }
        string Entities_Conferences_All { get; }
        string Entities_Discussions_All { get; }
        string Entities_Grants_All { get; }
        string Entities_Journals_All { get; }
        string Entities_Technologies_All { get; }
        string Entities_Events_All { get; }
        string Entities_Events_More { get; }

        string GetLangTitle(string _code);
    }
}