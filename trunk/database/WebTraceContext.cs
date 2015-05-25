using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Linq;
using Microsoft.Practices.Unity;
using Database;
using Common.IoC;

namespace Database
{
    public class WebTraceContext : TraceDataContext
    {
        public WebTraceContext(string _connection) : base(_connection)
        {
        }

        public static WebTraceContext INST
        {
            get {
                return MvcUnityContainer.Container.Resolve<TraceDataContext>("WebTraceContext") as WebTraceContext;
            }
        }
    }
}
