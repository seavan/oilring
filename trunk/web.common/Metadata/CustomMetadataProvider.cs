using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Web.Common.Metadata
{
    public class CustomMetadataProvider : DataAnnotationsModelMetadataProvider
    {

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
                                                        Type containerType,
                                                        Func<object> modelAccessor,
                                                        Type modelType,
                                                        string propertyName)
        {
            
            ModelMetadata metadata = base.CreateMetadata(attributes,
                                                         containerType,
                                                         modelAccessor,
                                                         modelType,
                                                         propertyName);

            // Prefer [Display(Name="")] to [DisplayName]
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                string name = display.GetName();
                if (name != null)
                {
                    metadata.DisplayName = name;
                }

                // There was no 3.5 way to set these values
                metadata.Description = display.GetDescription();
                metadata.ShortDisplayName = display.GetShortName();
                metadata.Watermark = display.GetPrompt();
            }

            var validators = new List<string>();

            // Prefer [Editable] to [ReadOnly]
            EditableAttribute editable = attributes.OfType<EditableAttribute>().FirstOrDefault();
            if (editable != null)
            {
                metadata.IsReadOnly = !editable.AllowEdit;
            }

            // If [DisplayFormat(HtmlEncode=false)], set a data type name of "Html"
            // (if they didn't already set a data type)
            DisplayFormatAttribute displayFormat = attributes.OfType<DisplayFormatAttribute>().FirstOrDefault();
            if (displayFormat != null
                    && !displayFormat.HtmlEncode
                    && String.IsNullOrWhiteSpace(metadata.DataTypeName))
            {
                metadata.DataTypeName = DataType.Html.ToString();
            }

            var link =
                attributes.OfType<LinkAttribute>().FirstOrDefault();

            if( link != null )
            {
                metadata.AdditionalValues.Add("Link", link);
            }

            var wizard =
                attributes.OfType<WizardAttribute>().FirstOrDefault();

            if (wizard != null)
            {
                metadata.AdditionalValues.Add("Wizard", wizard);
            }

            var combo = attributes.OfType<ComboValuesAttribute>().FirstOrDefault();

            if (combo != null)
            {
                metadata.AdditionalValues.Add("Combo", combo);
            }

            return metadata;
        }
    }
}