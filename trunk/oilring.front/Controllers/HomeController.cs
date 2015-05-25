using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading;
using admin.web.common;
using Web.Common.Controllers;


namespace Notamedia.Oilring.Community.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchResult(string query = "")
        {
            return View((object)query);
        }

        [HttpGet]
        public ActionResult Error404()
        {
            //Response.StatusCode = 404;  
            return View();
        }

        [HttpGet]
        public ActionResult Error403()
        {
            //Response.StatusCode = 403;  
            return View();
        }

        [HttpGet]
        public ActionResult Error500()
        {
            //Response.StatusCode = 403;  
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
