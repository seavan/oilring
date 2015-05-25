using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Metadata;

namespace Web.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EqualityValidator : Attribute, ICustomValidator
    {
        public string[] FieldNames { get; set; }

        #region ICustomValidator Members

        public bool IsValid(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            if ((FieldNames == null) || (FieldNames.Length == 0)) return true;
            foreach (var f in FieldNames)
            {
                if (!_value.Equals(_valueProvider.GetPropertyParam(f))) return false;
            }

            return true;
        }

        public string GetMessage(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            return "Значения полей должны совпадать";
        }

        #endregion
    }
}
