<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.JournalObject>>" %>	
<% foreach (var item in Model){%>
<li>
	<div class="bgWrap">		
		<%if(Request.IsAuthenticated) {%>
        <div class='icFavorite <%= item.PSEUDO_IsUserFavourite ? "add" : "" %>'>���������</div>
        <%} %>
		
        <%= OilringExtension.DefaultImage(item, ConstSizes.MID,"class='f'") %>

		<div class="descr">
            <a href="<%= Html.SingleUri(item) %>" class="name"><%= item.Title %></a>			
			<div class="info">
				<span>����:</span> �������<br />
				<span>���������:</span> <%:item.AUTO_ReadersCount %><br />
				<span>ISBN:</span> <%= item.ISBN %>
			</div>
			<%= item.ShortDescription%>
		</div>

		<div class="info2">
			���� ������ ������: <span class="_universalPeopleDoor peopleDoor borderTop10"><span><%:item.AUTO_ReadersCount %></span></span> <!-- ��� ����� ��������� show -->
			<span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span> <!-- ��� ����� ��������� show -->									
		</div>

		<!--�������-->
		<% (new RubricModule(item) { Relation = "Rubrics", ViewName = "RelatedListWidget", Ajax = true, Delayed = true }).ListWidget(Html); %>
		<!--/�������-->

		<!--����-->
		<% Html.RenderPartial("Readers", item); %>
		<!--/����-->

	</div>
</li>
<%} %>