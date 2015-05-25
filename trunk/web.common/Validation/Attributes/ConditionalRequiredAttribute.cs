using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ConditionalRequiredAttribute : Attribute
    {
        public string[] FieldNames { get; set; }
    }

}
