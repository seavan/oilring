using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Metadata
{
    public interface ICustomValueProvider
    {
        object GetPropertyParam(string _paramName);
    }
}
