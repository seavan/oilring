	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Rubric
	File name: 	Rubric.controller.cs
 * 
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using System.Web;

namespace Notamedia.Oilring
{
    public class RubricController : admin.web.common.RubricController
    {
        public RubricController()
        {

        }

        protected IRubricService m_RubricService;
        
        private IRubricService RubricService
        {
            get
            {
                if (m_RubricService == null)
                {
                    m_RubricService = GetService() as IRubricService;
                }

                return m_RubricService;
            }
        }

        public ActionResult GetRubricList()
        {           
            var jsonSerializer = new JavaScriptSerializer();
            return Content(jsonSerializer.Serialize(RubricService.GetAllRubrics()));
        }
        
        public string GetRubricListScript()
        {
            Request.RequestContext.HttpContext.Items.Add("X-Disable-Profiling", true);

            var jsonSerializer = new JavaScriptSerializer();
            StringBuilder builder = new StringBuilder();
            builder.Append("var RUBRICS = ");
            builder.Append(jsonSerializer.Serialize(RubricService.GetAllRubrics()));
            builder.Append(";");
            return builder.ToString();
        }


        public void SetSelectRubrics(List<long> IDs, List<long> TagIDs)
        {
            if (IDs != null)
            {
                HttpCookie userRubricCookie = Request.Cookies["UserSelectedRubrics"];
                
                if (Request.IsAuthenticated)
                {
                    if (userRubricCookie != null)
                    {
                        userRubricCookie.Expires = DateTime.Now.AddDays(-1);
                        userRubricCookie.Domain = Request.ServerVariables["HTTP_HOST"];
                        Response.Cookies.Add(userRubricCookie);
                    }
                    
                    RubricService.SetUserRubrics(IDs, ((UserPrincipal) User).CurrentUser);
                }
                else
                {
                    var jsonSerializer = new JavaScriptSerializer();
                    if (userRubricCookie == null)
                    {
                        HttpCookie newCookie = new HttpCookie("UserSelectedRubrics", jsonSerializer.Serialize(IDs));
                        newCookie.Domain = Request.ServerVariables["HTTP_HOST"];
                        //newCookie.Expires = DateTime.Now.AddMinutes(1);
                        Response.Cookies.Add(newCookie);
                    }
                    else
                    {
                        userRubricCookie.Value = jsonSerializer.Serialize(IDs);
                        userRubricCookie.Domain = Request.ServerVariables["HTTP_HOST"];
                        Response.Cookies.Add(userRubricCookie);
                    }
                }
            }

            if (TagIDs != null)
            {
                DataServiceLocator.TagService.SetTagUserSelection(TagIDs);
            }
        }

        public ActionResult MyChoice()
        {
            if (Request.IsAuthenticated)
            {
                return View(RubricService.GetSelectedRubrics(((UserPrincipal)User).CurrentUser));
            }
            else
            {
                HttpCookie userRubricCookie = Request.Cookies["UserSelectedRubrics"];
                if (userRubricCookie != null)
                {
                    var jsonSerializer = new JavaScriptSerializer();
                    List<long> IDs = jsonSerializer.Deserialize<List<long>>(userRubricCookie.Value);
                    return View(RubricService.GetSelectedRubrics(IDs));
                }
                else
                {
                    return View();
                }
            }
        }
    }
}	
