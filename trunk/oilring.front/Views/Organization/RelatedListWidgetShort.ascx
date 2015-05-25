<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<% if (Model.Count() > 0){%>
<dt>����������<%: Model.Count() > 1 ? "�" : "�" %></dt>
<dd>
    <%foreach (var item in Model){%>
    <a href="<%=Html.SingleUri(item)%>"><%=item.Title%></a><%: item.Id == Model.Last().Id ? "" : ", " %>
    <%}%>
</dd>
<%}%>
