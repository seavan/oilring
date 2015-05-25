using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using admin.db;
using Microsoft.Practices.Unity;
using Database.Entities;
using Common;
using Web.Common.Controllers;
using Web.Common.Modules;
using Web.Common.Filters;
using Database.Extensions;
using Web.Common.Extensions;

namespace admin.web.common
{
    public abstract class OilringBaseUniversalController<_T> : BaseUniversalController<_T>
         where _T : class, IDatabaseEntity, new()
    {
        public OilringBaseUniversalController() : base()
        {
            m_PreFilterList.RegisterSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_All",
                    (_params, _q) => { return Service.GetAllPre(); },
                    (_params) => { return true; },
                    (_params) => { return new object[] { }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Related",
                    (_params, _q) => { return Service.GetRelated(_params.Relation, _params.REL_ObjectID, _params.REL_ObjectType); },
                    (_params) => { return !String.IsNullOrEmpty(_params.Relation); },
                    (_params) => { return new object[] { _params.Relation, _params.REL_ObjectID, _params.REL_ObjectType }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter<_T, IDateRangeItem>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_FilterDate",
                    (_params, _q) =>
                    {
                        var dt = _params.GetCurrentDate().FromJSCode();
                        return _q.Cast<IDateRangeItem>().Where(s => (s.EventStartDate.Year.Equals(dt.Year) && s.EventStartDate.Month.Equals(dt.Month) && s.EventStartDate.Day.Equals(dt.Day))).Cast<IDatabaseEntity>();
                    },
                    (_params) =>
                    { return _params.GetCurrentDate() > 0; },
                    (_params) => { return new object[] { _params.GetCurrentDate() }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter<_T, IDateRangeItem>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_FilterDateMonth",
                    (_params, _q) =>
                    {
                        var dt = _params.GetCurrentDateForMonth().FromJSCode();
                        return _q.Cast<IDateRangeItem>().Where(s => (s.EventStartDate.Year.Equals(dt.Year) && s.EventStartDate.Month.Equals(dt.Month))).Cast<IDatabaseEntity>();
                    },
                    (_params) =>
                    { return _params.GetCurrentDateForMonth() > 0; },
                    (_params) => { return new object[] { _params.GetCurrentDateForMonth() }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter<_T, IRubricFilterable>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_ByRubricList",
                    (_params, _q) =>
                    {
                        var ids =
                            _params.GetUserRubricFilter().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).
                                Select(s => long.Parse(s)).ToArray();
                        var t = Service.FilterByRelated<Rubric>("Rubrics", ids, _q);
                        return t;
                    },
                    (_params) => { return (_params.UserFilter > 0) && !String.IsNullOrEmpty(_params.GetUserRubricFilter()); },
                    (_params) => { return new object[] { _params.UserFilter, _params.GetUserRubricFilter() }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter<_T, ITagFilterable>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_ByTagList",
                    (_params, _q) =>
                    {
                        var ids = _params.GetUserTagFilter().Split(';').Select(s => long.Parse(s)).ToArray();
                        var t = Service.FilterByRelated<Tag>("Tags", ids, _q);
                        return t;
                    },
                    (_params) => { return (_params.UserFilter > 0) && !String.IsNullOrEmpty(_params.GetUserTagFilter()); },
                    (_params) => { return new object[] { _params.UserFilter, _params.GetUserTagFilter() }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter<_T, ITagFilterable>(
                new BasicFilter<IDatabaseEntity>(
                "StatusFilter",
                (_params, q)
                =>
                {
                    switch ((StatusList)_params.GetUserStatusFilter())
                    {
                        case StatusList.Member:
                            q = Service.FilterByRelated<User>("ObjectUserVisitor", new long[] { _params.CurrentUserId }, q);
                            break;
                        case StatusList.Organizer:
                            q = Service.FilterByRelated<User>("ObjectUserVisitor", new long[] { _params.CurrentUserId }, q);
                            break;
                        case StatusList.Request:
                            q = Service.FilterByRelated<User>("ObjectJoinRequest", new long[] { _params.CurrentUserId }, q);
                            break;
                        case StatusList.AuthorReader:
                            q = Service.FilterByRelated<User>("ObjectAuthorReader", new long[] { _params.CurrentUserId }, q);
                            break;
                    }
                    return q;
                },
                (_params)
                =>
                {
                    return _params.GetUserStatusFilter() > 0;
                },
                (_params) =>
                {
                    return new object[] { _params.GetUserStatusFilter() };
                }));

            /*m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Behave",
                    (_params, _q) => { return Behaviour.Behave(_q); },
                    (_params) => { return true; },
                    (_params) => { return new object[] { "bhv" }; }
                    )
                ); */

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Drafts",
                    (_params, _q) =>
                    {
                        return _q.Where(s => (s.Approved && s.Published));
                    },
                    (_params) => { return (Behaviour.OnlyApproved || Behaviour.OnlyPublished) && (_params.ShowDrafts <= 0); },
                    (_params) => { return new object[] { _params.ShowDrafts }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_OnlyDrafts",
                    (_params, _q) =>
                    {
                        return _q.Where(s => (!s.Published));
                    },
                    (_params) => { return _params.OnlyDrafts > 0; },
                    (_params) => { return new object[] { _params.OnlyDrafts }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_OnlyPublished",
                    (_params, _q) =>
                    {
                        return _q.Where(s => (s.Published));
                    },
                    (_params) => { return _params.OnlyPublished > 0; },
                    (_params) => { return new object[] { _params.OnlyPublished }; }
                    )
                );


            m_PreFilterList.RegisterPreFilter<_T, IFavorable>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_UserFavourite",
                    (_params, _q) => { return Service.FilterByRelated<User>("UserFavourites", new[] { _params.CurrentUserId }, _q); },
                    (_params) => { return _params.GetUserFavouriteFilter() > 0; },
                    (_params) => { return new object[] { _params.GetUserFavouriteFilter(), _params.CurrentUserId }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Lang",
                    (_params, _q) => { return _q.Where(s => (s.Lang == null) || (s.Lang.Equals(_params.Lang))); },
                    (_params) => { return !String.IsNullOrEmpty(_params.Lang); },
                    (_params) => { return new object[] { _params.Lang }; }
                    )
                );


            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Single",
                    (_params, _q) =>
                    {
                        return _q.Where(s => s.Id.Equals(_params.Id));
                    },
                    (_params) => { return (_params.Action.Contains("Single")) && (_params.Id > 0); },
                    (_params) => { return new object[] { "Single", _params.Id }; }
                    )
                );
            m_PreFilterList.RegisterPreFilter
                <_T, ITitleable>(new ByLetterFilter<IDatabaseEntity>());

            m_PreFilterList.RegisterPostFilter(new OrderFilter<IDatabaseEntity>());

            m_PreFilterList.RegisterPostFilter(new PageFilter<IDatabaseEntity>());

            m_PreFilterList.RegisterPostSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Convert",
                    (_params, _q) => 
                    { 
                        return Service.Convert(_q).Cast<_T>().ToArray().AsQueryable(); 
                    },
                    (_params) => { return true; },
                    (_params) => { return new object[] { "cnv" }; }
                    )
                );

            m_PreFilterList.RegisterPostSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Enhance",
                    (_params, _q) =>
                    {
                        var otype = Mapper.INST.GetTypeCode<_T>();
                        var enhanced = DataServiceLocator.UserService.ApplyEnhancement(
                            _q.ToArray().Cast<IUserEnhancable>().AsQueryable(),
                            otype,
                            _params.CurrentUserId,
                            false
                            ).Cast<_T>();
                        _q = enhanced.ToArray().AsQueryable();
                        return _q;
                    },
                    (_params) =>
                    {
                        return typeof(IUserEnhancable).IsAssignableFrom(typeof(_T)) &&
                               _params.CurrentUserId > 0;
                    },
                    (_params) => { return new object[] { _params.CurrentUserId }; }
                    )
                );

