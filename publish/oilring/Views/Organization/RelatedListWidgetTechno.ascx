<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<% if (Model.Count() > 0){%>
<dt>Организаци<%: Model.Count() > 1 ? "и" : "я" %></dt>
<dd>
    <ul class="list">
        <%foreach (var item in Model){%>
        <li><a href="<%=Html.SingleUri(item)%>"><%=item.Title%></a></li>
        <%}%>
    </ul>
</dd>
<%}%>
