<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.SeminarObject>>" %>

<%
    var shortModel = Model.Take(5);
    foreach (var item in shortModel){%>
<li>
    <div class="date"><%= item.EventStartDate.ToStringNormalDate() %>&nbsp;&nbsp;<!--//  Я иду --></div>
    <a href="<%= Html.SingleUri(item) %>"><%= item.Title %></a>
</li>
<%}%>