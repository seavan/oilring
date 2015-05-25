<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.RegistrationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">
    
    <!--середина-->
	<div id="mainwrap">
        
		<div id="middleWrap" class="borderAll10">
			<div class="borderAll10 middleBlock">
				<a href="/" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
				
                <!--регистрация-->
				<div class="iForm registrationBlock">
					<h1>Регистрация</h1>
					<div class="field">
                       		Регистрация прошла успешно! На адрес электронной почты, указанный при регистрации, выслано письмо с активационным кодом. Пожалуйста, пройдите по ссылке, указанной в письме, для активации аккаунта.
					</div>
					
				</div>
				<!--/регистрация-->
                
			</div>
		</div>
        
	</div>
	<!--/середина-->

</asp:Content>
