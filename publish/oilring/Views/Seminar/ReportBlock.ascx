<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.SeminarObject>" %>
<dl class="reportList">
    <dt>Доклады семинара:</dt>
    <%(new ReportModule(Model) { ViewName = "RelatedListWidget", REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html); %>
</dl>
