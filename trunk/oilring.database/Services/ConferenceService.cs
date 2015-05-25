
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Conference
    File name: 	Conference.service.cs
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
    public partial class ConferenceService : DataService<Conference, ConferenceObject, ConferenceObject.Converter>, IConferenceService
    {
        public ConferenceService()
        {
            RegisterManyToManyRelation<_ObjectAuthorLink>("ConferenceAuthorObject", null, true);
        }
    }
}
