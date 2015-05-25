
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	OuterLink
    File name: 	OuterLink.service.cs
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
    public partial class OuterLinkService : DataService<OuterLink, OuterLinkObject, OuterLinkObject.Converter>, IOuterLinkService
    {
        public OuterLinkService()
        {
            RegisterManyToManyRelation<_OuterLink>("OuterLinks");

        }
    }
}
