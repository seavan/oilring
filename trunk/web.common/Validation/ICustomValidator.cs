using System.Reflection;
using Web.Common.Metadata;

namespace Web.Common.Validation
{
    public interface ICustomValidator
    {
        bool IsValid(PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider);

        string GetMessage(PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider);
    }

}