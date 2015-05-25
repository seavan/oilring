<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<!--меню-->
<%
    UserObject cu = null;
    bool thisUser = false;
    var menu = new Dictionary<string, string>();

    if (Request.IsAuthenticated)
    {
        cu = ((UserPrincipal)HttpContext.Current.User).CurrentUser;
        thisUser = (cu.Id == Model.Id);
    }

    menu["Личная информация"] = Html.ActionUri("User", "Single", Model.Id);
    //    if( thisUser) menu["Редактировать"] = Html.ActionUri("User", "Edit", Model.Id);
    menu["Коллеги"] = Html.ActionUri("User", "Friends", Model.Id);
    menu["Активность"] = Html.ActionUri("User", "Activity", Model.Id);
    if (thisUser) menu["Обновления"] = Html.ActionUri("User", "Notifications", Model.Id);
    if (thisUser) menu["Сообщения"] = Html.ActionUri("User", "PrivateMessages", Model.Id);
    if (thisUser) menu["Настройки"] = Html.ActionUri("User", "Options", Model.Id);
%>
<ul class="menuMain inside borderTop10">
    <% foreach (var i in menu)
       {
           if (HttpContext.Current.Request.Url.PathAndQuery.Contains(i.Value))
           {%>
    <li class="borderAll10 cur">
        <%= i.Key %></li>
    <%
       }
       else
       { %>
    <li><a href="<%=i.Value%>">
        <%=i.Key%></a></li>
    <% }
   } %>
</ul>
<!--/меню-->
