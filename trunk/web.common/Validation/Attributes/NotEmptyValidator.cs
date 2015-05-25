using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Metadata;

namespace Web.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class NotEmptyValidator : Attribute, ICustomValidator
    {
        #region ICustomValidator Members

        public bool IsValid(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            return _value.ToString().Length > 0;
        }

        public string GetMessage(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            return "Поле не может быть пустым";
        }

        #endregion
    }
}
