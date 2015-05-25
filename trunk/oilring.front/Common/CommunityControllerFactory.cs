using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using admin.web.common;
using System.Reflection;
using Web.Common.IoC;

namespace Notamedia.Oilring.Community
{
    public class CommunityControllerFactory : UnityControllerFactory
    {
        public CommunityControllerFactory()
        {
            SetDefaultAssembly(Assembly.GetExecutingAssembly());
        }
    }
}