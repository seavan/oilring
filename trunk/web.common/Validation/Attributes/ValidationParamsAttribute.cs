using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Web.Common.Metadata;

namespace Web.Common.Validation.Attributes
{
    /// <summary>
    /// TODO: Почему это атрибут??? Используется только в качестве имплементации ICustomValidationParams
    /// </summary>
    public class ValidationParamsAttribute : Attribute, ICustomValidationParams
    {
        public ValidationParamsAttribute()
        {
            IsValidated = true;
            IsRequired = false;
            IsConvertNullToEmpty = true;
            IsConvertEmptyToNull = false;
        }

        public bool IsRequired { get; set; }
        public bool IsValidated { get; set; }
        public bool IsConvertNullToEmpty { get; set; }
        public bool IsConvertEmptyToNull { get; set; }


        #region ICustomValidationParams Members

        public bool ValidationRequired(PropertyInfo _thisProperty, object _object = null)
        {
            return true;
        }

        public bool ConvertNullToEmpty(PropertyInfo _thisProperty)
        {
            return true;
        }

        public bool ConvertEmptyToNull(PropertyInfo _thisProperty)
        {
            return false;
        }

        public bool AttributeRequired(PropertyInfo _thisProperty, object _parentObject, ICustomValueProvider _valueProvider)
        {
            if (IsRequired) return true;
            var ra = _thisProperty.GetSingleAttribute<RequiredAttribute>();
            var cra = _thisProperty.GetSingleAttribute<ConditionalRequiredAttribute>();
            if( (cra != null) && (cra.FieldNames != null) && (cra.FieldNames.Length > 0))
            {
                var type = _parentObject.GetType();
                foreach (var f in cra.FieldNames)
                {
                    var p = _valueProvider.GetPropertyParam(f);
                    if ((p != null) && (p.ToString().Length > 0))
                    {
                        return true;
                    }
                }
            }

            return (ra != null);
        }

        public string GetMissingMessage(PropertyInfo _prop)
        {

            var ra = _prop.GetSingleAttribute<RequiredAttribute>();
            if (ra != null) return ra.FormatErrorMessage(_prop.Name);

            var disp = _prop.GetSingleAttribute<DisplayAttribute>();

            return String.Format("Поле обязательно для заполнения", disp != null ? disp.Name : _prop.Name);
        }

        public string GetInvalidFormatMessage(PropertyInfo _prop)
        {
            var disp = _prop.GetSingleAttribute<DisplayAttribute>();

            return String.Format("Неправильный формат для поля {0}", disp != null ? disp.Name : _prop.Name);
        }

        #endregion
    }
}