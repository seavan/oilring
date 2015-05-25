	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Univer
	File name: 	User_Univer.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace Notamedia.Oilring
{
    public class User_UniverController : admin.web.common.User_UniverController
    {
        protected IUser_UniverService m_User_UniverService;

        private IUser_UniverService User_UniverService
        {
            get
            {
                if (m_User_UniverService == null)
                {
                    m_User_UniverService = GetService() as IUser_UniverService;
                }

                return m_User_UniverService;
            }
        }

        public ActionResult GetUserUniverForm()
        {
            User_UniverObject obj = new User_UniverObject
            {
                Id = 0,
                ObjectType = "user_univer"
            };

            return PartialView("ListItemForEdit", obj);
        }

        public string AutoCompleteSearchUniver(string searchString)
        {
            var tags = User_UniverService.GetAllUnivers(searchString).Select(u => new RequestsAutoComplete { Id = "", Title = u, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }
        public string AutoCompleteSearchFaculty(string searchString)
        {
            var tags = User_UniverService.GetAllFaculties(searchString).Select(u => new RequestsAutoComplete { Id = "", Title = u, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }
        public string AutoCompleteSearchDepartment(string searchString)
        {
            var tags = User_UniverService.GetAllDepartments(searchString).Select(u => new RequestsAutoComplete { Id = "", Title = u, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }
        public string AutoCompleteSearchGroup(string searchString)
        {
            var tags = User_UniverService.GetAllGroups(searchString).Select(u => new RequestsAutoComplete { Id = "", Title = u, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }
    }
}	
