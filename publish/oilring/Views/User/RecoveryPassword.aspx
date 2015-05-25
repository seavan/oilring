<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.RecoveryPassword>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">

<div id="mainwrap" class="_recoverPass">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("RecoveryPassword","User", FormMethod.Post, new {Lang= Html.LC().LANG_CODE})) { %>
	<div id="middleWrap" class="borderAll10">
		<div class="borderAll10 middleBlock">
			<a href="#" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
			<!--регистрация-->
			<div class="iForm registrationBlock3">
				<h1>Восстановление пароля</h1>
				<div class="field">
                    <%: Html.LabelFor(m => m.EMail, new { @class = "name" })%>
                    <div class="borderAll10 input"><div><%: Html.TextBoxFor(m => m.EMail, new { tabindex = 1, @class = "_emailString" })%></div></div>						
                    <div class="error"><%: Html.ValidationMessageFor(m => m.EMail)%></div>					
				</div>
				<div class="code">
					<div class="_captcha" style="width:140px;"><% Html.RenderPartial("Captcha"); %></div>
					<a href="#" class="update" rel="<%:Url.Action("GetNewImageCaptcha", "User", new { Lang = Html.LC().LANG_CODE })%>">обновить</a>
					<div class="field">
                        <%: Html.LabelFor(m => m.Captcha, new { @class = "name" })%>
                        <div class="borderAll10 input"><div><%: Html.TextBoxFor(m => m.Captcha, new { tabindex = 2, @class = "_CaptchaString" })%></div></div>						
                        <div class="error"><%: Html.ValidationMessageFor(m => m.Captcha)%></div>					
				    </div>
				</div>

                <div class="errorAuth" style="padding:0px;"><%: Html.ValidationMessage("AdditionalError")%></div>
				<div class="but"><input type="submit" value="Продолжить" class="ibutton entryButton3" /></div>
			</div>
			<!--/регистрация-->
		</div>
	</div>
    <%} %>
</div>

</asp:Content>
