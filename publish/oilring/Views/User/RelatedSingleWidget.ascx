<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<%
    foreach (var item in Model)
{
        %>
        <img src="<%= RES.IMAGE_CONTENT_URI %><%= item.SmallAvatar %>" alt="" />
        <a href="<%= Html.SingleUri(item) %>"><%= item.DisplayName %></a><%
    break;
} %>