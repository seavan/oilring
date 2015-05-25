using System.Reflection;
using Web.Common.Metadata;

namespace Web.Common.Validation
{
    public interface ICustomValidationParams 
    {
        bool ValidationRequired(PropertyInfo _thisProperty, object _parentObject = null);
        bool AttributeRequired(PropertyInfo _thisProperty, object _parentObject, ICustomValueProvider _valueProvider);
        bool ConvertNullToEmpty(PropertyInfo _thisProperty);
        bool ConvertEmptyToNull(PropertyInfo _thisProperty);
        string GetMissingMessage(PropertyInfo _prop);
        string GetInvalidFormatMessage(PropertyInfo _prop);
    }
}