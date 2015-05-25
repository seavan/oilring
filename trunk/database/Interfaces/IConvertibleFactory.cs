using System;
using System.Linq.Expressions;
using System.Data.Linq;

namespace Database.Interfaces
{
    public interface IConvertibleFactory<T, M>
    {
        Expression<Func<T, M>> GetConverter();
        Action<M, T> GetModelConverter();
        DataLoadOptions GetOptions();

    }
}