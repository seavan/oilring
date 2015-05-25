using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Entities;
using Web.Common.Modules;
using Web.Common.Controllers;

namespace admin.web.common
{
    /// <summary>
    /// Extension properties are not allowed :(
    /// </summary>
    public static class ModuleExtensions
    {
        public static OrderList GetOrder<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetOrder();
        }

        public static void SetOrder<_T, _M, _F>(this Module<_T, _M, _F> p, OrderList value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetOrder(value);
        }

        public static long GetSearchTagId<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetSearchTagId();
        }

        public static void SetSearchTagId<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetSearchTagId(value);
        }

        public static long GetSearchRubricId<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetSearchRubricId();
        }

        public static void SetSearchRubricId<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetSearchRubricId(value);
        }

        public static long GetCurrentDateForMonth<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetCurrentDateForMonth();
        }

        public static void SetCurrentDateForMonth<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetCurrentDateForMonth(value);
        }

        public static long GetCurrentDate<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetCurrentDate();
        }

        public static void SetCurrentDate<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetCurrentDate(value);
        }

        public static long GetUserFavouriteFilter<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetUserFavouriteFilter();
        }

        public static void SetUserFavouriteFilter<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetUserFavouriteFilter(value);
        }

        public static string GetUserRubricFilter<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetUserRubricFilter();
        }

        public static void SetUserRubricFilter<_T, _M, _F>(this Module<_T, _M, _F> p, string value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetUserRubricFilter(value);
        }

        public static long GetUserStatusFilter<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetUserStatusFilter();
        }

        public static void SetUserStatusFilter<_T, _M, _F>(this Module<_T, _M, _F> p, long value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetUserStatusFilter(value);
        }

        #region UserTagFilter
        public static string GetUserTagFilter<_T, _M, _F>(this Module<_T, _M, _F> p)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            return p.ModuleParams.GetUserTagFilter();
        }

        public static void SetUserTagFilter<_T, _M, _F>(this Module<_T, _M, _F> p, string value)
            where _T : BaseUniversalController<_M>, new()
            where _M : class, IDatabaseEntity, new()
            where _F : class, new()
        {
            p.ModuleParams.SetUserTagFilter(value);
        }
        #endregion // UserTagFilter
    }
}
