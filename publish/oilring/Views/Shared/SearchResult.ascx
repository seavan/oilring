<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>


<!--кол-во на странице-->
<div class="onPage top">
    <!--фильтр выпадашка года-->
    <div class="borderBot10 filtrSelectBlock">
        <div class="border borderAll10">
            <!-- при клике добавляем show к ul -->
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
<ul class="materialList list">
<% foreach(ITitleable item in Model as IEnumerable)
   {  %>
    <li>
        <div class="bgWrap">
            <div class="name">
                <a href="<%= Html.SingleUri(item) %>"><%=  item.Title %></a></div>
                <%= item.ShortDescription %>
        </div>
    </li>
    <% } %>
</ul>
<!--нумерация-->
<!--/нумерация-->
<!--кол-во на странице-->
<div class="onPage bot">
    <!--фильтр выпадашка года-->
    <div class="borderBot10 filtrSelectBlock">
        <div class="border borderAll10">
            <!-- при клике добавляем show к ul -->
            <ul class="borderAll10">
                <li>55</li>
                <li><a href="#">10</a></li>
                <li><a href="#">15</a></li>
            </ul>
        </div>
    </div>
    <!--/фильтр выпадашка года-->
    <span class="h">Количество материалов на странице</span>
</div>
<!--/кол-во на странице-->
