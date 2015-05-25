<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.EventObject>>" %>
<% foreach (var item in Model) {%>
<li>
    <div class="f">
        <span class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></span>
    </div>
    <a href="<%= Html.SingleUri(item) %>"><%= item.Title %></a>
    <%if(!string.IsNullOrEmpty(item.SourceTitle)){ %>
    <div class="source">// <%=item.SourceTitle%></div>
    <%}%>
</li>
<%}%>