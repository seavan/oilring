using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc.Html;
using Microsoft.Practices.Unity;
using Database.Entities;
using Common.IoC;
using Common;
using Web.Common.Controllers;
using Web.Common.Extensions;

namespace Web.Common.Modules
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T">Контроллер, связанный с сущностью предметной области</typeparam>
    /// <typeparam name="_M">Сущность предметной области</typeparam>
    /// <typeparam name="_F">Тип модуля-наследника</typeparam>
    public abstract class Module<_T, _M, _F>
        where _T : BaseUniversalController<_M>, new()
        where _M : class, IDatabaseEntity, new()
        where _F : class, new()
    {
        public bool Ajax { get; set; }
//        public bool NoModuleRender { get; set; }
        public bool Delayed { get; set; }

        /// <summary>
        /// Определяет поведение модуля на клиенте(?), устанавливая соответствующий css класс
        /// </summary>
        public string Behave { get; set; }

        public _F LinkRouteData()
        {
            var rel = Relation;
            ModuleParams.Merge(new ModuleParams(HttpContext.Current.Request.RequestContext.RouteData.Values));
            Relation = rel;
            return this as _F;

        }

        public Module(bool _preserveRouteData = false)
        {
            Ajax = false;
            ModuleParams = new ModuleParams();
            Relation = "";
            Page = 1;
            PageSize = 0;
            ViewName = "";
            UserFilter = 0;
            ModuleId = TickId();

            Init();
        }

        public Module(IDatabaseEntity _model, bool _preserveRouteData = false) : this(_preserveRouteData)
        {
            Ajax = false;
            REL_ObjectID = _model.Id;
            REL_ObjectType = _model.ObjectType;
        }

        protected abstract void Init();

        protected string ControllerName
        {
            get { return typeof(_T).Name.Replace("Controller", ""); }
            //get { return typeof(_T).FullName; }
        }

        private static string TickId()
        {
            return Guid.NewGuid().ToString();
        }

        public _F List(HtmlHelper _helper, string _action = "ListItems", string _overrideView = null, 
                       bool _noModuleReload = false, bool _noModuleRender = false)
        {
            var orig = ViewName;
            var vn = ViewName;
            if (String.IsNullOrEmpty(_overrideView) && String.IsNullOrEmpty(vn))
            {
                vn = _action;
            } 
            if (_overrideView != null)
            {
                vn = _overrideView;
            }
            ViewName = vn;

            var pars = ModuleParams.GetParams();

            if (!_noModuleRender)
            {
                _helper.ViewContext.Writer.Write(
                    "<!-- {0} --><div class='_module {0} {1} {2} {5}' rel='{0}' rev='{3}' view='{4}'>", ModuleId, Behave,
                    Delayed ? "_delayed" : "", _helper.ActionUri(ControllerName, _action), vn, _noModuleReload ? "_noReload" : "");

                _helper.ViewContext.Writer.Write("<script>var p = new Object();");

                foreach (var par in pars)
                {
                    if( par.Value != null && !String.IsNullOrEmpty(par.Value.ToString()))
                    {
                        _helper.ViewContext.Writer.Write("p['{0}'] = '{1}';", par.Key, par.Value);
                    }
                }

                if (!Ajax)
                {
                    _helper.ViewContext.Writer.Write("p['DisablePreAjax'] = true;", ModuleId);
                }
                _helper.ViewContext.Writer.Write("MODULEPARAMS['{0}'] = p;</script>", ModuleId);
            }

            if (!Ajax)
            {
                _helper.RenderAction(_action, ControllerName, pars);
                
                HttpContext.Current.Response.ContentType = "text/html; charset=utf-8";
            }

            if (!_noModuleRender)
            {
                _helper.ViewContext.Writer.Write("</div>");
            }

            ViewName = orig;

            return this as _F;
        }

        public _F RelatedEditWidget(HtmlHelper _helper)
        {
            _helper.ViewContext.Writer.WriteLine("<div class='_relation' rel='{0}' rev='{1}'>", Relation, Mapper.INST.GetTypeCode<_M>());
            var f = List(_helper, "RelatedEditWidget");
            _helper.ViewContext.Writer.WriteLine("</div>");
            return f;
        }

        public _F Pager(HtmlHelper _helper, string _view = null)
        {
            return List(_helper, "Pager", _view);
        }

        public _F EntityTypeFilter(HtmlHelper _helper, string _view = "EntityTypeFilter")
        {
            return List(_helper, "EntityTypeFilter", _view);
        }

        public _F PagerJS(HtmlHelper _helper, string _view = null)
        {
            return List(_helper, "Pager", _view, true);
        }

        public _F GetListDateJS(HtmlHelper _helper, string _view = null)
        {
            return List(_helper, "GetListDateJS", _view);
            //return _helper.RenderAction("GetListDateJS", Controller);
        }

        public virtual _F AddWidget(HtmlHelper _helper)
        {
            return List(_helper, "AddWidget");
        }

        public virtual _F ListWidget(HtmlHelper _helper)
        {
            return List(_helper, "ListWidget");
        }

        public _F ListRandom(HtmlHelper _helper)
        {
            return List(_helper, "ListRandom");
        }

        public _F Single(HtmlHelper _helper)
        {
            return List(_helper, "Single");
        }

        public _F SingleWidget(HtmlHelper _helper, string _view = "SingleWidget")
        {
            return List(_helper, "SingleWidget", _view);
        }

        public _F SearchResult(HtmlHelper _helper)
        {
            return List(_helper, "SearchResult");
        }

        public _F Tab(HtmlHelper _helper, string _filter = null)
        {
            _helper.ViewContext.Writer.WriteLine("<div class='_tabItem' {0}>", Delayed ? "style='display: none' " : "");
            if (!String.IsNullOrEmpty(_filter))
            {
                _helper.ViewContext.Writer.WriteLine(_filter, ModuleId);
            }

            _helper.ViewContext.Writer.WriteLine("<ul class='materialList'>");
            var f = List(_helper);
            _helper.ViewContext.Writer.WriteLine("</ul>");
            _helper.ViewContext.Writer.WriteLine("<ul class='pager'>");
            f = Pager(_helper);
            _helper.ViewContext.Writer.WriteLine("</ul>");
            _helper.ViewContext.Writer.WriteLine("</div>");
            return f;
        }

        public long Id
        {
            get { return ModuleParams.Id; }
            set { ModuleParams.Id = value; }
        }

        public long PageSize
        {
            get { return ModuleParams.PageSize; }
            set { ModuleParams.PageSize = value; }
        }

        public long UserFilter
        {
            get { return ModuleParams.UserFilter; }
            set { ModuleParams.UserFilter = value; }
        }

        public string ModuleId
        {
            get { return ModuleParams.ModuleId; }
            private set { ModuleParams.ModuleId = value; }
        }

        public string Lang
        {
            get { return ModuleParams.Lang; }
            set { ModuleParams.Lang = value; }
        }

        public long REL_ObjectID
        {
            get { return ModuleParams.REL_ObjectID; }
            set { ModuleParams.REL_ObjectID = value; }
        }

        public string REL_ObjectType
        {
            get { return ModuleParams.REL_ObjectType; }
            set { ModuleParams.REL_ObjectType = value; }
        }

        public string REF_ObjectType
        {
            get { return ModuleParams.REF_ObjectType; }
            set { ModuleParams.REF_ObjectType = value; }
        }

        // нигде не используется
        //public string From
        //{
        //    get { return ModuleParams.From; }
        //    set { ModuleParams.From = value; }
        //}

        public string ViewName
        {
            get { return ModuleParams.ViewName; }
            set { ModuleParams.ViewName = value; }
        }

        public string Relation
        {
            get { return ModuleParams.Relation; }
            set { ModuleParams.Relation = value; }
        }

        public string FilterLetter
        {
            get { return ModuleParams.FilterLetter; }
            set { ModuleParams.FilterLetter = value; }
        }

        public long ParentID
        {
            get { return ModuleParams.ParentID; }
            set { ModuleParams.ParentID = value; }
        }

        public long Page
        {
            get { return ModuleParams.Page; }
            set { ModuleParams.Page = value; }
        }

        public long CurrentUserId
        {
            get { return ModuleParams.CurrentUserId; }
            set { ModuleParams.CurrentUserId = value; }
        }

        // нигде не используется
        //public long TemporaryUserFilter
        //{
        //    get { return ModuleParams.TemporaryUserFilter; }
        //    set { ModuleParams.TemporaryUserFilter = value; }
        //}

        // нигде не используется
        //public long IsUserFilterApplyable
        //{
        //    get { return ModuleParams.IsUserFilterApplyable; }
        //    set { ModuleParams.IsUserFilterApplyable = value; }
        //}

        public string SearchQueryString
        {
            get { return ModuleParams.SearchQueryString; }
            set { ModuleParams.SearchQueryString = value; }
        }

        public long ShowDrafts
        {
            get { return ModuleParams.ShowDrafts; }
            set { ModuleParams.ShowDrafts = value; }
        }

        public long OnlyDrafts
        {
            get { return ModuleParams.OnlyDrafts; }
            set { ModuleParams.OnlyDrafts = value; }
        }

        public long OnlyPublished
        {
            get { return ModuleParams.OnlyPublished; }
            set { ModuleParams.OnlyPublished = value; }
        }

        public _DT GetEnum<_DT>(string _name)
        {
            return ModuleParams.GetEnum<_DT>(_name);
        }

        public long GetInt(string _name)
        {
            return ModuleParams.GetInt(_name);
        }

        public string GetString(string _name)
        {
            return ModuleParams.GetString(_name);
        }

        public ModuleParams ModuleParams;
    }
}
