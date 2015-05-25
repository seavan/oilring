<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ConferenceObject>" %>
<% var obj = (new UserModule(Model) { Relation = "ObjectUserVisitor", ViewName = "RelatedListWidgetListMember", PageSize = 9, Ajax = true, Delayed = true }); %>
<div class="peopleBlock borderAll10">
    <!--по клику раскрываем-->
    <ul class="filtr">
        <li class="cur borderAll10">Все</li>
        <li><a href="#">Коллеги</a></li>
    </ul>
    <%--<div class="slider">
        <span class="cur" title="1">&nbsp;</span> <span title="2">&nbsp;</span> <span title="3">
            &nbsp;</span> <span title="4">&nbsp;</span>
    </div>
    <% (new UserModule(Model) { Relation = "ObjectUserVisitor", ViewName = "RelatedListWidgetListMember" }).ListWidget(Html); %>--%>
    <% obj.PagerJS(Html, "PagerJS"); %>
    <% obj.ListWidget(Html); %>  
</div>
