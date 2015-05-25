	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Journal
	File name: 	Journal.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace Notamedia.Oilring
{
    public class JournalController : admin.web.common.JournalController
    {
        protected IJournalService m_JournalService;

        private IJournalService JournalService
        {
            get
            {
                if (m_JournalService == null)
                {
                    m_JournalService = GetService() as IJournalService;
                }

                return m_JournalService;
            }
        }

        public string AutoCompleteSearch(string searchString)
        {
            var grants = JournalService.GetAllJournal(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Title, Additional = "", Icon = u.Image });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(grants);
        }
    }
}	
