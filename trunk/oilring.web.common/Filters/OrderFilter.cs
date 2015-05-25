using System.Linq;
using Notamedia.Oilring.Database.DataAccess;
using System;
using Database.Entities;
using Web.Common.Filters;

namespace admin.web.common
{
    public class OrderFilter<_T> : BasicFilter<_T> where _T : IDatabaseEntity
    {
        public OrderFilter()
            : base(
                "OrderFilter",
                (_params, q)
                =>
                    {
                        switch (_params.GetOrder())
                        {
                            case OrderList.Commented: q = q.Cast<ICommentable>().OrderByDescending(s => s.AUTO_CommentCount).Cast<_T>(); break;
                            case OrderList.LastName: q = q.Cast<IUserItem>().OrderBy(s => s.LastName).Cast<_T>(); break;
                            case OrderList.Title: q = q.Cast<IOrgItem>().OrderBy(s => s.Title).Cast<_T>(); break;
                            case OrderList.PublicationDateDesc: q = q.Cast<IPublishedItem>().OrderByDescending(s => s.CreationDate).Cast<_T>().OrderByDescending(s => s.Id); break;
                            case OrderList.Coming: q = q.Cast<IDateRangeItem>().Where(s => s.EventEndDate >= DateTime.Now).OrderBy(s => s.EventStartDate).Cast<_T>(); break;
                            case OrderList.Passed: q = q.Cast<IDateRangeItem>().Where(s => s.EventEndDate < DateTime.Now).OrderByDescending(s => s.EventStartDate).Cast<_T>(); break;
                            default: break;
                        }
                        return q;
                    },
                (_params)
                =>
                    {
                        return (_params.GetOrder() >= 0) && (!_params.Action.Contains("Single"));
                    },
                (_params) =>
                    {
                        return new object[] { _params.GetOrder() };
                    }
            

                )
        {
            
        }

    }
}