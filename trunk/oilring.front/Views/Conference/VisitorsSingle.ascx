<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ConferenceObject>" %>
<dl class="peopleBlock2">
    <dt>��������:</dt>
    <dd>
        <ul class="filtr">
            <li class="cur borderAll10"><span>���</span></li>
            <li><span>�������</span></li>
            <li><span>���������</span></li>
            <li><span>�����������</span></li>
        </ul>
        <% (new UserModule(Model) { Relation = "ObjectUserVisitor", ViewName = "RelatedListWidgetSingleMember" }).ListWidget(Html); %>        
    </dd>
</dl>
