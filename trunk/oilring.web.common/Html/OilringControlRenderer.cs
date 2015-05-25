using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Html;
using System.Web;
using admin.db;

namespace oilring.web.common.Html
{
    public class OilringControlRenderer : IControlRenderer
    {
        public string ActionUri(System.Web.Mvc.HtmlHelper _html, string _controller, string _action)
        {
            return string.Format("/{0}/{1}/{2}", _html.LC().LANG_CODE, _controller, _action);
        }

        public string ActionUri(System.Web.Mvc.HtmlHelper _html, string _controller, string _action, long _id)
        {
            return string.Format("/{0}/{1}/{2}/{3}", _html.LC().LANG_CODE, _controller, _action, _id);
        }


        public long CurrentUserId(System.Web.Mvc.HtmlHelper _html)
        {
            UserObject cu = null;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                cu = ((UserPrincipal)HttpContext.Current.User).CurrentUser;
                return cu.Id;
            }
            return 0;   
        }


        public string SingleUserAction<_T>(System.Web.Mvc.HtmlHelper _html, Database.Entities.IIdentifiedTyped _param, string _action) where _T : Database.Entities.IDatabaseEntity
        {
            return String.Format("/{0}/{1}/{2}?REL_Id1={3}&REL_ObjectType1={4}",
                                 _html.LC().LANG_CODE, typeof(_T).Name.Replace("Object", ""), _action, _param.Id, _param.ObjectType);

        }

        public string SingleAction<_T>(string _action) where _T : Database.Entities.IDatabaseEntity
        {
            return String.Format("/{0}/{1}/{2}",
                I18N.C.LANG_CODE, typeof(_T).Name.Replace("Object", ""), _action);
        }


        public string SingleAction<_T>(string _action, _T _item) where _T : Database.Entities.IDatabaseEntity
        {
            return String.Format("/{0}/{1}/{2}/{3}",
                I18N.C.LANG_CODE, typeof(_T).Name.Replace("Object", ""), _action, _item.Id);
        }


        public string SingleUserAction<_T>(System.Web.Mvc.HtmlHelper _html, Database.Entities.IDatabaseEntity _param, string _action) where _T : Database.Entities.IDatabaseEntity
        {
            return String.Format("/{0}/{1}/{2}?REL_Id1={3}&REL_ObjectType1={4}",
    _html.LC().LANG_CODE, typeof(_T).Name.Replace("Object", ""), _action, _param.Id, _param.ObjectType);
        }


        public string SingleUri<_T>(_T _object, string _anchor = "") where _T : Database.Entities.IDatabaseEntity
        {
            return "/" + I18N.C.LANG_CODE + "/" + _object.GetType().Name.Replace("Object", "") + "/Single/" + _object.Id.ToString() + (!String.IsNullOrEmpty(_anchor) ? "#" + _anchor : "");
        }


        public string SingleUri(System.Web.Mvc.HtmlHelper _html, Database.Entities.IDatabaseEntity _object, string _anchor = "")
        {
            return "/" + _html.LC().LANG_CODE + "/" + _object.GetType().Name.Replace("Object", "") + "/Single/" + _object.Id.ToString() + (!String.IsNullOrEmpty(_anchor) ? "#" + _anchor : "");
        }


        public string SingleUri<_T>(System.Web.Mvc.HtmlHelper _html, _T _object, string _anchor = "") where _T : Database.Entities.IDatabaseEntity
        {
            return "/" + _html.LC().LANG_CODE + "/" + _object.GetType().Name.Replace("Object", "") + "/Single/" + _object.Id.ToString() + (!String.IsNullOrEmpty(_anchor) ? "#" + _anchor : "");
        }


        public string EditUri<_T>(System.Web.Mvc.HtmlHelper _html, _T _object, string _anchor = "") where _T : Database.Entities.IDatabaseEntity
        {
            return "/" + _html.LC().LANG_CODE + "/" + _object.GetType().Name.Replace("Object", "") + "/Edit/" + _object.Id.ToString() + (!String.IsNullOrEmpty(_anchor) ? "#" + _anchor : "");
        }


        public string Chapter(System.Web.Mvc.HtmlHelper _html, Type _t, long? page = null)
        {
            return "/" + _html.LC().LANG_CODE + "/" + _t.Name.Replace("Object", "") + "/List" + (page.HasValue ? "/" + page.Value : "");
        }
    }
}
