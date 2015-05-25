<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<ul class="menuTop">
    <li><a href="<%: Url.Action("","User", null) %>"><%= Html.LC().Menu_Users %></a></li>
    <li><a href="/"><%= Html.LC().Menu_Content %></a></li>
    <li><a href="<%: Url.Action("","Organization", null) %>"><%= Html.LC().Menu_Organizations %></a></li>
    <li><a href="<%: Url.Action("SearchResult","Home", null) %>"><%= Html.LC().Search_Search %></a></li>
    <li><a href="<%: Url.Action("About","Home", null) %>"><%= Html.LC().Menu_AboutProject %></a></li>
</ul>
