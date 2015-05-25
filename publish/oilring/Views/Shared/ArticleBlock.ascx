<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<dl class="infoBlock materialsList">
    <dt><%= Html.LC().Entities_Materials_Last %></dt>
    <dd>
        <!--фильтр-->
        <%  var mod = (new ArticleModule() {PageSize = 4}); %>
        <ul class="filtr">
            <li class="cur borderAll10 _moduleAction _sortNew" rel="sort" rev="<%= mod.ModuleId %>"><span>Новые</span></li>
            <li class="_moduleAction _sortCommented" rel="sort" rev="<%= mod.ModuleId %>"><span>Комментируемые</span></li>
        </ul>
        <!--/фильтр-->
        <ul class="list">
            <% mod.ListWidget(Html); %>
        </ul>
        
        <div class="more"><a href="<%= Html.Chapter<admin.db.ArticleObject>() %>"><%= Html.LC().Entities_Materials_All %></a></div>
    </dd>
</dl>
