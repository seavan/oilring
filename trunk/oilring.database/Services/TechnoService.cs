
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Techno
    File name: 	Techno.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using Database.Implementation;
namespace admin.db
{
    public partial class TechnoService : DataService<Techno, TechnoObject, TechnoObject.Converter>, ITechnoService
    {
        public TechnoService()
        {
            RegisterManyToManyRelation<_ObjectAuthorLink>("TechnoAuthorObject", null, true);
        }
    }
}
