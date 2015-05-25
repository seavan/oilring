namespace admin.db
{
    public interface IRelatableCreator<T1, T2, R>
    {
        R[] CreateRelation(T1 _t1, T2 _t2);
    }
}