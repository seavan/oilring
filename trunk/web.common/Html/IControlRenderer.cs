using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Database.Entities;

namespace Web.Common.Html
{
    public interface IControlRenderer
    {
        string ActionUri(HtmlHelper _html, string _controller, string _action);

        string ActionUri(HtmlHelper _html, string _controller, string _action, long _id);

        long CurrentUserId(HtmlHelper _html);

        string SingleUserAction<_T>(HtmlHelper _html, IIdentifiedTyped _param, string _action) 
            where _T : IDatabaseEntity;

        string SingleAction<_T>(string _action) where _T : IDatabaseEntity;

        string SingleAction<_T>(string _action, _T _item) where _T : IDatabaseEntity;

        string SingleUserAction<_T>(HtmlHelper _html, IDatabaseEntity _param, string _action)
            where _T : IDatabaseEntity;

        string SingleUri<_T>(_T _object, string _anchor = "") where _T : IDatabaseEntity;

        string SingleUri(HtmlHelper _html, IDatabaseEntity _object, string _anchor = "");

        string SingleUri<_T>(HtmlHelper _html, _T _object, string _anchor = "") where _T : IDatabaseEntity;

        string EditUri<_T>(HtmlHelper _html, _T _object, string _anchor = "") where _T : IDatabaseEntity;

        string Chapter(HtmlHelper _html, Type _t, long? page = null);
    }
}
