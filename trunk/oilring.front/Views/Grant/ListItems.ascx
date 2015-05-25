<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.GrantObject>>" %>	
<% foreach (var item in Model){%>
<li>
	<div class="bgWrap">
    		
		<% Html.RenderPartial("FavouriteBlock", item); %>

		<dl class="price">
			<dt>����� ������</dt>
			<dd><b><%= item.Sum.ToStringNormalSum() %> <%= item.SumCurrency.Replace(" ","")%>.</b></dd>
            			
            <% (new OrganizationModule(item) { Relation = "Organizers", ViewName = "RelatedListWidgetShort" }).ListWidget(Html); %>

		</dl>
		<div class="descr">
			<a href="<%= Html.SingleUri(item) %>" class="name"><%= item.Title %></a>
			<div class="date">
                ����������: <%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%>     
                ������� ���� ������ ������: <%=item.OrderDeadline.ToStringNormalDate() %>
            </div>
			<%= item.ShortDescription%>
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