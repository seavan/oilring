<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.SeminarObject>" %>
<%
    string addClass = string.Empty;
    
    if(ViewData["class"]!=null)
    {
        addClass = ViewData["class"].ToString() + " ";
    }
%>
<dl class="<%: addClass %>autor">
    <dt>Семинар добавил:</dt>
    <dd>
        <% (new UserModule(Model) {ViewName = "RelatedListWidgetSeminar", Relation = "ObjectAuthor", PageSize = 1}).ListWidget(Html); %>
    </dd>
    <dt>Семинар читают:</dt>
    <dd>
        <%
            (new UserModule(Model) { ViewName = "RelatedListWidgetSeminar", Relation = "ObjectAuthorReader", PageSize = 0 }).ListWidget(Html);
             %>
    </dd>
</dl>
