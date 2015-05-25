	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Organization
	File name: 	Organization.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Web;
using Elmah;

namespace Notamedia.Oilring
{
    public class OrganizationController : admin.web.common.OrganizationController
    {
        protected IOrganizationService m_OrganizationService;

        private IOrganizationService OrganizationService
        {
            get
            {
                if (m_OrganizationService == null)
                {
                    m_OrganizationService = GetService() as IOrganizationService;
                }

                return m_OrganizationService;
            }
        }

        public string AutoCompleteSearch(string searchString)
        {
            var orgs = OrganizationService.GetAllOrganizations(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Title, Additional = "", Icon = u.SmallAvatar });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(orgs);
        }

        public ActionResult GetHtmlItemList(long searchId)
        {
            var org = OrganizationService.GetById(searchId);
            if (org != null) return PartialView("ListItemForEdit", org);

            return null;
        }
        public ActionResult SearchHtmlItemList(string searchName)
        {
            return null;
        }
    }
}	
