<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% var moduleId = ViewData["AffectedModuleId"]; %>

<!--алфавит-->
<ul class="alphabet inside borderTop10 _moduleAction" rev="<%= moduleId %>" rel="filterLetter">
	<li class="all cur">все</li>
	<li>а</li>
	<li>б</li>
	<li>в</li>
	<li>г</li>
	<li>д</li>
	<li>е</li>
	<li>ж</li>
	<li>з</li>
	<li>и</li>
	<li>к</li>
	<li>л</li>
	<li>м</li>
	<li>н</li>
	<li>о</li>
	<li>п</li>
	<li>р</li>
	<li>с</li>
	<li>т</li>
	<li>у</li>
	<li>ф</li>
	<li>х</li>
	<li>ц</li>
	<li>ч</li>
	<li>ш</li>
	<li>щ</li>
	<li>ы</li>
	<li>э</li>
	<li>ю</li>
	<li>я</li>
	<li class="lang">Eng</li>
</ul>
<!--/алфавит-->
