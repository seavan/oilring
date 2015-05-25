using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel;
using Microsoft.Security.Application;
using HtmlAgilityPack;
using System.IO;
using Notamedia.Oilring.Community.Metadata.Attributes;

namespace Notamedia.Oilring.Community.ModelBinders
{
    /// <summary>
    /// Этот ModelBinder позволяет использовать ограниченный набор html-тегов во входных параметрах.
    /// ValidateInput должен быть выключен
    /// </summary>
    public class RestrictedTagsBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, 
                                            PropertyDescriptor propertyDescriptor, object value)
        {
            if (!controllerContext.Controller.ValidateRequest)
            {
                string st = value as string;

                if (!String.IsNullOrWhiteSpace(st))
                {
                    if (propertyDescriptor.Attributes.OfType<RestrictedHtmlAttribute>().Count() > 0)
                    {
                        //Удаляем весь небезопасный HTML
                        st = Sanitizer.GetSafeHtmlFragment(st);

                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(st);

                        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a[@class=\"x_media\"]");

                        if (nodes != null)
                        {
                            // постобработка:
                            foreach (HtmlNode link in nodes)
                            {
                                // переименуем обратно
                                link.Attributes["class"].Value = "media";
                                // декодируем url, т.к. Sanitizer его зачем-то кодирует
                                link.Attributes["href"].Value = HttpUtility.HtmlDecode(link.Attributes["href"].Value);
                            }

                            StringWriter stringWriter = new StringWriter();
                            doc.Save(stringWriter);

                            value = stringWriter.ToString();
                        }
                    }
                    else
                    {
                        value = HttpUtility.HtmlEncode(value);
                    }
                }
            }

            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
}