            m_PreFilterList.RegisterPostSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_OwnerEnhance",
                    (_params, _q) =>
                    {
                        var enhanced = DataServiceLocator.UserService.ApplyOwnerUserEnhancement(
                            _q.ToArray().Cast<IOwnerUserEnhancable>().AsQueryable()
                            ).Cast<_T>();
                        _q = enhanced.ToArray().AsQueryable();
                        return _q;
                    },
                    (_params) => { return typeof(IOwnerUserEnhancable).IsAssignableFrom(typeof(_T)); },
                    (_params) => { return new object[] { _params.CurrentUserId }; }
                    )
                );

            m_PreFilterList.RegisterPostSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_SenderEnhance",
                    (_params, _q) =>
                    {
                        var enhanced = DataServiceLocator.UserService.ApplySenderUserEnhancement(
                            _q.ToArray().Cast<ISenderUserEnhancable>().AsQueryable()
                            ).Cast<_T>();
                        _q = enhanced.ToArray().AsQueryable();
                        return _q;
                    },
                    (_params) => { return typeof(ISenderUserEnhancable).IsAssignableFrom(typeof(_T)); },
                    (_params) => { return new object[] { }; }
                    )
                );

            m_PreFilterList.RegisterPostSelector<_T, IRelatedUserEnhancable>(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_RelatedEnhance",
                    (_params, _q) =>
                    {
                        var enhanced = DataServiceLocator.UserService.ApplyRelatedUserEnhancement(
                            _q.ToArray().Cast<IRelatedUserEnhancable>().AsQueryable()
                            ).Cast<_T>();
                        _q = enhanced.ToArray().AsQueryable();
                        return _q;
                    },
                    (_params) => { return typeof(IRelatedUserEnhancable).IsAssignableFrom(typeof(_T)); },
                    (_params) => { return new object[] { }; }
                    )
                );

            m_PreFilterList.RegisterPostSelector(
                 new BasicFilter<IDatabaseEntity>(
                     GetType().Name + "_JoinableEnhance",
                     (_params, _q) =>
                     {
                         var enhanced = DataServiceLocator.UserService.ApplyJoinableEventEnhancement(
                             _q.ToArray().Cast<IJoinableEventEnhancable>().AsQueryable(), _params.CurrentUserId
                             ).Cast<_T>();
                         _q = enhanced.ToArray().AsQueryable();
                         return _q;
                     },
                     (_params) => { return typeof(IJoinableEventEnhancable).IsAssignableFrom(typeof(_T)) && (_params.CurrentUserId > 0) && Request.Url.PathAndQuery.Contains("/Single"); },
                     (_params) => { return new object[] { _params.CurrentUserId }; }
                     )
                 );

            m_PreFilterList.RegisterPostSelector(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_FriendEnhance",
                    (_params, _q) =>
                    {
                        var enhanced = DataServiceLocator.UserService.ApplyFriendRelationEnhancement(
                            _q.ToArray().Cast<IFriendEnhancable>().AsQueryable(), _params.CurrentUserId
                            ).Cast<_T>();
                        _q = enhanced.ToArray().AsQueryable();
                        return _q;
                    },
                    (_params) =>
                    {
                        return Request.Url.PathAndQuery.Contains("User/Single") && (_params.CurrentUserId > 0) &&
                               typeof(IFriendEnhancable).IsAssignableFrom(typeof(_T));
                    },
                    (_params) => { return new object[] { _params.CurrentUserId }; }
                    )
                );
        }

        [Dependency]
        public IDataServiceLocator DataServiceLocator
        {
            get;
            set;
        }

        [ValidateInput(false)]
        public override ActionResult Single(long id)
        {
            Behaviour.OnlyApproved = false;
            Behaviour.OnlyPublished = false;

            _T _function = GetCachedEnhancedUltraItems(GetModuleParams()).First();

            if (Request.HttpMethod == "POST")
            {
                if (CustomTryUpdateModel(_function))
                {
                    Service.Update(_function);
                }
                return RedirectToAction("Single", new { id });
            }

            var moduleParams = GetModuleParams();

            // recalculate last comment view
            if (id > 0)
            {
                var currentUserId = moduleParams.CurrentUserId;
                var currentUserType = Mapper.INST.GetTypeCode<UserObject>();
                if (typeof(ICommentable).IsAssignableFrom(typeof(_T)) && currentUserId > 0)
                {
                    DataServiceLocator.CommentService.CheckVisit(currentUserId, currentUserType, (ICommentable)_function);
                }
            }

            Prepare(_function);

            return View(_function);
        }

        public override ModuleParams GetModuleParams()
        {
            var moduleParams = new ModuleParams(Request).Merge(RouteData.Values);

            if ((User.Identity.IsAuthenticated) && (User as UserPrincipal != null))
            {

                var principal = ((UserPrincipal)User).CurrentUser;

                if (principal != null)
                {
                    moduleParams.CurrentUserId = principal.Id;

                    if (String.IsNullOrEmpty(moduleParams.GetUserRubricFilter())
                        && principal.UseSelectedRubrics.HasValue && principal.UseSelectedRubrics.Value)
                    {
                        moduleParams.SetUserRubricFilter(
                            String.Join(";", DataServiceLocator.RubricService.GetSelectedRubrics(principal).Select(s => s.Id)));
                    }
                    moduleParams.IsAdmin = false; // new long[] { 1, 167, 168 }.Contains(principal.Id);
                }
            }

            return moduleParams;
        }

        public ActionResult CreateDraft()
        {
            var item = Create();
            InitDraft(item);
            Service.Insert(item);
            var cu = Params.CurrentUserId;
            DataServiceLocator.UserService.CreateRelation("ObjectAuthor", DataServiceLocator.UserService.GetById(cu), 
                                                          item.Id, item.ObjectType);
            return RedirectToAction("Edit", new { id = item.Id });
        }

        public ActionResult GetListDateJS()
        {
            var moduleParams = GetModuleParams();
            var cacheSignature = m_PreFilterList.GetCacheSignature(moduleParams);

            //var dt = moduleParams.CurrentDate.FromJSCode();

            var objList = (IEnumerable<IDateRangeItem>)this.GetOrStore("ListItemsDates",
                                                   typeof(_T),
                                                   () =>
                                                   {
                                                       // hack to force to display all rows
                                                       moduleParams.PageSize = 0;
                                                       return
                                                           (object)
                                                           m_PreFilterList.GetFiltered(moduleParams).Cast<IDateRangeItem>();
                                                   }, cacheSignature, "Dates");

            //var date1 =
            //    objList.Where(
            //        d =>
            //        d.EventStartDate.Day == d.EventEndDate.Day && d.EventStartDate.Month == d.EventEndDate.Month &&
            //        d.EventStartDate.Year == d.EventEndDate.Year).Select(
            //            s => new DateTime(s.EventStartDate.Year, s.EventStartDate.Month, s.EventStartDate.Day));

            var date = objList.Select(
                        s => new DateTime(s.EventStartDate.Year, s.EventStartDate.Month, s.EventStartDate.Day)).Distinct();

            var listDate = "<script language='javascript' type='text/javascript'>var SEMINARDATE =[";
            foreach (var item in date)
            {
                listDate = listDate + "'" + item.ToString("M.d.yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")) + "'";
                if (item != date.Last()) listDate = listDate + ",";
            }
            listDate = listDate + "];$(document).ready(function () {UpdateCalendarDate()});</script>";

            return Content(listDate);
        }
    }
}
