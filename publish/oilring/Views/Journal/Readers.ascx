<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JournalObject>" %>
<% var obj = (new UserModule(Model) { Relation = "ObjectUserReader", ViewName = "RelatedListWidgetListMember", PageSize = 9, Ajax = true, Delayed = true }); %>
<div class="peopleBlock borderAll10"> <!--�� ����� ����������-->

	<ul class="filtr">
		<li class="cur borderAll10">���</li>
		<li><a href="#">�������</a></li>
	</ul>

	<% obj.PagerJS(Html, "PagerJS"); %>
    <% obj.ListWidget(Html); %>
</div>