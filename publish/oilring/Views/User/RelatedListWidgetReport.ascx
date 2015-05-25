<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<%foreach (var item in Model){%>
<a href="<%= Html.SingleUri(item) %>"><%= item.DisplayName %></a><%: item.Id == Model.Last().Id ? "" : ", " %>
<%} %>
