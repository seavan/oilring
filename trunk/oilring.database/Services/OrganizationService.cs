
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Organization
    File name: 	Organization.service.cs
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
    public partial class OrganizationService
    {
        public OrganizationService()
        {
            RegisterManyToManyRelation<_OrganizationLink>("Organizers");
            RegisterManyToManyRelation<_OrganizationMemberLink>("OrganizationMembers");
        }

        public IEnumerable<OrganizationObject> GetAllOrganizations(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return GetAll().OrderBy(u => u.Title);

            List<OrganizationObject> orgs = new List<OrganizationObject>();
            var words = searchString.Split(' ');

            var allOrg = GetAll();
            var listName = allOrg.Select(n => n.Title).ToList();
            int startRange = 0;
            List<string> temp;
            foreach (var word in words)
            {
                /*startRange = orgs.Count();
                temp = listName.Where(a => a.ClearText().StartsWith(word.ClearText())).ToList();
                orgs.InsertRange(startRange, allOrg.Where(u => temp.Contains(u.Title)));*/
                allOrg = allOrg.Where( s => s.Title.Contains(word));
            }

            return allOrg.ToArray().OrderBy(u => u.Title);
        }
    }
}
