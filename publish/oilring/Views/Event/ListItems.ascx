<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.EventObject>>" %>	
<% foreach (var item in Model){%>
<li>
	<div class="bgWrap">		
		<div class="descr">
			<a href="<%= Html.SingleUri(item) %>" class="name">
				<%= item.Title %>
			</a>
			<div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>
			<%= item.ShortDescription%>
		</div>
		<div class="comment">
            <a href="<%= Html.SingleUri(item, "comments") %>" class="icComment"><%= item.AUTO_CommentCount %> комментариев</a> 
            <% if (item.AUTO_Comment_LastDateTime != null && item.AUTO_CommentCount > 0){%>(последний <%= OilringExtension.ToStringVerboseDateTime(item.AUTO_Comment_LastDateTime.Value) %>) <%}%>
        </div>
	</div>
</li>
<%} %>	