using Microsoft.Practices.Unity;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Community;
using admin.db;
using System.Web.Mvc;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System;
using System.Net.Mail;
using System.IO;
using Database.Interfaces;
using Database.Implementation;
using Database;
using Common.IoC;

namespace mailer
{
    public class Mailer
    {
        public Mailer()
        {
            ConfigureUnity();
        }

        private IDataStore m_DataStore;
        private TraceDataContext m_DataContext;


        private void ConfigureUnity()
        {
            //Create UnityContainer          
            IUnityContainer result = new UnityContainer();
            result
                // контекст данных со временем жизни в рамках http-запроса
                //            .RegisterType<OilringContext>("Context", new HttpContextLifetimeManager<OilringContext>(),
                //                                                  new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Oilring"].ConnectionString))
                //            .RegisterType<MailDataContext>("MailContext", new HttpContextLifetimeManager<MailDataContext>(),
                //                                                    new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Mail"].ConnectionString))

//            .RegisterType<VideoContext, VideoContext>("VideoContext", new HttpContextLifetimeManager<MailDataContext>(), new InjectionConstructor(ConfigurationManager.ConnectionStrings["Video"].ConnectionString))
            .RegisterInstance<IDataStore>(new DataStore());

            result.RegisterInstance<TraceDataContext>("WebTraceContext", new WebTraceContext(ConfigurationManager.ConnectionStrings["Oilring"].ConnectionString));


            MvcUnityContainer.Container = result;

            //var ds = result.Resolve<OilringTraceContext>("WebTraceContext");
            m_DataStore = result.Resolve<IDataStore>();
            m_DataContext = result.Resolve<TraceDataContext>("WebTraceContext");

//            m_DataStore.PhotoService.SetTargetDirectories(
//                new string[] { OUTPUT_IMAGE_DIR, REMOTE_IMAGE_DIR, LOCAL_IMAGE_DIR});
            //Set Controller Factory as UnityControllerFactory
            ControllerBuilder.Current.SetControllerFactory(typeof(CommunityControllerFactory));
        }


    }
}