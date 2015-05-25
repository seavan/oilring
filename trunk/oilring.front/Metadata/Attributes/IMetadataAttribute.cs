using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Notamedia.Oilring.Community.Metadata.Attributes
{
    public interface IMetadataAttribute
    {
        void Process(ModelMetadata _modelMetaData);
    }
}
