using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Web.Common.Validation;

namespace Web.Common.Validation
{
    public class WebModelValidator : CustomModelValidator
    {
        public WebModelValidator()
        {
        }

        public override object GetPropertyParam(string _paramName)
        {
            return HttpContext.Current.Request.Form[_paramName];   
        }
    }
}
