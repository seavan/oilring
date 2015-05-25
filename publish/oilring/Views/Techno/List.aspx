<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.TechnoObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="materialBlockIn">
    <% var obj = new TechnoModule() { PageSize = 5 }.LinkRouteData(); ;%>
	<!--������-->
    <div class="filtrBlock">
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= obj.ModuleId %>"><span>�����</span></li>
            <li class="_moduleAction _sortCommented" rel="sort" rev="<%= obj.ModuleId %>"><span>��������������</span></li>
        </ul>
        <ul class="filtr">
            <li class="_moduleAction borderAll10 cur _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>���</span></li>
                        <% if (Request.IsAuthenticated)
                           { %>
            <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>���������</span></li>
            <% } %>
        </ul>
    </div>
	<!--/������-->

	<!--���-�� �� ��������-->
	<div class="onPage top">						
		<!--������ ��������� ����-->
		<div class="borderBot10 filtrSelectBlock">
			<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
				<ul class="borderAll10">
					<li>55</li>
					<li><a href="#">10</a></li>
					<li><a href="#">15</a></li>
				</ul>
			</div>
		</div>
		<!--/������ ��������� ����-->						
		<span class="h">����������� ���������� �� ��������</span>
	</div>
	<!--/���-�� �� ��������-->

	<ul class="materialList">
        <% obj.List(Html); %>		
	</ul>
    <% obj.Pager(Html); %>

	<!--���-�� �� ��������-->
	<div class="onPage bot">
		<!--������ ��������� ����-->
		<div class="borderBot10 filtrSelectBlock">
			<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
				<ul class="borderAll10">
					<li>55</li>
					<li><a href="#">10</a></li>
					<li><a href="#">15</a></li>
				</ul>
			</div>
		</div>
		<!--/������ ��������� ����-->
		<span class="h">����������� ���������� �� ��������</span>
	</div>
	<!--/���-�� �� ��������-->

</div>			
</asp:Content>