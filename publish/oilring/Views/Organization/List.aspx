<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OrganizationObject>>"  MasterPageFile="~/Views/Shared/Main.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div id="middleWrap" class="borderBot10">
	<div class="block1 borderAll10">

        <% var orgModule = new OrganizationModule() {PageSize = 8}; %>
		<% Html.RenderPartial("AlphabetFilter", new ViewDataDictionary{ {"AffectedModuleId", orgModule.ModuleId} }); %>

		<div class="firmBlockIn">
            <% orgModule.LinkRouteData(); %>
			<dl class="list">
				<% orgModule.List(Html); %>
			</dl>
			<%
                   orgModule.Pager(Html); %>
		</div>
	</div>
	<div class="block2">
		<!--баннеры-->
        <% Html.RenderPartial("BannerBlock"); %>
        <!--/баннеры-->
	</div>
</div>
</asp:Content>