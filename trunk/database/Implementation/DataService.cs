using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Practices.Unity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Collections.Specialized;
using Database.Interfaces;
using Database.Extensions;
using Database.Entities;
using Common;
using Common.IoC;

namespace Database.Implementation
{
    public abstract class DataService<T, M, C> :
        IDataService<M>
        where T : class, IDatabaseEntity, new()
        where M : class, IDatabaseEntity, IAutoUpdateable, new()
        where C : IConvertibleFactory<T, M>, new()
    {

        public void ResetCache()
        {
            this.ResetDep(typeof(M));
        }

        protected virtual IQueryable<T> GetAllDb()
        {
            return Table.AsQueryable<T>();
        }

        protected virtual T GetByIdDb(long id)
        {
            return Table.SingleOrDefault<T>(o => o.Id.Equals(id));
        }

        protected void DeleteDb(long id)
        {
            TraceContext.Transaction(s =>
            {
                var item = s.GetTable<T>().Single(obj => obj.Id.Equals(id));
                var toUpdate = UpdateParentAssociations(s, item.Id);
                s.GetTable<T>().DeleteOnSubmit(item);
                s.SubmitChanges();
                foreach (var i in toUpdate)
                {
                    Updater.Update(s, i);
                }
                s.SubmitChanges();
            });
            this.ResetDep(typeof(M));
        }

        #region IDataService<M> Members

        public virtual IQueryable<M> Convert(IQueryable<IDatabaseEntity> _src)
        {
            return _src.Cast<T>().Select(m_ConverterExpression);
        }

        public IQueryable<IDatabaseEntity> GetAllPre()
        {
            return GetAllDb().Cast<IDatabaseEntity>();
        }

        public void Update(M item)
        {
            TraceContext.Transaction(s =>
                                         {
                                             var dbItem = item.Id > 0
                                                              ? s.GetTable<T>().Single(obj => obj.Id.Equals(item.Id))
                                                              : new T();
                                             m_BackConverter(item, dbItem);
                                             if (dbItem.Id <= 0)
                                             {
                                                 s.GetTable<T>().InsertOnSubmit(dbItem);
                                             }
                                             item.Id = dbItem.Id;
                                             AfterUpdate(dbItem, item);
                                             s.SubmitChanges();
                                             UpdateParentAssociations(s, dbItem.Id).ToList().ForEach(
                                                 i => Updater.Update(s, i)
                                                 );

                                             s.SubmitChanges();
                                         });
            this.ResetDep(typeof (M));
        }
        #endregion

        /// <summary>
        /// TODO: разобраться, может быть IPublishedItem надо вынести в дочерний проект
        /// </summary>
        /// <param name="_item"></param>
        protected virtual void InitItem(M _item)
        {
            var pi = _item as IPublishedItem;
            if (pi != null)
            {
                pi.CreationDate = DateTime.Now;
            }
        }

        public M CreateItem()
        {
            //var i = CreateItemDb();
            var m = new M();
            Updater.Init(DataContext, m);
            InitItem(m);
            //InsertDb(i);
            return m;
        }

        public virtual IQueryable<M> GetAll()
        {
            return GetAllDb().Select(m_ConverterExpression);
        }

        public virtual M GetById(long id)
        {
            return m_Converter(GetByIdDb(id));
        }


        public IDatabaseEntity Resolve(long _id)
        {
            return GetById(_id);
        }

        public void Delete(M item)
        {
            // todo
            DeleteAllRelation(item);
            DeleteDb(item.Id);
        }

        public void Insert(M item)
        {
            var dbItem = new T();
            TraceContext.Transaction(s =>
                                         {
                                             m_BackConverter(item, dbItem);
                                             s.GetTable<T>().InsertOnSubmit(dbItem);
                                             s.SubmitChanges();
                                             UpdateParentAssociations(s, dbItem.Id).ToList().ForEach(
                                                 i => Updater.Update(s, i)
                                                 );
                                             s.SubmitChanges();
                                         });
            item.Id = dbItem.Id;
            item.ObjectType = dbItem.ObjectType;
            this.ResetDep(typeof (M));
        }
        

        #region Private Methods

        #endregion

        protected class Joiner<T1, T2>
        {
            public T1 table1 { get; set; }
            public T2 table2 { get; set; }
        }
        private Action<M, T> m_BackConverter = null;

        private Func<T, M> m_Converter = null;

        protected Expression<Func<T, M>> m_ConverterExpression = null;


        private TraceDataContext m_TraceContext;

        public DataService()
        {
            var f = new C();

            Mapper.INST.RegisterEntityType<T, M>(this);

            m_ConverterExpression = f.GetConverter();
            m_Converter = m_ConverterExpression.Compile();
            m_BackConverter = f.GetModelConverter();

            if (typeof(IManyToOne).IsAssignableFrom(typeof(T)))
            {
                RegisterRelation(typeof (M).Name + "_ManyToOne",
                                 new RelationOperand()
                                     {Select = (_id, _type) => 
                                     { 
                                         return GetByParent(new DummyEntity(_id, _type)); 
                                     },
                                     Delete = (id1, otype1, id2, otype2) =>
                                                  {
                                                      if (otype1 == Mapper.INST.GetTypeCode<T>())
                                                      {
                                                          DeleteDb(id1);
                                                      }
                                                      else
                                                      {
                                                          if (otype2 == Mapper.INST.GetTypeCode<T>())
                                                          {
                                                              DeleteDb(id2);
                                                          }   
                                                      }
                                                  },
                                      DeleteAll =
                                                 (id, otype) => { DeleteManyToOneCascade(new DummyEntity(id, otype)); },
                                                 Insert = (thisItem, thisOtype, otherItem, otherOtype)
                                                     =>
                                                              {
                                                                  TraceContext.Transaction(
                                                                      s =>
                                                                          {
                                                                              var item =
                                                                                  s.GetTable<T>().Where(
                                                                                      i =>
                                                                                      i.Id.Equals(thisItem) &&
                                                                                      i.ObjectType.Equals(thisOtype)).Cast<IManyToOne>().Single();

                                                                              item.REL_Id = otherItem;
                                                                              item.REL_ObjectType = otherOtype;
                                                                              s.SubmitChanges();
                                                                          });
                                                              }

                                     
                                     });
            }

            if (typeof(IOneToOne).IsAssignableFrom(typeof(T)))
            {
                RegisterRelation(typeof(M).Name + "_ManyToOne",
                                  new RelationOperand()
                                  {
                                      Select = (_id, _type) =>
                                      {
                                          return GetByParent(new DummyEntity(_id, _type));
                                      },
                                      Delete = (id1, otype1, id2, otype2) =>
                                      {
                                          if (otype1 == Mapper.INST.GetTypeCode<T>())
                                          {
                                              DeleteDb(id1);
                                          }
                                          else
                                          {
                                              if (otype2 == Mapper.INST.GetTypeCode<T>())
                                              {
                                                  DeleteDb(id2);
                                              }
                                          }
                                      },

                                      Insert = (thisItem, thisOtype, otherItem, otherOtype)
                                          =>
                                      {
                                          TraceContext.Transaction(
                                              s =>
                                              {
                                                  var item =
                                                      s.GetTable<T>().Where(
                                                          i =>
                                                          i.Id.Equals(thisItem) &&
                                                          i.ObjectType.Equals(thisOtype)).Cast<IOneToOne>().Single();

                                                  item.Id = otherItem;
                                                  item.REF_ObjectType = otherOtype;
                                                  s.SubmitChanges();
                                              });
                                      }
                                  });
            }
        }

        public Action<long, string, long, string> CreateExpector<_T1>(Func<Action<long, string, long, string>> _callbackResolver)
        {
            return (id1, otype1, id2, otype2) =>
            {
                if (otype1.Equals(Mapper.INST.GetTypeCode<_T1>()))
                {
                    _callbackResolver()
                        (
                        id1, otype1, id2, otype2
                        );
                }
                if (otype2.Equals(Mapper.INST.GetTypeCode<_T1>()))
                {
                    _callbackResolver()
                        (
                        id2, otype2, id1, otype1
                        );
                }
            };
        }

        public Action<IDatabaseEntity, IDatabaseEntity> CreateExpector<_T1>(Func<Action<_T1, IDatabaseEntity>> _callbackResolver)
        {
            return (param1, param2) =>
            {
                if (param1.ObjectType.Equals(Mapper.INST.GetTypeCode<_T1>()))
                {
                    _callbackResolver()
                        (
                        (_T1)DataStore.Resolve(param1.Id, param1.ObjectType),
                        DataStore.Resolve(param2.Id, param2.ObjectType)
                        );
                }
                if (param2.ObjectType.Equals(Mapper.INST.GetTypeCode<_T1>()))
                {
                    _callbackResolver()(
                        (_T1)DataStore.Resolve(param2.Id, param2.ObjectType),
                        DataStore.Resolve(param1.Id, param1.ObjectType)
                        );
                }
            };
        }

        public Action<IDatabaseEntity, IDatabaseEntity> CreateExpector<_T1, _T2>(Func<Action<_T1, _T2>> _callbackResolver)
        {
            return (param1, param2) =>
            {
                if (param1.ObjectType.Equals(Mapper.INST.GetTypeCode<_T1>()) && param2.ObjectType.Equals(Mapper.INST.GetTypeCode<_T2>()))
                {
                    _callbackResolver()
                        (
                        (_T1)DataStore.Resolve(param1.Id, param1.ObjectType),
                        (_T2)DataStore.Resolve(param2.Id, param2.ObjectType)
                        );
                }
                else
                if (param2.ObjectType.Equals(Mapper.INST.GetTypeCode<_T1>()) && param1.ObjectType.Equals(Mapper.INST.GetTypeCode<_T2>()))
                {
                    _callbackResolver()
                        (
                        (_T1)DataStore.Resolve(param2.Id, param2.ObjectType),
                        (_T2)DataStore.Resolve(param1.Id, param1.ObjectType)
                        );
                }
            };
        }

        /// <summary>
        /// Получить все связанные объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDatabaseEntity> FilterByRelated<R>(string _relationName, long[] _ids, IQueryable<IDatabaseEntity> _src) where R : IDatabaseEntity
        {
            var objectType = typeof(T).Name.ToLower();
            if (DataRelationRegistrar.RegisteredRelations.IndexOfKey(_relationName) != -1)
            {
                var mediator =
                 DataRelationRegistrar.RegisteredRelations[_relationName].SelectBy();

                var res = GetByRelatedDb(mediator, typeof(R), _ids, _src);

                return res;
            }
            else
            {
                //throw new SystemException("Relation not found " + _relationName);
                return new List<IDatabaseEntity>().AsQueryable();
            }
        }

        public IDatabaseEntity[] GetAllRelations(string _relation, M _item)
        {
            var rel = DataRelationRegistrar.RegisteredRelations[_relation];

            if (rel.SelectBy != null)
            {
                return DataContext.GetTable(rel.SelectBy()).Cast<IRelatable>().
                    Where(
                        s => s.REL_Id1.Equals(_item.Id) && s.REL_ObjectType1.Equals(_item.ObjectType)).Select(
                            s => new DummyEntity(s.REL_Id2, s.REL_ObjectType2)).ToArray();
            }
            else
            {
                if( rel.Select != null)
                {
                    return rel.Select(_item.Id, _item.ObjectType).ToArray();
                }
            }
            return new IDatabaseEntity[] {};
        }

        protected IQueryable<IDatabaseEntity> GetByParent(IDatabaseEntity _arg)
        {
            return GetAllDb().Cast<IManyToOne>()
                .Where(s => s.REL_Id.Equals(_arg.Id)
                            && s.REL_ObjectType.Equals(_arg.ObjectType)).Cast<T>()
                .AsQueryable();
        }

        protected IQueryable<IDatabaseEntity> GetByRelatedDb(Type _mediator, Type _related, long[] _ids, IQueryable<IDatabaseEntity> _src)
        {
            var relatedType = _related.Name.ToLower();// +"_" + typeof(T).Name;
            var m1 = DataContext.GetTable(_mediator).Cast<IRelatable>();//.Where( s => _ids.Contains(s.REL_Id2) && s.REL_ObjectType2.Equals(relatedType)).AsEnumerable();

            var r = _src.Join(m1,
                outer => new { id = outer.Id, type = outer.ObjectType },
                inner => new { id = inner.REL_Id1, type = inner.REL_ObjectType1 },
                (outer, inner) => new Joiner<IRelatable, IDatabaseEntity>() { table1 = inner, table2 = outer })
                .Where( s => _ids.Contains(s.table1.REL_Id2) && s.table1.REL_ObjectType2.Equals(relatedType))
                .Select(s => s.table2).AsQueryable()
                ;
            
            return r;
        }

        public string[] GetRegisteredRelations()
        {
            return DataRelationRegistrar.RegisteredRelations.Keys.ToArray();
        }

        /// <summary>
        /// Получить все связанные объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDatabaseEntity> GetRelated(string _relationName, long _id, string _objectType)
        {
            if (DataRelationRegistrar.RegisteredRelations.IndexOfKey(_relationName) != -1)
            {
                return
                    DataRelationRegistrar.RegisteredRelations[_relationName].Select(_id, _objectType).
                        AsQueryable();
            }
            else
            {
                //throw new SystemException("Relation not found " + _relationName);
                return new M[] {}.AsQueryable();
            }
        }

        protected IQueryable<IDatabaseEntity> GetRelatedDb<RELATEDMEDIATOR>(Type _type, IDatabaseEntity _arg, Expression<Func<RELATEDMEDIATOR, bool>>
            _mediatorFilter = null)
            where RELATEDMEDIATOR : class, IRelatable, new()
        {
            var s1 = DataContext.GetTable(_type).AsQueryable().Cast<IDatabaseEntity>();
            var m1 = DataContext.GetTable<RELATEDMEDIATOR>().AsQueryable();
            if( _mediatorFilter != null )
            {
                m1 = m1.Where(_mediatorFilter);
            }

            var res = s1;
            if (_arg != null)
            {
                m1 = m1.Where(s => s.REL_Id1.Equals(_arg.Id) && s.REL_ObjectType1.Equals(_arg.ObjectType));
            }
            res = m1.Join(s1, med_key => new { id = med_key.REL_Id2, type = med_key.REL_ObjectType2 }, tg_key => new { id = tg_key.Id, type = tg_key.ObjectType }, (inner, result) => result).AsQueryable();
            return res;
        }

        protected IEnumerable<long> GetThisRelatedIds<RELATEDMEDIATOR>(IDatabaseEntity _arg)
            where RELATEDMEDIATOR : class, IRelatable, new()
        {
            return GetRelatedDb<RELATEDMEDIATOR>(typeof (T), _arg).Cast<T>().Select(s => s.Id);
        }

        protected virtual IQueryable<IDatabaseEntity> GetThisRelatedModel<RELATEDMEDIATOR>(IDatabaseEntity _arg)
            where RELATEDMEDIATOR : class, IRelatable, new()
        {
            return GetRelatedDb<RELATEDMEDIATOR>(typeof (T), _arg).Cast<T>().AsQueryable();
        }

        public virtual IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
        {
            return new List<IDatabaseEntity>();
        }

        public virtual void AfterUpdate(T _dbItem, M _model)
        {
        }

        public void AutoUpdateAll()
        {
            TraceContext.Transaction(s =>
                                         {
                                             var f = new C();
                                             s.DeferredLoadingEnabled = true;
                                             //s.LoadOptions = f.GetOptions();

                                             //var c1 = f.GetFullConverter().Compile();
                                             var updating = s.GetTable<T>().ToList();
                                             updating.ForEach(
                                                 obj => { Updater.Update(s, obj); }
                                                 );
                                             s.SubmitChanges();
                                         });
        }

        protected void CreateRelation<R>(IDatabaseEntity _arg1, IDatabaseEntity[] _arg2, Func<R, R> _additional = null)
            where R : class, IRelatable, new()
        {
            foreach (var arg in _arg2)
            {
                CreateRelation<R>(_arg1, arg, _additional);
            }
        }

        protected void CreateRelation<R>(IDatabaseEntity _arg1, IDatabaseEntity _arg2, Func<R, R> _additional = null)
            where R : class, IRelatable, new()
        {
            TraceContext.Transaction(s =>
                                         {
                                             var t = s.GetTable<R>();

                                             var existing1 = t.Where(
                                                 rel =>
                                                 (rel.REL_Id1.Equals(_arg1.Id) &&
                                                  rel.REL_ObjectType1.Equals(_arg1.ObjectType)
                                                  && rel.REL_Id2.Equals(_arg2.Id) &&
                                                  rel.REL_ObjectType2.Equals(_arg2.ObjectType)
                                                 )).FirstOrDefault();
                                             
                                             var existing2 = t.Where(rel =>
                                                     (rel.REL_Id1.Equals(_arg2.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg2.ObjectType)
                                                      && rel.REL_Id2.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg1.ObjectType)
                                                     )
                                                     ).FirstOrDefault();

                                             if (existing1 == null)
                                             {
                                                 existing1 = new R();
                                                 t.InsertOnSubmit(existing1);
                                             }
                                             if (existing2 == null)
                                             {
                                                 existing2 = new R();
                                                 t.InsertOnSubmit(existing2);
                                             }
                                             /*
                                             t.DeleteAllOnSubmit(t.Where(
                                                     rel =>
                                                     (rel.REL_Id1.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg1.ObjectType)
                                                      && rel.REL_Id2.Equals(_arg2.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg2.ObjectType)
                                                     ) ||
                                                     (rel.REL_Id1.Equals(_arg2.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg2.ObjectType)
                                                      && rel.REL_Id2.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg1.ObjectType)
                                                     )
                                                     )); */

                                             var r1 = existing1 != null ? existing1 : new R();
                                             r1.REL_Id1 = _arg1.Id;
                                             r1.REL_ObjectType1 = _arg1.ObjectType;
                                             r1.REL_Id2 = _arg2.Id;
                                             r1.REL_ObjectType2 = _arg2.ObjectType;
                                             var r2 = existing2 != null ? existing2 : new R();
                                             r2.REL_Id1 = _arg2.Id;
                                             r2.REL_ObjectType1 = _arg2.ObjectType;
                                             r2.REL_Id2 = _arg1.Id;
                                             r2.REL_ObjectType2 = _arg1.ObjectType;

                                             if (_additional != null)
                                             {
                                                 r1 = _additional(r1);
                                                 r2 = _additional(r2);
                                             }

                                             //t.InsertOnSubmit(r1);
                                             //t.InsertOnSubmit(r2);

                                             s.SubmitChanges();

                                             Updater.Update(s, _arg1.Id, _arg1.ObjectType);
                                             Updater.Update(s, _arg2.Id, _arg2.ObjectType);

                                             s.SubmitChanges();

                                         });
        }


