using System.Linq;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
using Web.Common.Filters;

namespace admin.web.common
{
    public class ByLetterUserFilter<_T> : BasicFilter<_T> where _T : IDatabaseEntity
    {
        public ByLetterUserFilter()
            : base(
                "ByFilterLetter",
                (_params, q)
                =>
                    {
                        return
                            q.Cast<IUserItem>().Where(s => s.LastName.StartsWith(_params.FilterLetter)).Cast<_T>().
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