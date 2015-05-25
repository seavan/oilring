	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Seminar
	File name: 	Seminar.service.cs
*/
		

using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
namespace admin.db
{
  public partial class SeminarService
  {
      public SeminarService()
      {
          RegisterManyToManyRelation<_ObjectAuthorLink>("SeminarAuthorObject", null, true);
      }

      protected override void InitItem(SeminarObject _item)
      {
          base.InitItem(_item);
          _item.REL_Id = 0;
          _item.REL_ObjectType = null;
      }
      public IEnumerable<SeminarObject> GetAllSeminars(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().OrderBy(u => u.Title);

          List<SeminarObject> orgs = new List<SeminarObject>();
          //var words = searchString.Split(' ');

          var allOrg = GetAll();
          var listName = allOrg.Select(n => n.Title).ToList();
          int startRange = 0;
          List<string> temp;
          //foreach (var word in words)
          //{
              startRange = orgs.Count();
              temp = listName.Where(a => a.ClearText().StartsWith(searchString.ClearText())).ToList();
              orgs.InsertRange(startRange, allOrg.Where(u => temp.Contains(u.Title)));
          //}

          return orgs.Distinct().OrderBy(u => u.Title);
      }
      public IEnumerable<SeminarObject> GetAllCycleSeminars(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Where(s=>s.IsCycle).OrderBy(u => u.Title);

          List<SeminarObject> orgs = new List<SeminarObject>();
          //var words = searchString.Split(' ');

          var allOrg = GetAll().Where(s => s.IsCycle);
          var listName = allOrg.Select(n => n.Title).ToList();
          int startRange = 0;
          List<string> temp;
          //foreach (var word in words)
          //{
              startRange = orgs.Count();
              temp = listName.Where(a => a.ClearText().StartsWith(searchString.ClearText())).ToList();
              orgs.InsertRange(startRange, allOrg.Where(u => temp.Contains(u.Title)));
          //}

          return orgs.Distinct().OrderBy(u => u.Title);
      }
  }
}	
