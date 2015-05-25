<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<dl class="infoBlock listInfoBlock _withCalendarBlock">
    <% var obj = new SeminarModule(); %>
    <% obj.SetCurrentDateForMonth(DateTime.Now.ToJSCode()); %>
    <dt><%= Html.LC().Entities_Seminars %> <span class="calendarDoor _hide" style="visibility:visible">Календарь</span> </dt>
    <dd>
        <!--фильтр-->
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>Все</span></li>
            <% if(Request.IsAuthenticated)
               { %>
            <li class="_moduleAction _filterMember" rel="filter" rev="<%=obj.ModuleId%>"><span>Иду</span></li>
            <li class="_moduleAction _filterAuthorReader" rel="filter" rev="<%=obj.ModuleId%>"><span>Выступаю</span></li>
            <li class="_moduleAction _filterOrganizer" rel="filter" rev="<%=obj.ModuleId%>"><span>Организую</span></li>
            <% } %>
        </ul>
        <!--/фильтр-->

        <% obj.GetListDateJS(Html); %>
        <!--календарь-->
        <% Html.RenderPartial("Calendar", obj.ModuleId); %>
        <!--/календарь-->

        <ul class="list">
        <% obj.ListWidget(Html); %>
        </ul>
        <a href="<%= Html.Chapter<admin.db.SeminarObject>() %>" class="more"><%= Html.LC().Entities_Seminars_All %></a>
    </dd>
</dl>
