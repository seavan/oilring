<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.JournalObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="journalBlockIn">
    <% var obj = new JournalModule() { PageSize = 5 }.LinkRouteData();%>
	<!--������-->
    <div class="filtrBlock">
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= obj.ModuleId %>"><span>�����</span></li>
            <li class="_moduleAction _sortReaders" rel="sort" rev="<%= obj.ModuleId %>"><span>����������</span></li>
        </ul>
        <ul class="filtr">
            <li class="_moduleAction borderAll10 cur _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>���</span></li>
                        <% if (Request.IsAuthenticated)
                           { %>
            <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>���������</span></li>
            <li class="_moduleAction _filterVak" rel="filter" rev="<%=obj.ModuleId%>"><span>������� ���</span></li>
            <li class="_moduleAction _filterOthers" rel="filter" rev="<%=obj.ModuleId%>"><span>������ �������</span></li>
            <% } %>
        </ul>
    </div>

	<!--/������-->

	<%--<!--�������-->
	<ul class="alphabet">
		<li class="all cur">���</li>
		<li><a href="#">�</a></li>
		<li><a href="#">�</a></li>
		<li>�</li>
		<li>�</li>
		<li class="cur">�</li>
		<li>�</li>
		<li><a href="#">�</a></li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li><a href="#">�</a></li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li><a href="#">�</a></li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li>�</li>
		<li class="lang"><a href="#">Eng</a></li>
	</ul>
	<!--/�������-->--%>
	<ul class="materialList">
        <% obj.List(Html); %>		
	</ul>
    <% obj.Pager(Html); %>
</div>
</asp:Content>