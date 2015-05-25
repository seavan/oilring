	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Seminar
	File name: 	Seminar.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace Notamedia.Oilring
{
    public class SeminarController : admin.web.common.SeminarController
    {
        protected ISeminarService m_SeminarService;

        private ISeminarService SeminarService
        {
            get
            {
                if (m_SeminarService == null)
                {
                    m_SeminarService = GetService() as ISeminarService;
                }

                return m_SeminarService;
            }
        }

        public string AutoCompleteSearchCycle(string searchString)
        {
            var tags = SeminarService.GetAllCycleSeminars(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Title, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }

        public ActionResult GetHtmlItemList(long searchId)
        {
            var seminar = SeminarService.GetById(searchId);
            if (seminar != null) return PartialView("ItemForEdit", seminar);

            return null;
        }

        public ActionResult SearchHtmlItemList(string searchName)
        {
            return null;
        }
    }
}	
