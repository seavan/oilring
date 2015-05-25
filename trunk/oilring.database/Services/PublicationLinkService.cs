
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	PublicationLink
    File name: 	PublicationLink.service.cs
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
    public partial class PublicationLinkService : DataService<PublicationLink, PublicationLinkObject, PublicationLinkObject.Converter>, IPublicationLinkService
    {
        public PublicationLinkService()
        {
            RegisterManyToManyRelation<_PublicationLink>("PublicationLinks");
        }
    }
}
