	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Job
	File name: 	User_Job.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace Notamedia.Oilring
{
    public class User_JobController : admin.web.common.User_JobController
    {
        protected IUser_JobService m_User_JobService;

        private IUser_JobService User_JobService
        {
            get
            {
                if (m_User_JobService == null)
                {
                    m_User_JobService = GetService() as IUser_JobService;
                }

                return m_User_JobService;
            }
        }

        public ActionResult GetUserJobForm()
        {
            User_JobObject obj = new User_JobObject
            {
                Id = 0,
                ObjectType = "user_job"
            };

            return PartialView("ListItemForEdit", obj);
        }

        public string AutoCompleteSearchJob(string searchString)
        {
            var tags = User_JobService.GetAllJobs(searchString).Select(u => new RequestsAutoComplete { Id = "", Title = u, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }
    }
}	
