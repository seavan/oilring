using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notamedia.Oilring.Community.Filters
{
    /// <summary>
    /// http://forums.asp.net/p/1546774/3782468.aspx
    /// </summary>
    public class ConvertEnumOptionalValuesAttribute : ActionFilterAttribute
    {
        private static readonly Type[] enumBaseTypes = new[]
        { 
            typeof(byte), 
            typeof(int), 
            typeof(long), 
            typeof(sbyte), 
            typeof(short), 
            typeof(uint), 
            typeof(ulong), 
            typeof(ushort) 
        };

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var parameter in filterContext.ActionDescriptor.GetParameters())
            {
                if (parameter.ParameterType.IsEnum)
                {
                    var value = filterContext.ActionParameters[parameter.ParameterName];

                    if (value != null)
                    {
                        var valueType = value.GetType();

                        if (enumBaseTypes.Contains(valueType))
                        {
                            filterContext.ActionParameters[parameter.ParameterName] = Enum.ToObject(parameter.ParameterType, value);
                        }
                    }
                }
            }
        }
    }   
}