<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Web.AuthenticationModel>" %>
<!--вход-->
<div class="entryBlock<%: Model.isValid ? "" : " show" %>"><!--при клике добавляем класс show-->
    <% Html.EnableClientValidation(); %>
	<span class="entryDoor">Войти</span> или <a href="<%:Url.Action("Register", "User", new { Lang = Html.LC().LANG_CODE })%>" class="register">зарегистрироваться</a>
	<% using (Html.BeginForm("SignIn","User", FormMethod.Post, new {Lang= Html.LC().LANG_CODE})) { %>
        <div class="userEnter">
		    <dfn>Вход</dfn>
        
		    <div class="wrap iForm">
			    <div class="field">				    
                    <%: Html.LabelFor(m => m.Login, new { @class = "name" })%>
				    <div class="borderAll10 input"><div><%: Html.TextBoxFor(m => m.Login, new { tabindex = 1 })%></div></div>	
                    
				    <label for="<%: Html.IdFor(m=>m.RememberMe) %>" class="forget"><%: Html.CheckBoxFor(m => m.RememberMe, new { tabindex = 3 })%>Запомнить меня</label>
			    </div>
			    <div class="field">
				    <%: Html.LabelFor(m => m.Password, new { @class = "name" })%>
				    <div class="borderAll10 input"><div><%: Html.PasswordFor(m => m.Password, new { tabindex = 2})%></div></div>		
				    <a href="<%: Url.Action("RecoveryPassword", "User", new { Lang = Html.LC().LANG_CODE })%>">Я забыл пароль</a>
			    </div>
		    </div>
        
            <div class="errorAuth"><%: Html.ValidationSummary(false, null)%></div>
		    <div class="but"><input type="submit" value="Войти" class="ibutton entryButton" tabindex="4" /></div>
	    </div>
    <%} %>
</div>
<!--/вход-->
<% if (ViewData["SignOut"] != null)
   { %>
   <script> window.location = "/"; </script>
<% } %>