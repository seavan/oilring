using System.Globalization;

namespace Web.Common.Validation.Parsers
{
    public interface ICustomParser
    {
        bool TryParse(object _value, out object _result);
    }
}