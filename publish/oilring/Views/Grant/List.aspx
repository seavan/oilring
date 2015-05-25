<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.GrantObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% var obj = new GrantModule() { PageSize = 5 }.LinkRouteData();%>
<div class="grantsBlockIn">
	<!--фильтр-->
        <!--фильтр-->
        <div class="filtrBlock">
            <ul class="filtr">
                <li class="cur borderAll10 _moduleAction _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>Все</span></li>
                <% if (Request.IsAuthenticated)
                   { %>
                <li class="_moduleAction _filterRequest" rel="filter" rev="<%=obj.ModuleId%>"><span>Подаюсь</span></li>
                <li class="_moduleAction _filterMember" rel="filter" rev="<%=obj.ModuleId%>"><span>Участвую</span></li>
                <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>Избранное</span></li>
                <% } %>
            </ul>
            <ul class="filtr">
                <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= obj.ModuleId %>"><span>Новые</span></li>
                <li class="_moduleAction _sortCommented" rel="sort" rev="<%= obj.ModuleId %>"><span>Комментируемые</span></li>
            </ul>
        </div>
        <!--/фильтр-->
	<!--/фильтр-->
	<!--календарь-->
	<div class="calendarBlockPopup">
		<div class="calendarDoor"><span>Календарь</span></div>
		<div class="calendarBlock"> <!--по клику раскрываем-->
			<div class="close" title="Закрыть">Закрыть</div>
			<div class="months">
				<a href="#" class="prev">Назад</a>
				<a href="#" class="next">Вперед</a>
				<span>сентябрь</span>										
			</div>
			<table>
				<tr>
					<th>пн</th>
					<th>вт</th>
					<th>ср</th>
					<th>чт</th>
					<th>пт</th>
					<th>сб</th>
					<th>вс</th>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>1</td>
					<td>2</td>
					<td class="weekend">3</td>
				</tr>
				<tr>
					<td>4</td>
					<td>5</td>
					<td>6</td>
					<td><a href="#">7</a></td>
					<td class="cur"><a href="#">8</a></td>
					<td>9</td>
					<td class="weekend">10</td>
				</tr>
				<tr >
					<td>11</td>
					<td>12</td>
					<td><a href="#">13</a></td>
					<td>14</td>
					<td>15</td>
					<td>16</td>
					<td class="weekend"><a href="#">17</a></td>
				</tr>
				<tr >
					<td>18</td>
					<td>19</td>
					<td>20</td>
					<td>21</td>
					<td>22</td>
					<td>23</td>
					<td class="weekend">24</td>
				</tr>
				<tr >
					<td>25</td>
					<td>26</td>
					<td>27</td>
					<td>28</td>
					<td>29</td>
					<td>30</td>
					<td class="weekend">&nbsp;</td>
				</tr>				
			</table>
			<a href="#">Сбросить дату</a>
		</div>
		<!--/календарь-->
	</div>
	<!--/календарь-->

	<ul class="materialList">
        <% obj.List(Html); %>		
	</ul>
    <% obj.Pager(Html); %>
</div>			
</asp:Content>