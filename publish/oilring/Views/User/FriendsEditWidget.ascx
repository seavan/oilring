<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>

<%
    UserObject cu = null;
    bool thisUser = false;

    if (Request.IsAuthenticated)
    {
        cu = ((UserPrincipal)HttpContext.Current.User).CurrentUser;
        thisUser = cu.Id == Model.Id;
    }
%>   
    <div id="middleWrap" class="borderBot10 <%= thisUser ? "" : "_disableEdit" %>">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
<div class="profileBlockEdit">
					<div class="edit" style="margin-bottom: 10px"><a href="#">Управление списками</a></div>
                    <h2>Управление списками</h2>
                    <span class="more _createUserGroupPopup"><span>Создать список</span></span>
                    <div class="_userGroupList">
					<%
                       var ugModule = new User_GroupModule(Model) {};
                       ugModule.ListWidget(Html);
                    %>
                    </div>
					<!--Не в списках-->
					<%
                        var module = new UserModule(Model) { Behave = "availableUsers", Relation = "GroupFriendLink", ViewName = "RelatedListWidgetFriends" };
                       module.List(Html);
                    %>
					<!--/Не в списках-->

				</div>
        </div>
        <div class="block2">
            <% Html.RenderPartial("BannerBlock"); %>
        </div>
    </div>
</div>
