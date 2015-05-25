using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using admin.db;
using Notamedia.Oilring.Database;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using Database;
using Database.Interfaces;
using Database.Implementation;
using Common.IoC;

namespace converter
{
    class Worker
    {
        public Worker()
        {
            ConfigureUnity();
        }

        private IDataServiceLocator m_DataStore;
        private TraceDataContext m_DataContext;

        private void ConfigureUnity()
        {
            //Create UnityContainer          
            IUnityContainer result = new UnityContainer();
            result.RegisterInstance<IDataStore>(new DataStore());
            result.RegisterInstance<TraceDataContext>("WebTraceContext", new WebTraceContext(ConfigurationManager.ConnectionStrings["Oilring"].ConnectionString));


            MvcUnityContainer.Container = result;

            //var ds = result.Resolve<OilringTraceContext>("WebTraceContext");
            m_DataStore = result.Resolve<IDataServiceLocator>();
            m_DataContext = result.Resolve<TraceDataContext>("WebTraceContext");

            //Set Controller Factory as UnityControllerFactory
            //            ControllerBuilder.Current.SetControllerFactory(typeof(CommunityControllerFactory));
        }

        public void CheckFilesToConvert()
        {
            var filesToConvert =
                m_DataStore.FileAttachmentService.GetAll().Where(
                    s => s.IsConversionRequired.HasValue && s.IsConversionRequired.Value).ToArray();

            foreach (var file in filesToConvert)
            {
                Console.WriteLine("Converting {0}", file.Guid);
                file.IsConversionInProgress = true;
                file.IsConversionRequired = false;
                m_DataStore.FileAttachmentService.Update(file);

                try
                {
                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    var fname = file.FullPath;

                    var oname = Path.GetTempFileName();

                    var ofname = (object)fname;
                    var ooname = (object)oname;
                    var oformat = (object)Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
                    var OFALSE = (object)false;
                    var OTRUE = (object)true;
                    var document = app.Documents.Open(ref ofname);
                    // document.Convert();
                    document.SaveAs(ref ooname, ref oformat);
                    document.Close(OFALSE);

                    var fileToRead = new FileStream(oname, FileMode.Open);
                    var streamReader = new StreamReader(fileToRead, Encoding.GetEncoding(1251));
                    var res = streamReader.ReadToEnd();

                    var regex1 = new Regex(@".*\<body.*?\>", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    var regex2 = new Regex(@"\</body.*?\>.*", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    res = regex1.Replace(res, "");
                    res = regex2.Replace(res, "");

                    file.Content = res;
                }
                catch (Exception)
                {
                    file.IsError = true;
                }
                finally
                {
                    file.IsConverted = true;
                    file.IsConversionInProgress = false;
                }
                m_DataStore.FileAttachmentService.Update(file);
                Console.WriteLine("Converting complete {0}", file.Guid);
            }
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            var worker = new Worker();

            while (true)
            {
                Console.WriteLine("Next Cycle");
                worker.CheckFilesToConvert();
                Thread.Sleep(15000);
            }
        }
    }
}
