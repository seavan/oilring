using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Configuration;
using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring.Database;
using admin.web.common;
using admin.db;
using System.Threading;
using System.Globalization;
using admin.db.Updaters;
using Common.IoC;
using Database;
using Database.Implementation;
using Database.Interfaces;
using Web.Common.Metadata;
using Web.Common.IoC;
using Web.Common.Html;
using oilring.web.common.Html;

namespace admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Make sure MVC is handling every request for static files
            //routes.RouteExistingFiles = true;

            // Don't process routes where actual static resources live
            routes.IgnoreRoute("Сontent/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "AccountActivation", // Route name
                "Accounting/Activate/{email}/{activationKey}", // URL with parameters
                new { controller = "Accounting", action = "Activate" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{Id}", // URL with parameters
                new { controller = "AdminHome", action = "Index", id = UrlParameter.Optional }, new string[] { "admin" } // Parameter defaults
            );

        }

        protected void Application_BeginRequest()
        {
            Thread.CurrentThread.CurrentCulture
              = CultureInfo.CreateSpecificCulture("ru-RU");
        }
        

        protected void Application_Start()
        {
            AjaxHelper.GlobalizationScriptPath =
  "http://ajax.microsoft.com/ajax/4.0/1/globalization/";

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);


            ModelMetadataProviders.Current = new CustomMetadataProvider();

            ConfigureUnity();
        }

        private void ConfigureUnity()
        {
            //Create UnityContainer          
            IUnityContainer result = new UnityContainer();
            result
            .RegisterInstance<IDataStore>(new DataStore())
            .RegisterType<IDataServiceLocator, DataServiceLocator>(new ContainerControlledLifetimeManager())
            .RegisterInstance<UniversalUpdater>(new OilringUpdater())
            .RegisterType<TraceDataContext, WebTraceContext>("WebTraceContext", 
                                                             new HttpContextLifetimeManager<WebTraceContext>(), new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Oilring"].ConnectionString))
            .RegisterType<IControlRenderer, OilringControlRenderer>()
            ;

            MvcUnityContainer.Container = result;
            var ds = result.Resolve<IDataServiceLocator>();

            //Set Controller Factory as UnityControllerFactory
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));

            string filesLocalUploadPath = ConfigurationManager.AppSettings["filesLocalUploadPath"];
            ds.FileAttachmentService.SetTargetDirectories(new string[] { filesLocalUploadPath });
        }
    }
}