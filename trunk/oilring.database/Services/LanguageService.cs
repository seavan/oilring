	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Language
	File name: 	Language.service.cs
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
    public partial class LanguageService 
    {
      public LanguageService()
      {
          RegisterManyToManyRelation<_LanguageLink>("UserLanguage");
      }
    }
}	
