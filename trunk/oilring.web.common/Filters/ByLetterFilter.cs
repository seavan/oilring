using System.Linq;
using Notamedia.Oilring.Database.DataAccess;
using System.Linq.Expressions;
using admin.db;
using System;
using Database.Entities;
using Web.Common.Filters;

namespace admin.web.common
{
    public class ByLetterFilter<_T> : BasicFilter<_T> where _T : IDatabaseEntity
    {
        public ByLetterFilter()
            : base(
                "ByFilterLetter",
                (_params, q)
                =>
                    {
                        return
                            q.Cast<ITitleable>().Where(s => s.Title.StartsWith(_params.FilterLetter)).Cast<_T>().
                                AsQueryable();
                    },
                (_params)
                =>
                    {
                        return !string.IsNullOrEmpty(_params.FilterLetter);
                    },
                (_params) =>
                    {
                        return new object[] { _params.FilterLetter };
                    }
                )
        {
            
        }
    }
}