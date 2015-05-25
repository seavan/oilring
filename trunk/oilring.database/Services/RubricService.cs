	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Rubric
	File name: 	Rubric.service.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Notamedia.Oilring.Database.DataAccess;
using System.Web;
using Database.Entities;
using Database;

namespace admin.db
{
    public partial class RubricService : OilringDataService<Rubric, RubricObject, RubricObject.Converter>, IRubricService
    {
        protected static SortedList<long, RubricObject> m_ListRubrics = new SortedList<long, RubricObject>();
        protected static List<RubricObject> m_RubricObjects = new List<RubricObject>();
        protected static List<RubricObject> m_SortedRubricObjects = new List<RubricObject>();
        
        public RubricService()
        {
            RegisterManyToManyRelation<_TagRubricLink>("TagRubrics");
            RegisterRelation("Rubrics", new RelationOperand
            {
                Select = (id, otype) => GetThisRelatedModel<_RubricLink>(new DummyEntity(id, otype)),
                SelectBy = () => typeof(_RubricLink),
                Delete = (id, otype, id2, otype2) => 
                { 
                    DeleteRelation<_RubricLink>(new DummyEntity(id, otype), new DummyEntity(id2, otype2));

                    RebuildTagLinks(id, otype, id2, otype2);

                },
                DeleteAll = (id, otype) => 
                {
                    var rubrics = GetRelated("Rubrics", id, otype).ToArray();
                    DeleteAllRelation<_RubricLink>(new DummyEntity(id, otype));
                    RebuildTagLinks(rubrics.ToArray(), id, otype);
                },
                Insert =
                CreateExpector<RubricObject>(
                () =>
                (id, otype, id2, otype2) => 
                {

                    var linkedTagsQ = DataServiceLocator.TagService.GetRelated("Tags", id2, otype2);//
                    var linkedTags = linkedTagsQ.ToArray();

                    var rubric = GetById(id);
                    if (rubric.Level0 > 0)
                    {
                        CreateRelation<_RubricLink>(new DummyEntity(rubric.Level0, otype), new DummyEntity(id2, otype2));
                        CreateRelation<_TagRubricLink>(new DummyEntity(rubric.Level0, otype),
                                                           linkedTags);
                    }
                    
                    if (rubric.Level1 > 0)
                    {
                        CreateRelation<_RubricLink>(new DummyEntity(rubric.Level1, otype), new DummyEntity(id2, otype2));
                        CreateRelation<_TagRubricLink>(new DummyEntity(rubric.Level1, otype),
                                                           linkedTags);

                    }

                    if (rubric.Level2 > 0)
                    {
                        CreateRelation<_RubricLink>(new DummyEntity(rubric.Level2, otype), new DummyEntity(id2, otype2));
                        CreateRelation<_TagRubricLink>(new DummyEntity(rubric.Level2, otype),
                                                           linkedTags);

                    }

                })
            });
        }

        public void RebuildTagLinks(IDatabaseEntity[] _rubrics, long _taggedObjectId, string _taggedObjectType)
        {
            foreach (var rubric in _rubrics)
            {
                RebuildTagLinks(rubric.Id, rubric.ObjectType, _taggedObjectId, _taggedObjectType);
            }
        }

        public void RebuildTagLinks(long _rubricId, string _rubricOtype, long _taggedObjectId, string _taggedObjectType)
        {
            // TODO: is not very fast thing

            var tags = DataServiceLocator.TagService.GetRelated("Tags", _taggedObjectId, _taggedObjectType);

            foreach (var tag in tags)
            {
                var thisRubricLinkCount =
                    DataContext.GetTable<_TagLink>().Where(s => s.REL_Id1.Equals(tag.Id) && s.REL_ObjectType1.Equals(tag.ObjectType))
                    .Join(DataContext.GetTable<_RubricLink>(),
                    outer => new { id = outer.REL_Id2, otype = outer.REL_ObjectType2 },
                    inner => new { id = inner.REL_Id2, otype = inner.REL_ObjectType2 },
                    (outer, inner) => outer).Where(outer => outer.REL_Id1.Equals(_rubricId) && outer.REL_ObjectType1.Equals(_rubricOtype)).Count();

                if (thisRubricLinkCount <= 0)
                {
                    DeleteRelation<_TagRubricLink>(new DummyEntity(_rubricId, _rubricOtype), new DummyEntity(tag.Id, tag.ObjectType));
                }
            }
        }

        public override IQueryable<RubricObject> Convert(IQueryable<IDatabaseEntity> _src)
        {
            return BuildNestedSet(_src.ToArray().AsQueryable());
        }

        public IQueryable<RubricObject> BuildNestedSet(IQueryable<IDatabaseEntity> _entity)
        {
            return _entity.Select(s => m_ListRubrics[s.Id]).OrderBy(s => s.Left).AsQueryable();
        }

        /*protected override IQueryable<RubricObject> GetThisRelatedModel<RELATEDMEDIATOR>(IDatabaseEntity _arg)
        {
            // Init();
            return base.GetThisRelatedIds<RELATEDMEDIATOR>(_arg).Select(s => m_ListRubrics[s]).OrderBy(s => s.Left).AsQueryable();
        }*/

 

        public override RubricObject GetById(long id)
        {
            return m_ListRubrics[id];
        }

        public override IQueryable<RubricObject> GetAll()
        {
            // Init();
            return m_SortedRubricObjects.ToArray().AsQueryable();
        }

