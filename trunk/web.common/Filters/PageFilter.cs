using System;
using System.Linq;
using Web.Common.Filters;

namespace Web.Common.Filters
{
    public class PageFilter<_T> : BasicFilter<_T>
    {
        public PageFilter()
            : base(
            "PageFilter",
            (_params, q)
                   =>
            {
                return q.Skip((int)(_params.PageSize * (_params.Page - 1))).Take((int)_params.PageSize);
            },
            (_params)
            =>
                {
                    return (_params.PageSize > 0);
                },
            (_params) =>
                {
                    return new object[] { _params.PageSize, _params.Page };
                }
            

            )
        {
            
        }

    }
}