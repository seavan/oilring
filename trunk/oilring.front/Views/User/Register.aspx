<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.RegistrationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">
    <% Html.EnableClientValidation(); %>
    <!--середина-->
	<div id="mainwrap">
        <% using (Html.BeginForm("Register","User", FormMethod.Post, new {Lang= Html.LC().LANG_CODE})) { %>
		<div id="middleWrap" class="borderAll10">
			<div class="borderAll10 middleBlock">
				<a href="/" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
				
                <!--регистрация-->
				<div class="iForm registrationBlock">
					<h1>Регистрация</h1>
					<div class="field">
                        <%: Html.LabelFor(m => m.EMail, new { @class="name"})%>						
						<div class="borderAll10 input"><div><%:Html.TextBoxFor(m => m.EMail, new { rev=Url.Action("CheckHasEmail", "User", new { Lang = Html.LC().LANG_CODE })})%></div></div>	
                        <div class="error"><%: Html.ValidationMessageFor(m => m.EMail)%></div>					
					</div>
					<div class="field">
						<%: Html.LabelFor(m => m.FirstName, new { @class = "name" })%>			
						<div class="borderAll10 input"><div><%:Html.TextBoxFor(m=>m.FirstName) %></div></div>	
                        <div class="error"><%: Html.ValidationMessageFor(m => m.FirstName)%></div>					
					</div>
					<div class="field">
						<%: Html.LabelFor(m => m.LastName, new { @class = "name" })%>	
						<div class="borderAll10 input"><div><%:Html.TextBoxFor(m=>m.LastName) %></div></div>	
                        <div class="error"><%: Html.ValidationMessageFor(m => m.LastName)%></div>					
					</div>
					<div class="field">
						<%: Html.LabelFor(m => m.Password, new { @class = "name" })%>	
						<div class="borderAll10 input"><div><%:Html.PasswordFor(m => m.Password)%></div></div>	
                        <div class="error"><%: Html.ValidationMessageFor(m => m.Password)%></div>					
					</div>
					<div class="field">
						<%: Html.LabelFor(m => m.PasswordConfirm, new { @class = "name" })%>	
						<div class="borderAll10 input"><div><%:Html.PasswordFor(m=>m.PasswordConfirm) %></div></div>		
						<div class="error"><%: Html.ValidationMessageFor(m => m.PasswordConfirm)%></div>
					</div>
					<div class="field">
						<label for="<%:Html.IdFor(m=>m.AgreementConfirm) %>" class="agree"><%:Html.CheckBoxFor(m=>m.AgreementConfirm) %>Я согласен с <span>правилами</span></label>
                        <div class="error"><%: Html.ValidationMessageFor(m => m.AgreementConfirm)%></div>
					</div>
					<div class="but"><input type="submit" value="Зарегистрироваться" class="ibutton hide" /></div>
				</div>
				<!--/регистрация-->
                
			</div>
		</div>
        <%} %>
	</div>
	<!--/середина-->

</asp:Content>
