	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Job
	File name: 	User_Job.service.cs
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
  public partial class User_JobService
  {
      public IEnumerable<string> GetAllJobs(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Select(u => u.Title);

          return GetAll().Where(t => t.Title.StartsWith(searchString)).Select(u => u.Title);
      }
  }
}	
