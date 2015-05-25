<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<%
    foreach (var item in Model)
{
        %>
        <div class="persona">
        <%= OilringExtension.DefaultImage(item, ConstSizes.SMALL) %>
        <a href="<%= Html.SingleUri(item) %>"><%= item.DisplayName %></a></div><%
    break;
} %>