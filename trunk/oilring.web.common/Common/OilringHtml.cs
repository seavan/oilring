using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using System.Web.Mvc;
using System.Text;
using Notamedia.Oilring;
using System.Reflection;
using System.Linq.Expressions;
using System.Web.Routing;
using Database.Entities;
using Web.Common;
using Web.Common.Models;
using Web.Common.Extensions;

namespace System.Web
{
    public static class OilringHtml
    {
        public static void LastVisitHook(this HtmlHelper _html, IUserEnhancable _item)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                _html.ViewContext.Writer.WriteLine("<span class='_lastVisit' style='display: none'>{0}</span>",
                                                   _item.PSEUDO_PreviousVisitDateTime.HasValue ?

                                                   _item.PSEUDO_PreviousVisitDateTime.Value.ToJSCode() : 0);
            }
        }

        public static string StaticFile(this HtmlHelper _html, string _url)
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
            return RES.STATIC_SERVER_URI + _url + (_url.Contains("?") ? "&" : "?") + "_v=" + v;
        }

        public static string StaticScriptFile(this HtmlHelper _html, string _url)
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
            return RES.SCRIPTS_SERVER_URI + _url + (_url.Contains("?") ? "&" : "?") + "_v=" + v;
        }

        public static string StaticLocaledFile(this HtmlHelper _html, string _url)
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            return "/" + _html.LC().LANG_CODE + _url + (_url.Contains("?") ? "&" : "?") + "_v=" + v;
        }

        public static string CreateDraft(this HtmlHelper _html, Type _t)
        {
            return "/" + _html.LC().LANG_CODE + "/" + _t.Name.Replace("Object", "") + "/CreateDraft";
        }

        public static string CreateDraft<_T>(this HtmlHelper _html)
        {
            return _html.CreateDraft(typeof(_T));
        }


    }
}