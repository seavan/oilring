	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Grant
	File name: 	Grant.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Linq;

namespace Notamedia.Oilring
{
    public class GrantController : admin.web.common.GrantController
    {
        protected IGrantService m_GrantService;

        private IGrantService GrantService
        {
            get
            {
                if (m_GrantService == null)
                {
                    m_GrantService = GetService() as IGrantService;
                }

                return m_GrantService;
            }
        }

        public string AutoCompleteSearch(string searchString)
        {
            var grants = GrantService.GetAllGrants(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Number + " - " + u.Title, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(grants);
        }

        public ActionResult GetHtmlItemList(long searchId)
        {
            var grant = GrantService.GetById(searchId);
            if (grant != null) return PartialView("ListItemForEdit", grant);

            return null;
        }
        public ActionResult SearchHtmlItemList(string searchName)
        {
            var grant = GetAll().Where(g => g.Number.ToString() == searchName).FirstOrDefault();
            if (grant != null) return PartialView("ListItemForEdit", grant);

            return null;
        }
    }
}	
