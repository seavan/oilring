using System.Linq;

namespace admin.db
{
    public interface IRelatableFactory<T1, T2, M>
    {
        IQueryable<T1> Get(IQueryable<T2> _table1, IQueryable<T1> _table2, IQueryable<M> _mediator);
    }

    public interface IRelatableFactory2<T2, T1, M>
    {
        IQueryable<T1> Get(IQueryable<T2> _table1, IQueryable<T1> _table2, IQueryable<M> _mediator);
    }

}