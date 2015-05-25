using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notamedia.Oilring.Community.Metadata.Attributes
{
    public class RestrictedHtmlAttribute : Attribute, IMetadataAttribute
    {
        public const string ALLOW_RESTRICTED = "AllowRestricted";

        public void Process(System.Web.Mvc.ModelMetadata _modelMetaData)
        {
            _modelMetaData.AdditionalValues.Add(ALLOW_RESTRICTED, true);
        }
    }
}