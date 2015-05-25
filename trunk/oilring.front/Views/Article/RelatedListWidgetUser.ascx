<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ArticleObject>>" %>

<%if(Model.Count()>0) {%>
<ul class="list">
    <%foreach(var item in Model) {%>
    <li>
        <a href="<%= Html.SingleUri(item) %>"><%= item.Title %></a><br />	
        <%= HttpUtility.HtmlDecode(item.ShortDescription)%>
	</li>
    <%} %>
</ul>
<%} %>