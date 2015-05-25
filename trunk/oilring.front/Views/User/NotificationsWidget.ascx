<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
            <div class="eventBlockIn">
                    <%
               var module = new NotificationModule(Model) { PageSize = 8 }; %>
               <%
               module.List(Html).Pager(Html); %>
            </div>
    </div>
            <div class="block2">
                <% Html.RenderPartial("BannerBlock"); %>
            </div>
        </div>
    </div>
