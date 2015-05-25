using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Modules;

namespace admin.web.common
{
    public static class ModuleParamsExtensions
    {
        public static OrderList GetOrder(this ModuleParams p)
        {
            return p.GetEnum<OrderList>("Order");
        }

        public static void SetOrder(this ModuleParams p, OrderList value)
        {
            p.SetEnum("Order", value);
        }

        public static long GetSearchTagId(this ModuleParams p)
        {
            return p.GetInt("SearchTagId");
        }

        public static void SetSearchTagId(this ModuleParams p, long value)
        {
            p.Set("SearchTagId", value);
        }

        public static long GetSearchRubricId(this ModuleParams p)
        {
            return p.GetInt("SearchRubricId");
        }

        public static void SetSearchRubricId(this ModuleParams p, long value)
        {
            p.Set("SearchRubricId", value);
        }

        public static long GetCurrentDateForMonth(this ModuleParams p)
        {
            return p.GetInt("CurrentDateForMonth");
        }

        public static void SetCurrentDateForMonth(this ModuleParams p, long value)
        {
            p.Set("CurrentDateForMonth", value);
        }

        public static long GetCurrentDate(this ModuleParams p)
        {
            return p.GetInt("CurrentDate");
        }

        public static void SetCurrentDate(this ModuleParams p, long value)
        {
            p.Set("CurrentDate", value);
        }

        public static long GetUserFavouriteFilter(this ModuleParams p)
        {
            return p.GetInt("UserFavouriteFilter");
        }

        public static void SetUserFavouriteFilter(this ModuleParams p, long value)
        {
            p.Set("UserFavouriteFilter", value);
        }

        public static string GetUserRubricFilter(this ModuleParams p)
        {
            return p.GetString("UserRubricFilter");
        }

        public static void SetUserRubricFilter(this ModuleParams p, string value)
        {
            p.Set("UserRubricFilter", value);
        }

        #region UserStatusFilter
        public static long GetUserStatusFilter(this ModuleParams p)
        {
            return p.GetInt("UserStatusFilter");
        }

        public static void SetUserStatusFilter(this ModuleParams p, long value)
        {
            p.Set("UserStatusFilter", value);
        }
        #endregion // UserStatusFilter

        #region UserTagFilter
        public static string GetUserTagFilter(this ModuleParams p)
        {
            return p.GetString("UserTagFilter");
        }

        public static void SetUserTagFilter(this ModuleParams p, string value)
        {
            p.Set("UserTagFilter", value);
        }
        #endregion // UserTagFilter
    }
}
