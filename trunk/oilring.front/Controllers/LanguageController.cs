	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Language
	File name: 	Language.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Linq;

namespace Notamedia.Oilring
{
    public class LanguageController : admin.web.common.LanguageController
    {
        protected ILanguageService m_LanguageService;

        private ILanguageService LanguageService
        {
            get
            {
                if (m_LanguageService == null)
                {
                    m_LanguageService = GetService() as ILanguageService;
                }

                return m_LanguageService;
            }
        }

        [OutputCache(Duration=2000, VaryByParam="none")]
        public  ActionResult GetLanguageForm()
        {
            return PartialView("ListForEdit", LanguageService.GetAll().ToArray().OrderBy(l=>l.Title));
        }
    }
}	
