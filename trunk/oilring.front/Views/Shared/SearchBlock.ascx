<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<!--поиск-->
<% using (Html.BeginForm("SearchResult", "Home", FormMethod.Post, new { id="quickSearchForm"})) { %>
<div class="searchBlock">
    <label for="fsearch" class="_autohide">
        <%= Html.LC().Search_All %></label><!--при фокусе убираем-->
    <input type="text" value="" name="query" id="fsearch" />
    <input type="submit" value="Найти" />
</div>
<%} %>
<!--/поиск-->
