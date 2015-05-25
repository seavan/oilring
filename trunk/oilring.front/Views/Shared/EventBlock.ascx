<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<dl class="infoBlock newsList">
    <dt><%= Html.LC().Entities_Events %></dt>
    <dd>
        <% var module = (new EventModule() {  PageSize = 5 }).ListWidget(Html); %>
        <div class="more _moduleAction" rel="nextPage" rev='<%= module.ModuleId %>'><span><%= Html.LC().Entities_Events_More %></span></div>
    </dd>
</dl>
