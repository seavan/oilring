using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using Common.IoC;
using Database.Interfaces;


namespace Web.Common.Controllers
{
    /// <summary>
    /// TODO: смысл?
    /// </summary>
    public class BasicController : Controller
    {
        public BasicController()
        {
            MvcUnityContainer.Container.BuildUp(this);
        }
        
        [Dependency]
        public IDataStore DataStore
        {
            get;
            set;
        }

        public JsonResult JsonGet(object _data)
        {
            return Json(_data, JsonRequestBehavior.AllowGet);
        }



    }
}