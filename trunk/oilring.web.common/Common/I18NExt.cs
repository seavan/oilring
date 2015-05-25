using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web
{
    public static class RES
    {
        static RES()
        {
            CONTENT_SERVER_URI = Configuration.WebConfigurationManager.AppSettings["contentServer"];
            STATIC_SERVER_URI = Configuration.WebConfigurationManager.AppSettings["staticServer"];
            SCRIPTS_SERVER_URI = Configuration.WebConfigurationManager.AppSettings["scriptsServer"];
            STATIC_CONTENT_URI = STATIC_SERVER_URI + "/";
            I_CONTENT_URI = STATIC_SERVER_URI + "/i/";
            IMAGE_CONTENT_URI = CONTENT_SERVER_URI + "/images/";
            FILE_CONTENT_URI = CONTENT_SERVER_URI + "/files/";
            BANNER_CONTENT_URI = CONTENT_SERVER_URI + "/banners/";
        }

        public static string IMAGE_CONTENT_URI { get; set; }
        public static string I_CONTENT_URI { get; set; }
        public static string FILE_CONTENT_URI { get; set; }
        public static string BANNER_CONTENT_URI { get; set; }
        public static string CONTENT_SERVER_URI { get; set; }
        public static string STATIC_SERVER_URI { get; set; }
        public static string SCRIPTS_SERVER_URI { get; set; }
        public static string STATIC_CONTENT_URI { get; set; }
    }

    public static class I18NExt
    {
        public static ILocale LC(this HtmlHelper _vc)
        {
            return LC(_vc.ViewContext);
        }
        public static ILocale LC(this ViewContext _vc)
        {
            return LC(_vc.Controller.ControllerContext.RouteData.Values);
        }

        public static ILocale LC(this Controller _controller)
        {
            return LC(_controller.ControllerContext.RouteData.Values);
        }

        public static ILocale LC(this RouteValueDictionary _rvd)
        {
            var lc = (HttpContext.Current.Items["_LOCALE"]) as ILocale;
            if (lc != null)
            {
                return lc;
            }
            else
            {
                var val = _rvd["Lang"];
                lc = val != null ? I18N.D[val.ToString()] : I18N.C;
                HttpContext.Current.Items["_LOCALE"] = lc;
                return lc;
            }
        }
        /*
        public static ILocale LC(this object _rvd)
        {
            return I18N.D.LC();
        } */
    }
}