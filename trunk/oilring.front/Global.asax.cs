using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Microsoft.Practices.Unity;
using System.Web.Configuration;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Configuration;
using Elmah;

using Notamedia.Oilring.Database;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using System.IO;
using admin.db.Updaters;
using Database.Interfaces;
using Database.Implementation;
using Database;
using Common.IoC;
using Web.Common.Metadata;
using Web.Common.IoC;
using Web.Common.Html;
using oilring.web.common.Html;

namespace Notamedia.Oilring.Community
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {


        public static void RegisterRoutes(RouteCollection routes)
        {
            // Make sure MVC is handling every request for static files
            routes.RouteExistingFiles = false;

            // Don't process routes where actual static resources live
            routes.IgnoreRoute("Сontent/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("elmah.axd");

            routes.MapRoute(
                            "AutomaticList", // Route name
                            "{Lang}/{controller}/List/{page}", new { Lang = "ru", action = "List", page = 1 }, new string[] { "Notamedia.Oilring" } // URL with parameters
                           );

            routes.MapRoute(
                            "Automatic", // Route name
                            "{Lang}/{controller}/{action}/{id}", new { Lang = "ru", id = UrlParameter.Optional }, new string[] { "Notamedia.Oilring" } // URL with parameters
                           );

            routes.MapRoute(
                            "AutomaticList3", // Route name
                            "{Lang}/{controller}/{page}", new { Lang = "ru", action = "List", page = 1 }, new string[] { "Notamedia.Oilring" } // URL with parameters
                           );

            routes.MapRoute(
                "DefaultLang", // Route name
                "{Lang}", // URL with parameters
                new { Lang = "ru", controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{Lang}/{controller}/{action}/{id}", // URL with parameters
                new { Lang = "ru", controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "CatchAll",
                "{*url}",
                new
                {
                    controller = "Home",
                    action = "Error404"
                });

        }

        public bool StaticFileRequest
        {
            get { return File.Exists(Server.MapPath(Request.AppRelativeCurrentExecutionFilePath)); }
        }

        protected void Application_BeginRequest()
        {
            var lang = HttpContext.Current.Request.RequestContext.RouteData.Values["Lang"];
            if (lang == null)
            {
                lang = "ru";
            }
            if (HttpContext.Current.Request.AcceptTypes.ToList().IndexOf("text/html") != -1)
            {
                if ( (!StaticFileRequest))
                {
                    WebTraceContext.INST.Trace("<b>Application - " + OilringExtension.VersionInfo() + "</b>");
                    WebTraceContext.INST.Trace("Begin request");
                    
                }
            }
        }

        protected void Application_EndRequest()
        {
            return;
            if (HttpContext.Current.Request.AcceptTypes.ToList().IndexOf("text/html") != -1)
            {
                if (Request.IsLocal && !StaticFileRequest && (!HttpContext.Current.Items.Contains("X-Disable-Profiling")))
                {

                    var s = WebTraceContext.INST.Finalize();
                    HttpContext.Current.Response.Write(
                        "<pre style='background: white; padding: 20px; border-top: 2px dotted silver'>");
                    HttpContext.Current.Response.Write(s);
                    HttpContext.Current.Response.Write("</pre>");
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            ModelMetadataProviders.Current = new CustomMetadataProvider();
            // регистрируем валидаторы
//            RegisterValidators();

            ConfigureUnity();
        }


        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (!StaticFileRequest && (Context.User != null))
            {
                var ds = MvcUnityContainer.Container.Resolve<IDataServiceLocator>();
                Context.User = ds.UserService.GetPrincipal();
            }
        }
        
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (String.Compare(custom, "browser") == 0)
            {
                return User.Identity.Name;
            }
            return base.GetVaryByCustomString(context, custom);
        }

        private void ConfigureUnity()
        {
            //Create UnityContainer          
            IUnityContainer result = new UnityContainer();
            result
            .RegisterInstance<IDataStore>(new DataStore())
            .RegisterType<IDataServiceLocator, DataServiceLocator>(new ContainerControlledLifetimeManager())
            .RegisterInstance<UniversalUpdater>(new OilringUpdater())
            .RegisterType<TraceDataContext, WebTraceContext>("WebTraceContext", new HttpContextLifetimeManager<WebTraceContext>(), new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Oilring"].ConnectionString))
            .RegisterType<IControlRenderer, OilringControlRenderer>()
            ;

            MvcUnityContainer.Container = result;
            var ds = result.Resolve<IDataServiceLocator>();

            //Set Controller Factory as UnityControllerFactory
            ControllerBuilder.Current.SetControllerFactory(typeof(CommunityControllerFactory));

            string filesLocalUploadPath = ConfigurationManager.AppSettings["filesLocalUploadPath"];
            ds.FileAttachmentService.SetTargetDirectories(new string[] { filesLocalUploadPath });

            ds.PhotoService.SetTargetDirectories(
                new string[] { ConfigurationManager.AppSettings["imagesLocalUploadPath"] });
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Request.IsLocal) return;
            HttpContext oHttpContext;
            Exception oException;

            oHttpContext = HttpContext.Current;

            oException = oHttpContext.Server.GetLastError();
            
            
            if (oException is HttpException)
            {
                switch ((oException as HttpException).GetHttpCode())
                {
                    case 500:
                        oHttpContext.Response.StatusCode = 404;
                        oHttpContext.Response.StatusDescription = "Not Found";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Response.Redirect("~/ru/Home/Error404");

                        oHttpContext.Server.ClearError();

                        break;

                    case 404:

                        oHttpContext.Response.StatusCode = 404;
                        oHttpContext.Response.StatusDescription = "Not Found";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Response.Redirect("~/ru/Home/Error404");

                        oHttpContext.Server.ClearError();

                        break;

                    case 403:

                        oHttpContext.Response.StatusCode = 403;
                        oHttpContext.Response.StatusDescription = "Forbidden";
                        oHttpContext.Response.Charset = "windows-1251";
                        //oHttpContext.Response.Redirect("~/ru/Home/Error403");
                        var UrlReturn = oHttpContext.Request.AppRelativeCurrentExecutionFilePath;
                        oHttpContext.Response.Redirect("~/ru/User/SignIn?UrlReturn=" + UrlReturn);

                        oHttpContext.Server.ClearError();

                        break;
                }
            }
        }
        void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            Filter(e);
        }

        void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            Filter(e);
        }
        void Filter(ExceptionFilterEventArgs args)
        {
            if (args.Exception.GetBaseException() is ArgumentException)
            {
                args.Dismiss();
            }
        }
    }
}