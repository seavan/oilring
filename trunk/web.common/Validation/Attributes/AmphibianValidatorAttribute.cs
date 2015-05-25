using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class AmphibianValidatorAttribute : Attribute
    {
        //        public string JsValidatorName { get; set; }
        //public string JsEncodedValidatorParams { get; }

        /*        private SortedList<string, string> m_JsParams = new SortedList<string, string>();

                protected void AddParam(string name, object _value)
                {
                    m_JsParams[name] = _value.ToString();
                }
        */
    }


}
