<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<dl class="autor">
    <dt>Автор дискуссии:</dt>
    <dd>
<%
    foreach (var item in Model)
    {
%>
<div class="persona">
    <a href="<%= Html.SingleUri(item) %>">
<img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a></div>
<%

} %>
    </dd>
</dl>
