<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.ConferenceObject>" %>
<dl class="infoBlocks links">
    <% (new OrganizationModule(Model) { Relation = "Organizers", ViewName = "RelatedListWidgetShort" }).ListWidget(Html); %>
</dl>
