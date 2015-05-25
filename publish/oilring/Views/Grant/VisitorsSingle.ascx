<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GrantObject>" %>
<dl class="peopleBlock2">
	<dt>Участники гранта:</dt>
	<dd>
		<ul class="filtr">
			<li class="cur borderAll10"><span>Все</span></li>
			<li><span>Коллеги</span></li>
		</ul>

		<% (new UserModule(Model) { Relation = "GrantMember", ViewName = "RelatedListWidgetSingleMember" }).ListWidget(Html); %>
        							
	</dd>
</dl>
