<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UserObject>>"  MasterPageFile="~/Views/Shared/MainUserList.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">	

<div id="middleWrap" class="borderBot10">
	<div class="block1 borderAll10">
            <% var obj = new UserModule() { PageSize = 18 }.LinkRouteData();
               ViewData["AffectedModuleId"] = obj.ModuleId;
               %>

		<% Html.RenderPartial("AlphabetFilter"); %>

		<div class="peopleBlockIn">
			<dl class="list">
				<% obj.List(Html); %>
			</dl>
            <% obj.Pager(Html); %>
		</div>
	</div>
	<div class="block2">
		<!--баннеры-->
        <% Html.RenderPartial("BannerBlock"); %>
        <!--/баннеры-->
	</div>
</div>
</asp:Content>