
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Tag
    File name: 	Tag.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Web;
using Database.Entities;
using Database;
namespace admin.db
{
    public partial class TagService
    {
        public TagService()
        {
            //RegisterManyToManyRelation<_TagLink>("Tags");

            RegisterRelation("Tags", new RelationOperand
            {
                Select = (id, otype) => GetThisRelatedModel<_TagLink>(new DummyEntity(id, otype)),
                Delete =
                    (id, otype, id2, otype2) =>
                    {
                        DeleteRelation<_TagLink>(new DummyEntity(id, otype),
                                           new DummyEntity(id2, otype2));
                        RebuildTagLinks(id, otype, id2, otype2);
                    },
                DeleteAll =
                    (id, otype) => 
                    {
                        var tags = GetRelated("Tags", id, otype).ToArray();
                        DeleteAllRelation<_TagLink>(new DummyEntity(id, otype));
                        RebuildTagLinks(tags.ToArray(), id, otype);
                    },
                Insert =
                    (id, otype, id2, otype2) =>
                    {
                        var linkedRubrics = DataServiceLocator.RubricService.GetRelated("Rubrics", id2, otype2).ToArray();


                        CreateRelation<_TagLink>(new DummyEntity(id, otype),
                                           new DummyEntity(id2, otype2));

                        CreateRelation<_TagRubricLink>(new DummyEntity(id, otype),
                                                                                   linkedRubrics);
                        
                    },
                    SelectBy = () => typeof(_TagLink)
            });
        }

        public void RebuildTagLinks(IDatabaseEntity[] _tags, long _taggedObjectId, string _taggedObjectType)
        {
            foreach (var tag in _tags)
            {
                RebuildTagLinks(tag.Id, tag.ObjectType, _taggedObjectId, _taggedObjectType);
            }
        }

        public void RebuildTagLinks(long _tagId, string _tagOtype, long _taggedObjectId, string _taggedObjectType)
        {
            // TODO: is not very fast thing

            var rubrics = DataServiceLocator.RubricService.GetRelated("Rubrics", _taggedObjectId, _taggedObjectType);

            foreach (var rubric in rubrics)
            {
                var thisRubricLinkCount =
                    DataContext.GetTable<_RubricLink>().Where(s => s.REL_Id1.Equals(rubric.Id) && s.REL_ObjectType1.Equals(rubric.ObjectType))
                    .Join(DataContext.GetTable<_TagLink>(),
                    outer => new { id = outer.REL_Id2, otype = outer.REL_ObjectType2 },
                    inner => new { id = inner.REL_Id2, otype = inner.REL_ObjectType2 },
                    (outer, inner) => outer).Where(outer => outer.REL_Id1.Equals(_tagId) && outer.REL_ObjectType1.Equals(_tagOtype)).Count();

                if (thisRubricLinkCount == 0)
                {
                    DeleteRelation<_TagRubricLink>(new DummyEntity(_tagId, _tagOtype), new DummyEntity(rubric.Id, rubric.ObjectType));
                }
            }
        }


        public IEnumerable<TagObject> GetAllTags(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return GetAll();
            
            return GetAll().Where(t => t.Text.StartsWith(searchString));
        }

        public void SetTagUserSelection(IEnumerable<long> _ids)
        {
            return;
            var tags = GetAll().Where(s => _ids.Contains(s.Id)).ToArray();
            // TODO: DataService имеет доступ к HttpContext ?
            HttpContext.Current.Session.Remove("SelectionTags");
            HttpContext.Current.Session.Add("SelectionTags", tags);
        }

        public IEnumerable<TagObject> GetTagUserSelection()
        {
            return new TagObject[] { };
            // TODO: DataService имеет доступ к HttpContext ?
            var obj = HttpContext.Current.Session["SelectionTags"] as IEnumerable<TagObject>;
            if (obj == null)
            {
                obj = new TagObject[] { };
            }
            return obj;
        }

        protected override System.Linq.Expressions.Expression<Func<Tag, bool>> GetEqualityComparer(TagObject b)
        {
            return (a) => a.Text.Equals(b.Text);
        }
    }
}
