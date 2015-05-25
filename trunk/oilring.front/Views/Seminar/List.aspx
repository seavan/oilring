<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.SeminarObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
    <% var obj = new SeminarModule() { PageSize = 3 }.LinkRouteData();%>
    <div class="seminarsBlockIn">
        <!--������-->
        <div class="filtrBlock">
            <ul class="filtr">
                <li class="cur borderAll10 _moduleAction _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>���</span></li>
                            <% if (Request.IsAuthenticated)
                               { %>
                <li class="_moduleAction _filterMember" rel="filter" rev="<%=obj.ModuleId%>"><span>���</span></li>
                <li class="_moduleAction _filterAuthorReader" rel="filter" rev="<%=obj.ModuleId%>"><span>��������</span></li>
                <li class="_moduleAction _filterOrganizer" rel="filter" rev="<%=obj.ModuleId%>"><span>���������</span></li>
                <li class="_moduleAction _filterFavourites" rel="filter" rev="<%=obj.ModuleId%>"><span>���������</span></li>
                <% } %>
            </ul>
            <ul class="filtr">
                <li class="cur borderAll10 _moduleAction _sortComing" rel="sort" rev="<%= obj.ModuleId %>"><span>���������</span></li>
                <li class="_moduleAction _sortPassed" rel="sort" rev="<%= obj.ModuleId %>"><span>���������</span></li>
            </ul>
        </div>
        <!--/������-->
        <!--���������-->
        <div class="calendarBlockPopup _withCalendarBlock">
            <% obj.GetListDateJS(Html); %>
            <div class="calendarDoor" style="visibility:visible"><span>���������</span></div>
            
            <% Html.RenderPartial("CalendarInner", obj.ModuleId); %>
            <!--/���������-->
        </div>
        <!--/���������-->

        <ul class="materialList">
            <% obj.List(Html); %>
        </ul>
        <% obj.Pager(Html); %>
    </div>
</asp:Content>
