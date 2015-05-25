	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Univer
	File name: 	User_Univer.service.cs
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
  public partial class User_UniverService
  {
      public IEnumerable<string> GetAllUnivers(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Select(u=>u.Title);

          return GetAll().Where(t => t.Title.StartsWith(searchString)).Select(u => u.Title);
      }

      public IEnumerable<string> GetAllFaculties(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Select(u => u.Faculty);

          return GetAll().Where(t => t.Faculty.StartsWith(searchString)).Select(u => u.Faculty);
      }

      public IEnumerable<string> GetAllDepartments(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Select(u => u.Department);

          return GetAll().Where(t => t.Department.StartsWith(searchString)).Select(u => u.Department);
      }

      public IEnumerable<string> GetAllGroups(string searchString)
      {
          if (string.IsNullOrEmpty(searchString)) return GetAll().Select(u => u.Group);

          return GetAll().Where(t => t.Group.StartsWith(searchString)).Select(u => u.Group);
      }
  }
}	
