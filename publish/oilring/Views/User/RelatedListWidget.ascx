<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<dl class="autor">
    <dt>Авторы дискуссии:</dt>
    <dd>
<%
    foreach (var item in Model)
    {
%>
<div class="persona">
    <a href="<%= OilringHtml.SingleUri(item) %>">
        <% if (!String.IsNullOrEmpty(item.Photo))
           {%><img src="/Content/images/<%=item.SmallAvatar%>" alt="" /><%
    }%><%= item.DisplayName %></a></div>
<%

} %>
    </dd>
</dl>
