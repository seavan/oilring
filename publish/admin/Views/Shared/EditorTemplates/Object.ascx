<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="_editor">
<% if (Model == null) { %>
    <%= ViewData.ModelMetadata.NullDisplayText %>
<% } else if (ViewData.TemplateInfo.TemplateDepth > 1) { %>
    <%= ViewData.ModelMetadata.SimpleDisplayText %>
<% } else { %>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 800px; margin: auto">
    <%
    var props = ViewData.ModelMetadata.Properties.Where(pm => pm.ShowForDisplay && !ViewData.TemplateInfo.Visited(pm));
    var step = ViewData["Step"];
    if (step != null)
        props = props.Where(pm => pm.AdditionalValues.SingleOrDefault(s => s.Key == "Wizard").Value != null).
            Where(
                pm =>
                (pm.AdditionalValues["Wizard"] as Web.Common.Metadata.WizardAttribute).Step == (int)step);
        %>
    <% foreach (var prop in props) {
    %>
        <% if (prop.HideSurroundingHtml) { %>
            <%= Html.Editor(prop.PropertyName) %>
        <% } else { %>
            <tr>
                <td style="width:100px; vertical-align: top">
                    <div class="display-label" style="text-align: right;">
                        <%= prop.GetDisplayName() %>
                    </div>
                </td>
                <td>
                    <div class="display-field _field">
                    <%
               var av = prop.AdditionalValues.FirstOrDefault(s => s.Key == "Link").Value as Web.Common.Metadata.LinkAttribute;
                        
                        
                        object key = null; 
                        if (av != null)
                        {
                            switch(av.LinkType)
                            {
                                case Web.Common.Metadata.LinkType.ltOneToOne: 
                                    break;

                                case Web.Common.Metadata.LinkType.ltOneToMany:
                                    key =
                                        ViewData.ModelMetadata.Properties.Single(ww => ww.PropertyName == av.ThisKeyName);
                                    %>
                                    <div class="_expanderCont">
                                        <span class="_apply">Применить</span>
                                        <span class="_expander">Изменить</span>
                                    </div>
                                    <span style="display: block; margin-bottom: 5px" class="_thisDisplay">
                                    <span class="_disabled"><%= Html.Editor(prop.PropertyName) %></span>
                                    </span>


                                    <span class="_foreign"></span>
                                    <input type="hidden" name="<%= av.ThisKeyName %>" class="_thisKey" value="<%= Html.Display(av.ThisKeyName) %>"/>
                                    <span class="_controller" style="display: none">/<%= av.Controller %>/<%= av.Template %></span>
                                    <%/* Html.Editor(prop.PropertyName, av.Template + "Display",  
                                        new { Link = av, Key = 
                                                          ViewData.ModelMetadata.Properties.Single(ww => ww.PropertyName == av.ThisKeyName).Model }) */ %>
                                    <%
                                    break;
                            }
                        }
                        else
                        {
%>
                        <%= !prop.IsReadOnly && prop.ShowForEdit ? Html.Editor(prop.PropertyName) : null%>
                        <span class="_disabled"><%= prop.IsReadOnly && prop.ShowForDisplay ? Html.Editor(prop.PropertyName) : null%></span>
                        <%
                        }%>
                    </div>
                </td>
                <td style="width:70px">
                    <%= Html.ValidationMessage(prop.PropertyName) %>
                </td>
            </tr>
        <% } %>
    <% } %>
    </table>
<% } %>
</div>