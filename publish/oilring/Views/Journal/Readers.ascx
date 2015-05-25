<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JournalObject>" %>
<% var obj = (new UserModule(Model) { Relation = "ObjectUserReader", ViewName = "RelatedListWidgetListMember", PageSize = 9, Ajax = true, Delayed = true }); %>
<div class="peopleBlock borderAll10"> <!--по клику раскрываем-->

	<ul class="filtr">
		<li class="cur borderAll10">Все</li>
		<li><a href="#">Коллеги</a></li>
	</ul>

	<% obj.PagerJS(Html, "PagerJS"); %>
    <% obj.ListWidget(Html); %>
</div>