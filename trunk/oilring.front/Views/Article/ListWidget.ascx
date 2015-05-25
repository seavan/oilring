<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.ArticleObject>>" %>	
<% foreach (var item in Model){
       var photoAvailable = OilringExtension.DefaultPhotoAvailable(item);
%>

<li class="<%= photoAvailable ? "" : "nofoto" %>">
    <% if (photoAvailable)
{%>
    <div class="f">
        <%=OilringExtension.DefaultImage(item, ConstSizes.MID)%>      
    </div>
    <%
}%>
    <a href="<%= Html.SingleUri(item) %>" class="name"><%= item.Title %></a><%= item.ShortDescription %>
    <div class="infBlock">
		<div class="comment"><a href="<%= Html.SingleUri(item) %>#comments" class="icComment"><%: item.AUTO_CommentCount %> комментариев</a></div>
		<div class="addComment"><a href="<%= Html.SingleUri(item) %>#commentAdd" class="icAddComment">Добавить комментарий</a></div>
	</div>
</li>
<%}%>