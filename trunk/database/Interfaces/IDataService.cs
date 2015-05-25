using System.Collections.Generic;
using System.Linq;

using System;
using Database.Entities;

namespace Database.Interfaces
{
    public interface IDataService
    {
        IDatabaseEntity Resolve(long _id);
    }

    public interface IDataService<T> : IDataService
        where T : class, IDatabaseEntity, new()
    {
        string[] GetRegisteredRelations();

        void CreateRelation(string _relation, T _item, long _id, string _otype);

        void DeleteRelation(string _relation, T _item, long _id, string _otype);

        void DeleteAllRelation(string _relation, T _item);

        IDatabaseEntity[] GetAllRelations(string _relation, T _item);

        void AutoUpdateAll();

        /// <summary>
        /// Получить все объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получить все объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        IQueryable<IDatabaseEntity> GetAllPre();

        /// <summary>
        /// Получить все объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Convert(IQueryable<IDatabaseEntity> _src);
        /// <summary>
        /// Получить все связанные объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        IQueryable<IDatabaseEntity> GetRelated(string _relationName, long _id, string _objectType);

        //IQueryable<T> GetByRelated(string _relationName, long[] _ids);

        IQueryable<IDatabaseEntity> FilterByRelated<R>(string _relationName, long[] _ids, IQueryable<IDatabaseEntity> _src) 
            where R : IDatabaseEntity;
        /// <summary>
        /// Получить элемент по первичному ключу
        /// </summary>
        /// <param name="id">ключ</param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// Вставить объект и закоммитить изменения
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        /// Вставить объект и закоммитить изменения
        /// </summary>
        /// <param name="item"></param>
        T InsertOrFind(T item);

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="item">Удаляемый элемент (объект). Должен присутствовать в БД</param>
        void Delete(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T CreateItem();

        void Update(T item);

        /// <summary>
        /// TODO: Зачем это в интерфейсе?
        /// </summary>
        /// <param name="_Name"></param>
        /// <param name="_operand"></param>
        void RegisterRelation(string _Name, RelationOperand _operand);
 

/*        IQueryable<RELATEDMODEL> GetRelated<RELATEDTYPE, RELATEDMODEL, RELATEDCF, RELATEDMEDIATOR>(IDatabaseEntity _arg)
            where RELATEDMODEL : class, IDatabaseEntity, new()
            where RELATEDTYPE : class, IDatabaseEntity, new()
            where RELATEDCF : IConvertibleFactory<RELATEDTYPE, RELATEDMODEL>, new()
            where RELATEDMEDIATOR : class, IRelatable, new(); */


    }
}