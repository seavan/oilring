<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
            <% using (var form = new CustomUserForm(Html, Model) { Action = "SaveAjax" }.Open())
               {
%>
            <dl class="settingsBlock iForm">
                <%
                   using (var group = new CustomSimpleGroup(Html) {Title = "Основное:"}.Open())
                   {
                       Html.RenderEditor(s => s.UserLogin);
                       Html.RenderEditor(s => s.NewPassword);
                       Html.RenderEditor(s => s.NewPasswordRepeat);
                       Html.RenderEditor(s => s.OldPassword);
                   }
%>
                <%
                   using (var group = new CustomSimpleGroup(Html) {Title = "Настройки подписок:"}.Open())
                   {
%>
                    <ul class="check">
                    <%
                       Html.RenderLiEditor(s => s.Options_SubscribeNews);
                       Html.RenderLiEditor(s => s.Options_SubscribePrivateMessages);
                       Html.RenderLiEditor(s => s.Options_SubscribeNewComments);
                       Html.RenderLiEditor(s => s.Options_SubscribeJoin);
                       Html.RenderLiEditor(s => s.Options_SubscribeFriendRequest);

%>
                    </ul>                       
                       <%
                   }
%>
                <%
                   using (
                       var group =
                           new CustomSimpleGroup(Html) {Title = "Настройки подписок:", DDClass = "privacyBlock"}.Open())
                   {
                       Html.RenderEditor(s => s.Options_ShowAge);
                       Html.RenderEditor(s => s.Options_ShowContacts);
                       Html.RenderEditor(s => s.Options_ShowInterests);
                       Html.RenderEditor(s => s.Options_ShowJobs);
                       Html.RenderEditor(s => s.Options_ShowEducations);
                       Html.RenderEditor(s => s.Options_ShowMiddleName);
                   }
%>
                <dd class="but">
                    <input type="submit" value="Сохранить настройки" class="ibutton _publish draft _ajax " rel="draft" />
                </dd>
            </dl>
            <%
               }%>
        </div>
        <div class="block2">
            <% Html.RenderPartial("BannerBlock"); %>
        </div>
    </div>
</div>
