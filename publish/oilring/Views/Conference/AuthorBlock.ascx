<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.ConferenceObject>" %>
<%
    string addClass = string.Empty;
    
    if(ViewData["class"]!=null)
    {
        addClass = ViewData["class"].ToString() + " ";
    }
%>
<dl class="<%: addClass %>autor">
    <dt>Конференцию добавил:</dt>
    <dd>
        <% (new UserModule(Model) {ViewName = "RelatedListWidgetSeminar", Relation = "ObjectAuthor"}).ListWidget(Html); %>
    </dd>
    <dt>Конференцию читают:</dt>
    <dd>
        <% (new UserModule(Model) { ViewName = "RelatedListWidgetSeminar", Relation = "ObjectAuthorReader" }).ListWidget(Html); %>
    </dd>
</dl>
