<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.TechnoObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="materialBlockIn">
    <% var obj = new TechnoModule() { PageSize = 5 }.LinkRouteData(); ;%>
	<!--фильтр-->
    <div class="filtrBlock">
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= obj.ModuleId %>"><span>Новые</span></li>
            <li class="_moduleAction _sortCommented" rel="sort" rev="<%= obj.ModuleId %>"><span>Комментируемые</span></li>
        </ul>
        <ul class="filtr">
            <li class="_moduleAction borderAll10 cur _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>Все</span></li>
                        <% if (Request.IsAuthenticated)
                           { %>
            <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>Избранное</span></li>
            <% } %>
        </ul>
    </div>
	<!--/фильтр-->

	<!--кол-во на странице-->
	<div class="onPage top">						
		<!--фильтр выпадашка года-->
		<div class="borderBot10 filtrSelectBlock">
			<div class="border borderAll10"><!-- при клике добавляем show к ul -->
				<ul class="borderAll10">
					<li>55</li>
					<li><a href="#">10</a></li>
					<li><a href="#">15</a></li>
				</ul>
			</div>
		</div>
		<!--/фильтр выпадашка года-->						
		<span class="h">Колличество материалов на странице</span>
	</div>
	<!--/кол-во на странице-->

	<ul class="materialList">
        <% obj.List(Html); %>		
	</ul>
    <% obj.Pager(Html); %>

	<!--кол-во на странице-->
	<div class="onPage bot">
		<!--фильтр выпадашка года-->
		<div class="borderBot10 filtrSelectBlock">
			<div class="border borderAll10"><!-- при клике добавляем show к ul -->
				<ul class="borderAll10">
					<li>55</li>
					<li><a href="#">10</a></li>
					<li><a href="#">15</a></li>
				</ul>
			</div>
		</div>
		<!--/фильтр выпадашка года-->
		<span class="h">Колличество материалов на странице</span>
	</div>
	<!--/кол-во на странице-->

</div>			
</asp:Content>