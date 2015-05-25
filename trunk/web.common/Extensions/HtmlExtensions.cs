using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Common.IoC;
using Web.Common.Html;
using Database.Entities;
using Web.Common.Models;
using System.Linq.Expressions;
using System.Web.Routing;

namespace Web.Common.Extensions
{
    public static class HtmlExtensions
    {
        public static void SetValidation(this ViewDataDictionary _viewData, MessageStacker _stacker)
        {
            _viewData["_Validation"] = _stacker;
        }

        public static MessageStacker GetValidation(this ViewDataDictionary _viewData, MessageStacker _stacker)
        {
            var res = _viewData["_Validation"] as MessageStacker;
            if (res == null) _viewData.SetValidation(new MessageStacker());
            res = _viewData["_Validation"] as MessageStacker;
            return res;
        }

        public static string ActionUri(this HtmlHelper _html, string _controller, string _action)
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().ActionUri(_html, _controller, _action);
        }

        public static string ActionUri(this HtmlHelper _html, string _controller, string _action, long _id)
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().ActionUri(_html, _controller, _action, _id);
        }

        public static string Ellipsis(this string _value, int _count)
        {
            if (_value == null) return null;
            if (_value.Length < _count) return _value;
            var val = _value.Substring(0, Math.Min(_value.Length, _count));
            // try to find space symbol
            for (int i = val.Length - 1; i > 0; --i)
            {
                if (val[i].Equals(' '))
                {
                    return val.Substring(0, i) + "...";
                }
            }

            return val + "...";
        }

        public static long CurrentUserId(this HtmlHelper _html)
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().CurrentUserId(_html);
        }

        public static long ToJSCode(this DateTime _date)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = _date;
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return (long)ts.TotalMilliseconds;
        }

        public static DateTime FromJSCode(this long _date)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            return d1.AddMilliseconds(_date);
        }

        public static void SingleUri<_T>(this HtmlHelper _html, _T _object, string _Text, string _anchor = "") where _T : IDatabaseEntity
        {
            _html.ViewContext.Writer.WriteLine("<a href='{0}'>{1}</a>", _html.SingleUri(_object, _anchor), _Text);
        }

        public static void EditLink<_T>(this HtmlHelper _html, _T _object, string _Text, string _anchor = "") where _T : IDatabaseEntity
        {
            _html.ViewContext.Writer.WriteLine("<a href='{0}'>{1}</a>", _html.EditUri(_object, _anchor), _Text);
        }

        public static string SingleUserAction<_T>(this HtmlHelper _html, IIdentifiedTyped
                                                  _param, string _action) where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleUserAction<_T>(_html, _param, _action);
        }

        public static string SingleAction<_T>(string _action) where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleAction<_T>(_action);
        }

        public static string SingleAction<_T>(string _action, _T _item) where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleAction<_T>(_action, _item);
        }

        public static string SingleUserAction<_T>(this HtmlHelper _html, IDatabaseEntity _param, string _action) 
            where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleUserAction<_T>(_html, _param, _action);
        }

        public static string SingleUri<_T>(_T _object, string _anchor = "") where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleUri<_T>(_object, _anchor);
        }

        public static string SingleUri(this HtmlHelper _html, IDatabaseEntity _object, string _anchor = "")
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleUri(_html, _object, _anchor);
        }

        public static string SingleUri<_T>(this HtmlHelper _html, _T _object, string _anchor = "") where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().SingleUri<_T>(_html, _object, _anchor);
        }

        public static string EditUri<_T>(this HtmlHelper _html, _T _object, string _anchor = "") where _T : IDatabaseEntity
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().EditUri<_T>(_html, _object, _anchor);
        }

        public static string CommentUri<_T>(this HtmlHelper _html, _T _object) where _T : IDatabaseEntity
        {
            return _html.SingleUri(_object, "comments");
        }

        public static string Chapter<_T>(this HtmlHelper _html, long? page = null)
        {
            return _html.Chapter(typeof(_T), page);
        }

        public static string Chapter(this HtmlHelper _html, Type _t, long? page = null)
        {
            return MvcUnityContainer.Resolve<IControlRenderer>().Chapter(_html, _t, page);
        }

        public static MvcHtmlString PagerJSCircles(this HtmlHelper _html, PagerModel _model)
        {
            var countPages = _model.PageCount;
            var curPage = _model.CurrentPage;
            var MAX_PAGES = _model.MaxPages;
            var ROUND = _model.Round;
            if (countPages < 2) return null;

            var sb = new StringBuilder();
            sb.AppendFormat("<div class='slider {0}' rel='{1}' rev='{2}'>", "_moduleAction", "pager", _model.ModuleId);
            for (int i = 1; i <= countPages; ++i)
            {
                sb.AppendFormat("<span class='_page {0} {1}' rel='{2}' title='{2}'>&nbsp;</span>", i == curPage ? "cur" : "", "", i);
            }
            sb.AppendFormat("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString Pager(this HtmlHelper _html, PagerModel _model)
        {
            var countPages = _model.PageCount;
            var curPage = _model.CurrentPage;
            var MAX_PAGES = _model.MaxPages;
            var ROUND = _model.Round;
            var type = _model.ModelType;

            //Если страница одна, не рисуем
            if (countPages < 2) return null;

            TagBuilder container = new TagBuilder("ul");
            container.AddCssClass("pager _moduleAction");
            container.Attributes["rel"] = "pager";
            container.Attributes["rev"] = _model.ModuleId;

            StringBuilder innerContainterHtml = new StringBuilder();
            TagBuilder pages = new TagBuilder("li");
            pages.InnerHtml = "Страницы:";
            innerContainterHtml.Append(pages.ToString(TagRenderMode.Normal));

            //Всегда рисуем первую страницу
            TagBuilder page1 = new TagBuilder("li");
            page1.AddCssClass("_page");
            if (curPage == 1)
            {
                page1.AddCssClass("cur");
                page1.InnerHtml = curPage.ToString();
            }
            else
            {
                string url = _html.Chapter(type, 1);
                page1.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>", url, 1);
            }
            innerContainterHtml.Append(page1.ToString(TagRenderMode.Normal));


            long con = 0;
            long count = 0;

            //Высчитываем количество элементов в общем списке
            //Рисуем, если надо, пропуски в списке страниц
            if (countPages == MAX_PAGES)
            {
                con = 2;
                count = countPages - 1;
            }
            else if (curPage < MAX_PAGES)
            {
                con = 2;
                if ((curPage + ROUND) >= countPages || countPages == (MAX_PAGES - 1))
                {
                    count = countPages - 1;
                }
                else
                {
                    if (countPages >= (MAX_PAGES + 1))
                    {
                        count = MAX_PAGES; // curPage + ROUND;
                    }
                    else
                    {
                        count = curPage + ROUND;
                    }
                }
            }
            else if (curPage <= (countPages - (MAX_PAGES - 1)))
            {
                con = curPage - ROUND > 2 ? curPage - ROUND : 2;
                count = curPage + ROUND;
                if (curPage - ROUND > 2)
                    innerContainterHtml.Append("<li class=\"skip\"><div>...</div></li>");
            }
            else
            {
                if (curPage + (MAX_PAGES - 1) > countPages)
                {
                    con = countPages - (MAX_PAGES - 1);
                }
                //con = curPage - ROUND;
                count = countPages - 1;
                if (con > 2)
                    innerContainterHtml.Append("<li class=\"skip\"><div>...</div></li>");
            }

            //Рисуем основную часть списка
            long j = 0;
            for (j = con; j <= count; j++)
            {
                TagBuilder page = new TagBuilder("li");
                page.AddCssClass("_page");
                if (j == curPage)
                {
                    page.AddCssClass("cur");
                    page.InnerHtml = j.ToString();
                }
                else
                {
                    string url = _html.Chapter(type, j);
                    page.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>", url, j);
                }
                innerContainterHtml.Append(page.ToString(TagRenderMode.Normal));
            }

            //Если надо, рисуем пропуск в списке
            if ((curPage <= (countPages - (MAX_PAGES - 1)) || curPage + ROUND == countPages - 2) && (countPages != (MAX_PAGES - 1) && countPages != MAX_PAGES) && (count + 1 != countPages))
            {
                innerContainterHtml.Append("<li class=\"skip\"><div>...</div></li>");
            }


            //Всегда рисуем последнюю страницу
            TagBuilder pageLast = new TagBuilder("li");
            pageLast.AddCssClass("_page");
            if (curPage == countPages)
            {
                pageLast.AddCssClass("cur");
                pageLast.InnerHtml = countPages.ToString();
            }
            else
            {
                string url = _html.Chapter(type, countPages);
                pageLast.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>", url, countPages);
            }
            innerContainterHtml.Append(pageLast.ToString(TagRenderMode.Normal));

            //Выводим
            container.InnerHtml = innerContainterHtml.ToString();
            return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal));
        }



        /// <summary>
        /// label, привязаный к определенному элементу модели с возможностью задавать HTML-атрибуты
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_innerText"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression,
                                                                   object _htmlAttributes = null,
                                                                   string _innerText = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, _helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);

            string labelText = _innerText ?? metadata.DisplayName ?? metadata.PropertyName
                                          ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");
            tag.MergeAttributes(new RouteValueDictionary(_htmlAttributes));
            if (!tag.Attributes.ContainsKey("for"))
                tag.Attributes.Add("for", _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
        /// <summary>
        /// Получить идентификатор контрола, связанного с элементом модели
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <returns></returns>
        public static string IdFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);
            return _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
        }

        /// <summary>
        /// Контейнерный label, привязаный к определенному элементу модели с возможностью задавать HTML-атрибуты
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcContainer BeginLabelFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression,
                                                                   object _htmlAttributes = null,
                                                                   InsertAt _insertion = InsertAt.End,
                                                                   string _caption = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, _helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);

            string labelText = _caption ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            var tag = new TagBuilder("label");
            tag.MergeAttributes(new RouteValueDictionary(_htmlAttributes));

            tag.Attributes.Add("for", _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            _helper.ViewContext.HttpContext.Response.Write(tag.ToString(TagRenderMode.StartTag));
            return new MvcContainer(_helper.ViewContext.HttpContext.Response, "label", labelText, _insertion);
        }

    }
}
