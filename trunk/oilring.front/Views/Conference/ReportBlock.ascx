<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.ConferenceObject>" %>
<dl class="reportList">
    <dt>Доклады конференции:</dt>
    <%(new ReportModule(Model) { ViewName = "RelatedListWidget", REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html); %>
</dl>
