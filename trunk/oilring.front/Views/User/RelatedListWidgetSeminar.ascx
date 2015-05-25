<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<%
    foreach (var item in Model)
{
        %>
        <%--<div class="persona">
        <%= OilringExtension.DefaultImage(item, ConstSizes.SMALL) %>
        <a href="<%= Html.SingleUri(item) %>"><%= item.DisplayName %></a></div>--%>
        <div class="persona">
    <a href="<%= Html.SingleUri(item) %>">
<img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a></div><%

} %>