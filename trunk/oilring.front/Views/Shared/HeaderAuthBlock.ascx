<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
    <div class="createEntryBlock borderBot10">
    <a href="<%= Html.CreateDraft<ArticleObject>() %>">Статью</a>
    <a href="<%= Html.CreateDraft<SeminarObject>() %>">Семинар</a>
    <a href="<%= Html.CreateDraft<ConferenceObject>() %>">Конференцию</a>
    <a href="<%= Html.CreateDraft<DiscussionObject>() %>">Дискуссию</a>
    <a href="<%= Html.CreateDraft<GrantObject>() %>">Грант</a>
    <a href="<%= Html.CreateDraft<TechnoObject>() %>">Технологию</a>
    </div>

<div class="topPanel borderTop10">
    <!--авторизованный-->
    <div class="userPanel">
        <%
            UserObject curUser;
            
            try
            {
                curUser = ((UserPrincipal)Context.User).CurrentUser;
            }
            catch
            {
                curUser = Model;
            }

            if (curUser != null && curUser.Id > 0)
            {
        %>

        <a href="<%= Html.SingleUri(curUser) %>" class="avatar">
            <img src="<%= RES.IMAGE_CONTENT_URI %><%=curUser.SmallAvatar%>" alt="" />
            <%= curUser.FirstName%><br />
            <%= curUser.LastName%>
        </a>

        <%--<div class="info">(<a href="#">10</a> новых событий, <a href="#">3</a> новых письма)</div>--%>

        <%} %>        

        <div class="userMaterialsBlock">
            <div class="addDoor">
                <span>Добавить</span></div>
        </div>
               
        <span class="exit" rel="<%:Url.Action("SignOut", "User", new { Lang = Html.LC().LANG_CODE })%>">Выйти</span>
    </div>
    <!--/авторизованный-->
    <%
        var cookie = ViewData["Cookie"] as HttpCookie;
        if (cookie != null)
        {
            Html.ViewContext.Writer.WriteLine("<script>setCookie('{0}', '{1}', {{ expires: 10000, path: '{3}' }}); /* $('body').find('._module').each(function () {{ updateModule($(this)) }}); */ window.location.reload(); </script>", cookie.Name, cookie.Value, cookie.Domain + ":" + HttpContext.Current.Request.Url.Port, cookie.Path);
        }
%>
</div>
