	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Journal
	File name: 	Journal.service.cs
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
  public partial class JournalService
  {
      public IEnumerable<JournalObject> GetAllJournal(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll();

          List<JournalObject> orgs = new List<JournalObject>();
          var words = searchString.Split(' ');

          var allOrg = GetAll();
          var listName = allOrg.Select(n => n.Title).ToList();
          int startRange = 0;
          List<string> temp;
          foreach (var word in words)
          {
              startRange = orgs.Count();
              temp = listName.Where(a => a.ClearText().StartsWith(word.ClearText())).ToList();
              orgs.InsertRange(startRange, allOrg.Where(u => temp.Contains(u.Title)));
          }

          return orgs.Distinct().OrderBy(u => u.Title);
      }
  }
}	
