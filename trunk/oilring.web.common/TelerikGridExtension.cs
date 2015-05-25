using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.Mvc.UI.Fluent;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Web.Mvc.UI
{
    public static class TelerikGridExtension
    {
        public static IEnumerable<_T> ClearAssoc<_T>(this IEnumerable<_T> _from)
        {
            var props = typeof(_T).GetProperties();
            foreach(var prop in props)
            {
                if (prop.GetCustomAttributes(true).OfType<AssociationAttribute>().Count() > 0)
                {
                    var tgAssocProp = prop.Name.Replace("CL_", "").Replace("REF_", "") + "Name";
                    var assocProp = props.SingleOrDefault( s => s.Name == tgAssocProp );

                    foreach (var item in _from)
                    {
                        var oldVal = prop.GetValue(item, new object[] { });

                        prop.SetValue(item, null, new object[] { });

                        if( assocProp != null )
                        {
                            if (oldVal != null)
                            {
                                var val = oldVal.GetType().GetProperty("Name").GetValue(oldVal, new object[]{});
                                assocProp.SetValue(item, val, new object[] {});
                            }
                        }
                    }

                }
            }
            return _from;
        }

        public static GridBoundColumnBuilder<_T> Id<_T>(this GridBoundColumnBuilder<_T> _caller) where _T : class
        {
            return _caller.ClientTemplate(
                String.Format("<span class='_gridId' rel='<#= {0} #>'><#= {0} #></span>",
                              _caller.Column.Member)
                ).Title("Id");
        }

        public static GridBoundColumnBuilder<_T> Display<_T>(this GridBoundColumnBuilder<_T> _caller) where _T : class
        {
            return _caller.ClientTemplate(
                String.Format("<span class='_gridDisplay'><#= {0} #></span>",
                              _caller.Column.Member)
                ).Hidden(true);
        }

        public static GridBoundColumnBuilder<_T> Bool<_T>(this GridBoundColumnBuilder<_T> _caller) where _T : class
        {
            return _caller.ClientTemplate(
                String.Format("<input type='checkbox' name='cbx{0}' <#= {0}?\"checked\":\"\" #> disabled />",
                              _caller.Column.Member)
                );
        }

        public static GridBoundColumnBuilder<_T> Login<_T>(this GridBoundColumnBuilder<_T> _caller) where _T : class
        {
            return _caller.ReadOnly().Sortable(false).Title(" ").Width(80).ClientTemplate(
                String.Format(
                "<a class='_link t-button' href='http://Oilring.ru/Authentication/Autologin?Id=<#= {0} #>'>Войти</a>", _caller.Column.Member));
        }

        public static GridBoundColumnBuilder<_T> Edit<_T>(this GridBoundColumnBuilder<_T> _caller, string _controller) where _T : class
        {
            return _caller.ClientTemplate(
                String.Format("<a class='_link t-button' href='/{0}/{1}/<#= {2}#>' rel='<#= {2}#>'>Редактировать</a>",
                              _controller, "Single",
                              _caller.Column.Member)).Visible(true).HeaderTemplate("&nbsp;").Sortable(false).Filterable(false).Visible(true).Width(60);
                
        }

        public static GridBoundColumnBuilder<_T> EditFunction<_T>(this GridBoundColumnBuilder<_T> _caller, string _controller) where _T : class
        {
            return _caller.ClientTemplate(
                String.Format("<!-- <a href='/{0}/{1}/<#= {2}#>' rel='<#= {2}#>'>Редактировать</a><br/> --><a href='/{0}/CreateStep1/<#= {2}#>' rel='<#= {2}#>'>Шаг 1</a><br/><a href='/{0}/CreateStep2/<#= {2}#>' rel='<#= {2}#>'>Шаг 2</a><br/><a href='/{0}/CreateStep3/<#= {2}#>' rel='<#= {2}#>'>Шаг 3</a>",
                              _controller, "Single",
                              _caller.Column.Member)).Width(100).Visible(true).HeaderTemplate("&nbsp").Sortable(false).Filterable(false);

        }

    }
}