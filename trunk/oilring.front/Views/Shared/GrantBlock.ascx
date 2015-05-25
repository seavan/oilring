<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<dl class="infoBlock listInfoBlock">
    <%
        var obj = (new GrantModule() {PageSize = 5}); %>
    <dt><%= Html.LC().Entities_Grants %> <span class="calendarDoor">Календарь</span> </dt>
    <dd>
        <!--фильтр-->
            <ul class="filtr">
                <li class="cur borderAll10 _moduleAction _filterAll" rel="filter" rev="<%= obj.ModuleId %>"><span>Все</span></li>
            <% if(Request.IsAuthenticated)
               { %>
                <li class="_moduleAction _filterRequest" rel="filter" rev="<%=obj.ModuleId%>"><span>Подаюсь</span></li>
                <li class="_moduleAction _filterMember" rel="filter" rev="<%=obj.ModuleId%>"><span>Участвую</span></li>
                <% } %>
            </ul>
        <!--/фильтр-->
        <!--календарь-->
        <div class="calendarBlock">
            <!--по клику раскрываем-->
            <div class="months">
                <a href="#" class="prev">Назад</a> <a href="#" class="next">Вперед</a> <span>сентябрь</span>
            </div>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        1
                    </td>
                    <td>
                        2
                    </td>
                    <td class="weekend">
                        3
                    </td>
                </tr>
                <tr>
                    <td>
                        4
                    </td>
                    <td>
                        5
                    </td>
                    <td>
                        6
                    </td>
                    <td>
                        <a href="#">7</a>
                    </td>
                    <td>
                        8
                    </td>
                    <td>
                        9
                    </td>
                    <td class="weekend">
                        10
                    </td>
                </tr>
                <tr>
                    <td>
                        11
                    </td>
                    <td>
                        12
                    </td>
                    <td>
                        <a href="#">13</a>
                    </td>
                    <td>
                        14
                    </td>
                    <td>
                        15
                    </td>
                    <td>
                        16
                    </td>
                    <td class="weekend">
                        <a href="#">17</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        18
                    </td>
                    <td>
                        19
                    </td>
                    <td>
                        20
                    </td>
                    <td>
                        21
                    </td>
                    <td>
                        22
                    </td>
                    <td>
                        23
                    </td>
                    <td class="weekend">
                        24
                    </td>
                </tr>
                <tr>
                    <td>
                        25
                    </td>
                    <td>
                        26
                    </td>
                    <td>
                        27
                    </td>
                    <td>
                        28
                    </td>
                    <td>
                        29
                    </td>
                    <td>
                        30
                    </td>
                    <td class="weekend">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!--/календарь-->
        <ul class="list">
            <% obj.ListWidget(Html); %>            
        </ul>
        <a href="<%= Html.Chapter<admin.db.GrantObject>() %>"><%= Html.LC().Entities_Grants_All %></a>
    </dd>
</dl>
