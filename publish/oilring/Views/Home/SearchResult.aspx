<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/MainInnerNoMenu.master"%>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">

<%
    var searchVal = Model != null ? Model.ToString() : "";
     %>
		<div class="searchReult">

			<h1>Поиск</h1>

			<% using (Html.BeginForm("SearchResult", "Home", FormMethod.Post, new { id="singleSearchForm"})) { %>
				<div class="searchBlock">
					<input type="text" class="_searchBox" id="fsearch" name="query" value="<%= searchVal %>"/>
					<input type="submit" value="Найти"/>
					<span class="searchDoor">Расширенный поиск</span>
				</div>
			<%} %>

            <div class="searchBlock2 borderAll10" style="display:none;">
				<% Html.RenderPartial("MenuSearch"); %>	



			</div>

            <% var mod = (new Dummy_SearchObjectModule() { SearchQueryString = searchVal, ViewName = "SearchResult", PageSize = 5 }); %>
            <% mod.EntityTypeFilter(Html); %>
            <% mod.SphinxSearch(Html); %>
            <% mod.Pager(Html, "Pager"); %>
</div>
	
</asp:Content>