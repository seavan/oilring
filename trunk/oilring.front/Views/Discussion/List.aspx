<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.DiscussionObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% var obj = new DiscussionModule() { PageSize = 5 }.LinkRouteData();%>
<div class="discussionBlockIn">
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

	<ul class="materialList">
		<% obj.List(Html); %>
	</ul>
    <% obj.Pager(Html); %>
</div>			
</asp:Content>