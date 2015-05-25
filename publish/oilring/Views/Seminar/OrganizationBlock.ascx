<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.SeminarObject>" %>
<dl class="infoBlocks links">
    <% (new OrganizationModule(Model) { Relation = "Organizers", ViewName = "RelatedListWidgetShort" }).ListWidget(Html); %>
</dl>
