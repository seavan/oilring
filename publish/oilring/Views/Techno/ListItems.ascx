<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.TechnoObject>>" %>
<% foreach (var item in Model){%>
<li>
	<div class="bgWrap">	
    	
		<% Html.RenderPartial("FavouriteBlock", item); %>

		<!-- authors -->
        <% (new UserModule(item) { ViewName = "RelatedListWidgetTechno", Relation = "ObjectAuthor", PageSize = 3, Page = 1 }).ListWidget(Html); %>
        <!-- /authors -->

		<div class="descr">
            <a href="<%= Html.SingleUri(item) %>" class="name"><%= item.GetSafeTitle() %></a>			
			<div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>
			<%= item.ShortDescription%>
			
            <% (new OrganizationModule(item) { ViewName = "RelatedListWidgetMember", Relation = "OrganizationMembers" }).ListWidget(Html); %>

		</div>

		<div class="comment">
			<a href="<%= Html.SingleUri(item, "comments") %>" class="icComment"><%= item.AUTO_CommentCount %> ������������ <%--<b>(2)</b>--%></a> 
            <% if (item.AUTO_Comment_LastDateTime != null && item.AUTO_CommentCount > 0){%>(��������� <%= OilringExtension.ToStringVerboseDateTime(item.AUTO_Comment_LastDateTime.Value) %>) <%}%>
			<span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span> <!-- ��� ����� ��������� show -->
		</div>

		<!--�������-->
		<% (new RubricModule(item) { Relation = "Rubrics", ViewName = "RelatedListWidget", Ajax = true, Delayed = true }).ListWidget(Html); %>
		<!--/�������-->
	</div>
</li>
<%} %>	