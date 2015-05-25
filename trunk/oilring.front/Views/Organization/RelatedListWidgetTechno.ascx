<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<% if (Model.Count() > 0){%>
<dt>����������<%: Model.Count() > 1 ? "�" : "�" %></dt>
<dd>
    <ul class="list">
        <%foreach (var item in Model){%>
        <li><a href="<%=Html.SingleUri(item)%>"><%=item.Title%></a></li>
        <%}%>
    </ul>
</dd>
<%}%>
