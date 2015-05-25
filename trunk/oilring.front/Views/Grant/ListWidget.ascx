<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.GrantObject>>" %>	
<% foreach (var item in Model){%>
<li>
    <div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>
    <a href="<%= Html.SingleUri(item) %>"><%= item.Title %></a>
</li>
<%} %>