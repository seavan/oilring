using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Common.IoC;

namespace Web.Common.IoC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        protected void SetDefaultAssembly(Assembly _asm)
        {
            m_Postfix = ", " + _asm.FullName;
        }

        private string m_Postfix = "";


        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController controller;
            var cnt = reqContext.RouteData.Values["controller"].ToString();
            if (cnt.IndexOf('.') != -1)
            {
                try
                {
                    controllerType = Type.GetType(cnt + m_Postfix);
                    /*if (controllerType == null)
                    {
                        controllerType = Type.GetType(cnt);
                    }*/
                    controller = MvcUnityContainer.Container.Resolve(controllerType) as IController;
                    reqContext.RouteData.Values["controller"] = controllerType.Name.Replace("Controller", "");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(String.Format("Error resolving controller {0}", controllerType.Name), ex);
                }
                return controller;
            }

            if (controllerType == null)
                throw new HttpException(404, String.Format("The controller for path '{0}' could not be found or it does not implement IController.", reqContext.HttpContext.Request.Path));

            try
            
            {
                controller = MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Error resolving controller {0}", controllerType.Name), ex);
            }
            return controller;
        }
    }
}