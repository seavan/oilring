<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="m_Page" runat="server">

<div id="mainwrap" class="_recoverPass">
    <%
        var text = string.Empty;
        if(ViewData["notifiText"]!=null)
        {
            text = ViewData["notifiText"] as string;
        }
%>
	<div id="middleWrap" class="borderAll10">
		<div class="borderAll10 middleBlock">
			<a href="#" class="logo"><img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли" title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
			<!--регистрация-->
			<div class="iForm registrationBlock3">
				<h1>Восстановление пароля</h1>
				<div class="field">
                    <%if(string.IsNullOrEmpty(text)) {%>
                    На указанный вами электронный адрес были высланы<br/>дальнейшие инструкции по сбросу пароля.
                    <%} else { Response.Write(text);}%>
                    <br/><br/>
                    Вы можете продолжить работу с <a href="/">главной страницы</a> сайта.
				</div>                                
			</div>
			<!--/регистрация-->
		</div>
	</div>
    
</div>

</asp:Content>
