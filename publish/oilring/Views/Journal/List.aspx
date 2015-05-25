<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.JournalObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="journalBlockIn">
    <% var obj = new JournalModule() { PageSize = 5 }.LinkRouteData();%>
	<!--фильтр-->
    <div class="filtrBlock">
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= obj.ModuleId %>"><span>Новые</span></li>
            <li class="_moduleAction _sortReaders" rel="sort" rev="<%= obj.ModuleId %>"><span>Популярные</span></li>
        </ul>
        <ul class="filtr">
            <li class="_moduleAction borderAll10 cur _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>Все</span></li>
                        <% if (Request.IsAuthenticated)
                           { %>
            <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>Избранное</span></li>
            <li class="_moduleAction _filterVak" rel="filter" rev="<%=obj.ModuleId%>"><span>Журналы ВАК</span></li>
            <li class="_moduleAction _filterOthers" rel="filter" rev="<%=obj.ModuleId%>"><span>Прочие журналы</span></li>
            <% } %>
        </ul>
    </div>

	<!--/фильтр-->

	<%--<!--алфавит-->
	<ul class="alphabet">
		<li class="all cur">все</li>
		<li><a href="#">а</a></li>
		<li><a href="#">б</a></li>
		<li>в</li>
		<li>г</li>
		<li class="cur">д</li>
		<li>е</li>
		<li><a href="#">ж</a></li>
		<li>з</li>
		<li>и</li>
		<li>к</li>
		<li>л</li>
		<li>м</li>
		<li>н</li>
		<li>о</li>
		<li>п</li>
		<li>р</li>
		<li>с</li>
		<li><a href="#">т</a></li>
		<li>у</li>
		<li>ф</li>
		<li>х</li>
		<li>ц</li>
		<li>ч</li>
		<li>ш</li>
		<li><a href="#">щ</a></li>
		<li>ы</li>
		<li>э</li>
		<li>ю</li>
		<li>я</li>
		<li class="lang"><a href="#">Eng</a></li>
	</ul>
	<!--/алфавит-->--%>
	<ul class="materialList">
        <% obj.List(Html); %>		
	</ul>
    <% obj.Pager(Html); %>
</div>
</asp:Content>