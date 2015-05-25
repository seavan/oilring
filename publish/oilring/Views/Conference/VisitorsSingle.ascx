<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ConferenceObject>" %>
<dl class="peopleBlock2">
    <dt>Записаны:</dt>
    <dd>
        <ul class="filtr">
            <li class="cur borderAll10"><span>Все</span></li>
            <li><span>Коллеги</span></li>
            <li><span>Ожидающие</span></li>
            <li><span>Отклоненные</span></li>
        </ul>
        <% (new UserModule(Model) { Relation = "ObjectUserVisitor", ViewName = "RelatedListWidgetSingleMember" }).ListWidget(Html); %>        
    </dd>
</dl>
