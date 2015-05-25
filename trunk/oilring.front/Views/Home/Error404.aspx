<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">

    <div id="mainwrap">
		<div id="middleWrap" class="borderAll10">
			<div class="borderAll10 middleBlock">
				<a href="/" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
				<!---->
				<div class="txt404">
					К сожалению эта страница не найдена.<br />Воспользуйтесь <a href="<%: Url.Action("SearchResult","Home", null) %>">поиском</a> или начните с <a href="/">главной страницы</a> сайта.
				</div>
				<!--/-->
			</div>
		</div>
	</div>

</asp:Content>