        protected override void Init()
        {

            if (ListRubrics.Count() <= 0)
            {
                var mask = new BigInteger(1);
                var items = base.GetAll().OrderBy(s => s.Id).ToArray().ToList();
                int i = 0;
                items.ForEach(s =>
                                  {
                                                s.Index = i++;
                                                  ListRubrics.Add(s.Id, s);
                                                  mask = mask << 1;
                                              });

                if (TreeRubrics.Count() <= 0)
                {
                    fill_parent(TreeRubrics, ListRubrics.Values, null);
                    int right = build_nested_set(TreeRubrics);
                    m_SortedRubricObjects = items.OrderBy(s => s.Left).ToList();
                }
            }
        }

        private int build_nested_set(List<RubricObject> _list, int _level = 0, int _current = 1)
        {
            foreach(var item in _list)
            {
                _current++;
                item.Left = _current;
                item.Level = _level;
                item.Right = build_nested_set(item.Children, _level + 1, item.Left);

                _current = item.Right;
            }
            return _current + 1;
        }

        private void fill_parent(List<RubricObject> _target, IEnumerable<RubricObject> _src, RubricObject _parent)
        {
            var pid = _parent != null ? _parent.Id : 0;
            _target.InsertRange(0,_src.Where( s => s.Parent_Rubric_ID == pid ));
            _target.ForEach(s =>
                                {
                                    s.SetParent(_parent);
                                    fill_parent(s.Children, _src, s);
                                });
        }

        protected SortedList<long, RubricObject> ListRubrics
        {
            get
            {
                if(m_ListRubrics == null)
                {
                    m_ListRubrics = new SortedList<long, RubricObject>();
                }
                return m_ListRubrics;
            }
        }
        protected List<RubricObject> TreeRubrics
        {
            get
            {
                if (m_RubricObjects == null)
                {
                    m_RubricObjects = new List<RubricObject>();
                }
                return m_RubricObjects;
            }
        }

        public List<RubricObject> GetAllRubrics()
        {
            return TreeRubrics;
        }

        public IEnumerable<RubricObject> GetSelectedRubrics(IEnumerable<long> IDs)
        {
            if (IDs != null)
            {
                return ListRubrics.Where(s => IDs.Contains(s.Key)).Select(s => s.Value);
            }
            return new RubricObject[] {};
        }

        public IEnumerable<RubricObject> ExpandWithParents(IEnumerable<RubricObject> _src)
        {
            var res = new List<RubricObject>();
            
            var parentableList = _src;
            while(parentableList.Count() > 0)
            {
                res.AddRange(parentableList);
                parentableList = parentableList.Where(s => s.Parent_Rubric_ID != 0).Select( s => m_ListRubrics[s.Parent_Rubric_ID] );
            }

            return res.OrderBy( s => s.Left ).ToArray();
        }

        //For Autch user
        public IEnumerable<RubricObject> GetSelectedRubrics(UserObject user)
        {
            //return GetSelectedRubrics(GetRubrics().Select(s => s.Id).ToArray());
            /*var IDs = GetRelated("Rubrics", user.Id, "user").Select(e => e.Id);
            var rs = GetSelectedRubrics(IDs).ToList();
            var rs2 = rs.Where(s => rs.Count(a => a.Parent_Rubric_ID == s.Id) == 0).ToList();
            return rs2;*/
            return new RubricObject[] { };
        }

        public List<RubricObject> Populate(long[] _ids)
        {
            var ids = _ids.Where(i => i > 0);
            var res1 = _ids.Select(i => m_ListRubrics[i]).ToList();
            var newRes = new System.Collections.Generic.SortedList<long, RubricObject>();

            res1.ForEach(
                s =>
                    {
                        var parent = s;
                        while( parent != null )
                        {
                            newRes[parent.Id] = parent;
                            parent = parent.GetParent();
                        }
                    });

            return newRes.Values.OrderBy( s => s.Left).ToList();
        }

        /// <summary>
        /// Set selected rubrics
        /// </summary>
        public void SetUserRubrics(IEnumerable<long> RubricIds, UserObject user)
        {
            var ds = DataServiceLocator;
            ds.UserService.DeleteAllRelation("Rubrics", user);
            foreach(var id in RubricIds)
            {
                ds.UserService.CreateRelation("Rubrics", user, id, "rubric");
            }
        }
        
        /// <summary>
        /// Get selected rubrics
        /// </summary>
        //public IEnumerable<RubricObject> GetRubrics()
        //{
        //    return new RubricObject[] { };
        //    if (HttpContext.Current.Session["SelectionRubrics"] != null)
        //    {
        //        return (IEnumerable<RubricObject>)HttpContext.Current.Session["SelectionRubrics"];
        //    }
        //    return new RubricObject[]{};
        //}

        //public List<RubricObject> GetTreeSelectedRubrics()
        //{
        //    var temp = GetRubrics();
        //    if (temp != null && temp.Count() > 0)
        //    {
        //        List<RubricObject> res = new List<RubricObject>();
        //        foreach(var item in temp)
        //        {
        //            var r = item;
        //            while (r != null)
        //            {
        //                res.Add(r);
        //                r = r.GetParent();
        //            }
        //        }
        //        return res.Distinct().OrderBy(s => s.Left).ToList();
        //    }
        //    return null;

        //}

        


    }
}	
