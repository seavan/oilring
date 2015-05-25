<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TagObject>>" %>
<dt>Интересы:</dt>
<dd>
    <%foreach (var item in Model) {%>
	<a href="<%= Html.SingleUri(item) %>"><%= item.Text %></a><%: item.Id != Model.Last().Id ? ", " : "" %>
    <%} %>
</dd>