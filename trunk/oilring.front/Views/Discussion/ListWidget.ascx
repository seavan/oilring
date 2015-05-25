<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.DiscussionObject>>" %>	
<% foreach (var item in Model){%>
<li>
    <div class="autor">
        <% (new UserModule(item) {ViewName = "RelatedSingleWidget", Relation = "ObjectAuthor"}).ListWidget(Html); %>
        <div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>
    </div>
    <a href="<%= Html.SingleUri(item) %>" class="name"><%= item.Title %></a> <%= item.ShortDescription %>

    <div class="infBlock">
		<div class="comment"><a href="<%= Html.SingleUri(item) %>#comments" class="icComment"><%: item.AUTO_CommentCount %> комментариев</a></div>
		<div class="addComment"><a href="<%= Html.SingleUri(item) %>#commentAdd" class="icAddComment">Добавить комментарий</a></div>
	</div>    
</li>
<%} %>