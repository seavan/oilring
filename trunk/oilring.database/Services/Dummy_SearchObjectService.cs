
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Dummy_SearchObject
    File name: 	Dummy_SearchObject.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
namespace admin.db
{
    public partial class Dummy_SearchObjectService : IDummy_SearchObjectService
    {
        #region IDummy_SearchObjectService Members

        public IQueryable<IDatabaseEntity> SearchByTagId(long _tagId)
        {
            return DataContext.GetTable<_TagLink>().Where(s => s.REL_Id1.Equals(_tagId) && s.REL_ObjectType1.Equals("tag"))
                .Select(
                s =>
                new DummyEntity() { Id = s.REL_Id2, ObjectType = s.REL_ObjectType2 }).OrderByDescending( s => s.Id );
        }

        public IQueryable<IDatabaseEntity> SearchByRubricId(long _rubricId)
        {
            return DataContext.GetTable<_RubricLink>().Where(s => s.REL_Id1.Equals(_rubricId) && s.REL_ObjectType1.Equals("rubric"))
                .Select(
                s =>
                new DummyEntity() { Id = s.REL_Id2, ObjectType = s.REL_ObjectType2 }).OrderByDescending(s => s.Id);
        }

        #endregion
    }
}
