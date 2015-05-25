<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<!---шапка-->
<div id="header">    
    
    <div id="loginBlock">
    <%if(Request.IsAuthenticated) {%>
    <% Html.RenderPartial("HeaderAuthBlock", new UserObject()); %>
    <%} else {%>
    <% Html.RenderPartial("HeaderNoAuthBlock", new AuthenticationModel()); %>
    <%} %>
    </div>

    <div class="mainCont borderBot10">
        <a href="/" class="logo">
            <img src="<%= RES.I_CONTENT_URI %>logo.png" alt="Oil Ring Инновационная научная среда для нефтегазовой отрасли"
                title="Oil Ring Инновационная научная среда для нефтегазовой отрасли" /></a>
        <% Html.RenderPartial("MenuTopBlock"); %>
        <% Html.RenderPartial("LangSelectorBlock"); %>
        <% Html.RenderPartial("SearchBlock"); %>
        <% Html.RenderPartial("PromoBlock"); %>
    </div>
</div>
<!--/шапка-->
