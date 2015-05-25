<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TagObject>>" %>
<%
    var moduleParams = new ModuleParams(this.ViewContext.RouteData.Values);

    var userFilter = moduleParams.UserFilter > 0;
    var selectedTags = new long[] { };
    if (userFilter)
    {
        selectedTags = moduleParams.GetUserTagFilter().Split(';').Where( s => s.Trim().Length > 0).Select(s => long.Parse(s)).ToArray();
    }
%>
<% foreach (var item in Model)
{
       %>
    <li rel="<%= item.Id %>" class="<%= selectedTags.Contains(item.Id) ? "cur" : ""%>">
        <div>
            <span><%= item.Text %></span></div>
    </li>
  <%
} %>

