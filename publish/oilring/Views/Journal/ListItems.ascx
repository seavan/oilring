<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.JournalObject>>" %>	
<% foreach (var item in Model){%>
<li>
	<div class="bgWrap">		
		<%if(Request.IsAuthenticated) {%>
        <div class='icFavorite <%= item.PSEUDO_IsUserFavourite ? "add" : "" %>'>избранное</div>
        <%} %>
		
        <%= OilringExtension.DefaultImage(item, ConstSizes.MID,"class='f'") %>

		<div class="descr">
            <a href="<%= Html.SingleUri(item) %>" class="name"><%= item.Title %></a>			
			<div class="info">
				<span>язык:</span> Русский<br />
				<span>читателей:</span> <%:item.AUTO_ReadersCount %><br />
				<span>ISBN:</span> <%= item.ISBN %>
			</div>
			<%= item.ShortDescription%>
		</div>

		<div class="info2">
			Этот журнал читают: <span class="_universalPeopleDoor peopleDoor borderTop10"><span><%:item.AUTO_ReadersCount %></span></span> <!-- при клике добавляем show -->
			<span class="rubricDoor borderTop10"><span class="h"><span>Рубрики</span></span></span> <!-- при клике добавляем show -->									
		</div>

		<!--рубрики-->
		<% (new RubricModule(item) { Relation = "Rubrics", ViewName = "RelatedListWidget", Ajax = true, Delayed = true }).ListWidget(Html); %>
		<!--/рубрики-->

		<!--люди-->
		<% Html.RenderPartial("Readers", item); %>
		<!--/люди-->

	</div>
</li>
<%} %>