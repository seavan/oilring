<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.AuthenticationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">
    <% Html.EnableClientValidation(); %>
    <!--середина-->
	<div id="mainwrap" class="_staticAutch">
        <% using (Html.BeginForm("SignIn","User", FormMethod.Post, new {Lang= Html.LC().LANG_CODE})) { %>
		<div id="middleWrap" class="borderAll10">
			<div class="borderAll10 middleBlock">
				<a href="/" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
				
                <!--регистрация-->
				<div class="iForm registrationBlock2">
					<h1>Вход</h1>
                    <%
                    if( ViewData["activation_message"] != null )
                    {
                        %>
                         <div class="field"><%= ViewData["activation_message"] %></div>
                        <%
                    } %>
                    <div class="field">
                        <%: Html.LabelFor(m => m.Login, new { @class = "name" })%>
                        <div class="borderAll10 input"><div><%: Html.TextBoxFor(m => m.Login, new { tabindex = 1})%></div></div>						
                        <div class="error"><%: Html.ValidationMessageFor(m => m.Login)%></div>					
					</div>
					<div class="field">
						<%: Html.LabelFor(m => m.Password, new { @class = "name" })%>
                        <div class="borderAll10 input"><div><%: Html.PasswordFor(m => m.Password, new { tabindex = 2})%></div></div>						
                        <div class="error"><%: Html.ValidationMessageFor(m => m.Password)%></div>					
					</div>					
					<div class="field">
                        <label for="<%: Html.IdFor(m=>m.RememberMe) %>" class="forget"><%: Html.CheckBoxFor(m => m.RememberMe, new { tabindex = 3 })%>Запомнить меня</label>						
					</div>
                    <div class="errorAuth" style="padding:0px;"><%: Html.ValidationMessage("AdditionalError")%></div>
					<div class="but"><input type="submit" value="Войти" class="ibutton entryButton2" /></div>
				</div>
				<!--/регистрация-->
                <div style="display:none;">
                    <%: Html.CheckBoxFor(m=>m.isAjax, false) %>
                    <%: Html.Hidden("UrlReturn", Request.QueryString["UrlReturn"])%>
                </div>
			</div>
		</div>
        <%} %>
	</div>

    <%
        var cookie = ViewData["Cookie"] as HttpCookie;
        if (cookie != null)
        {

            Html.ViewContext.Writer.WriteLine("<script>$(document).children('*').hide(); setCookie('{0}', '{1}', {{ expires: 10000, path: '{3}' }}); /* $('body').find('._module').each(function () {{ updateModule($(this)) }}); */ window.location = '{4}'; </script>", cookie.Name, cookie.Value, cookie.Domain + ":" + HttpContext.Current.Request.Url.Port, cookie.Path, ViewData["ReturnUrl"] != null ? ViewData["ReturnUrl"].ToString().Replace("~/", "/") : "/");
        }
%>
	<!--/середина-->
</asp:Content>