        public void CreateRelation(string _relation, M _item, long _id, string _otype)
        {
            var r = DataRelationRegistrar.RegisteredRelations[_relation];
            r.Insert(_item.Id, _item.ObjectType, _id, _otype);
            if (r.NotificationAdd != null)
            {
                r.NotificationAdd(_item, new DummyEntity(_id, _otype));
            }
        }

        protected void DeleteAllRelation<R>(IDatabaseEntity _arg1)
            where R : class, IRelatable, new()
        {
            TraceContext.Transaction(s =>
                                         {
                                             var t = s.GetTable<R>();
                                             var existing =
                                                 t.Where(
                                                     rel =>
                                                     (rel.REL_Id1.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg1.ObjectType)
                                                     )
                                                     ||
                                                     (rel.REL_Id2.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg1.ObjectType)
                                                     ));
                                             t.DeleteAllOnSubmit(existing);
                                             s.SubmitChanges();
                                         });
        }


        public void DeleteAllRelation(M _item)
        {
            // todo
            foreach (var relation in DataRelationRegistrar.RegisteredRelations.Keys)
            {
                DeleteAllRelation(relation, _item);
            }
        }

        public virtual void DeleteAllRelation(string _relation, M _item)
        {
            var deleter = DataRelationRegistrar.RegisteredRelations[_relation].DeleteAll;
            if( deleter != null )
            {
                deleter(_item.Id,
                _item.ObjectType)
                ;
            }
        }

        protected void DeleteFromParent(IDatabaseEntity _arg)
        {
            DeleteDb(_arg.Id);
        }

        protected void DeleteManyToOneCascade(IDatabaseEntity _arg1)
        {
                        
            TraceContext.Transaction(s =>
            {
                var t = s.GetTable<T>();
                var existing =
                    t.Cast<IManyToOne>().Where(
                    i => i.REL_Id.Equals(_arg1.Id) && i.REL_ObjectType.Equals(_arg1.ObjectType));
                t.DeleteAllOnSubmit(existing.Cast<T>());
                s.SubmitChanges();
            });
        }

        protected void DeleteRelation<R>(IDatabaseEntity _arg1, IDatabaseEntity _arg2)
            where R : class, IRelatable, new()
        {
            TraceContext.Transaction(s =>
                                         {
                                             var t = s.GetTable<R>();
                                             var existing =
                                                 t.Where(
                                                     rel =>
                                                     (rel.REL_Id1.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg1.ObjectType)
                                                      && rel.REL_Id2.Equals(_arg2.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg2.ObjectType)
                                                     )
                                                     ||
                                                     (rel.REL_Id1.Equals(_arg2.Id) &&
                                                      rel.REL_ObjectType1.Equals(_arg2.ObjectType)
                                                      && rel.REL_Id2.Equals(_arg1.Id) &&
                                                      rel.REL_ObjectType2.Equals(_arg1.ObjectType)
                                                     )
                                                     );
                                             t.DeleteAllOnSubmit(existing);
                                             s.SubmitChanges();
                                         });
        }

        public void DeleteRelation(string _relation, M _item, long _id, string _otype)
        {
            DataRelationRegistrar.RegisteredRelations[_relation].Delete(_item.Id, _item.ObjectType, _id, _otype);
        }

        protected virtual void Init()
        {
        }

        /// <summary>
        /// TODO используется только в потомках - protected?
        /// </summary>
        /// <typeparam name="_R"></typeparam>
        /// <param name="_Name"></param>
        /// <param name="_NotificationAdd"></param>
        /// <param name="_noDelete"></param>
        public void RegisterManyToManyRelation<_R>(string _Name, Action<IDatabaseEntity, IDatabaseEntity> _NotificationAdd = null, bool _noDelete = false) where _R : class, IRelatable, new()
        {
            var op = new RelationOperand()
                                        {
                                            Select = (id, otype) => GetThisRelatedModel<_R>(new DummyEntity(id, otype)),
                                            Delete =
                                                 (id, otype, id2, otype2) =>
                                                    {
                                                        DeleteRelation<_R>(new DummyEntity(id, otype),
                                                                           new DummyEntity(id2, otype2));
                                                    },
                                            DeleteAll =
                                                (id, otype) => { DeleteAllRelation<_R>(new DummyEntity(id, otype)); },
                                            Insert =
                                                (id, otype, id2, otype2) =>
                                                    {
                                                        CreateRelation<_R>(new DummyEntity(id, otype),
                                                                           new DummyEntity(id2, otype2));
                                                    },
                                            SelectBy = () => typeof(_R),
                                            NotificationAdd = _NotificationAdd

                                        };
            if (_noDelete)
            {
                op.Delete = null;
                op.DeleteAll = null;
            }

            RegisterRelation(_Name, op);
        }

        /// <summary>
        /// TODO: используется только в потомках - protected?
        /// </summary>
        /// <param name="_Name"></param>
        /// <param name="_operand"></param>
        public void RegisterRelation(string _Name, RelationOperand _operand)
        {
            DataRelationRegistrar.RegisteredRelations[_Name] = _operand;
        }


        public DataContext DataContext
        {
            get { return TraceContext.ReadOnlyContext; }
        }

        public IDataStore DataStore
        {
            get { return MvcUnityContainer.Container.Resolve<IDataStore>(); }
        }

        protected UniversalUpdater Updater
        {
            get { return MvcUnityContainer.Container.Resolve<UniversalUpdater>(); }
        }

        private Table<T> Table
        {
            get { return DataContext.GetTable<T>(); }
        }

        /// <summary>
        /// TODO: отвязать от Unity!
        /// </summary>
        [Dependency("WebTraceContext")]
        public TraceDataContext TraceContext
        {
            get
            {
                // hack
                // return m_TraceContext;
                return MvcUnityContainer.Container.Resolve<TraceDataContext>("WebTraceContext");
            }
            set
            {
                m_TraceContext = value;
                Init();
            }
        }

        public NameValueCollection GetAppSettings()
        {
            NameValueCollection result = null;

            if (HttpContext.Current != null)
            {
                result = System.Web.Configuration.WebConfigurationManager.AppSettings;
            }
            else
            {
                result = System.Configuration.ConfigurationManager.AppSettings;
            }
            return result;
        }

        public ConnectionStringSettingsCollection GetConnectionStrings()
        {
            ConnectionStringSettingsCollection result = null;

            if (HttpContext.Current != null)
            {
                result = System.Web.Configuration.WebConfigurationManager.ConnectionStrings;
            }
            else
            {
                result = System.Configuration.ConfigurationManager.ConnectionStrings;
            }
            return result;
        }

        #region IDataService<M> Members


        public M InsertOrFind(M item)
        {
            var cmp = GetEqualityComparer(item);
            var res = GetAllDb().Where(cmp).FirstOrDefault();
            if (res != null)
            {
                return GetById(res.Id);
            }
            Insert(item);
            return item;
        }

        #endregion

        protected virtual Expression<Func<T, bool>> GetEqualityComparer(M b)
        {
            return (a) => a.Id.Equals(b.Id) && a.ObjectType.Equals(b.ObjectType);
        }
    }
}