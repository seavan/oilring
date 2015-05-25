<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<PrivateMessageObject>" MasterPageFile="~/Views/Shared/MainUser.master" %>

<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
    <div id="mainwrap">
        <% Html.RenderPartial("../User/UserName", Model.OwnerUser); %>
        <div id="middleWrap" class="borderBot10">
            <div class="block1 borderAll10">
                <% Html.RenderPartial("../User/Menu", Model.OwnerUser); %>
                <!--профиль-->
                <div class="messageBlockIn">
                    <div class="topic">
                        <a href="<%= OilringHtml.SingleAction("PrivateMessages", Model.OwnerUser)  %>" class="allMessage">Все сообщения</a>
                        <!--фильтр выпадашка-->
                        <div class="filtrSelectBlock actions" style="display: none">
                            <div class="border borderAll10">
                                <!-- при клике добавляем show к ul -->
                                <ul class="borderAll10">
                                    <li>Операции</li>
                                    <li>Удалить</li>
                                </ul>
                            </div>
                        </div>
                        <!--/фильтр выпадашка-->
                        <div class="addMessageDoor" style="display: none">
                            Написать письмо</div>
                    </div>
                    <!--комменты-->
                    <div class="commentsBlock">
                        <h2>
                            <%= Model.AUTO_Subject %></h2>
                                            <%
               var module = new PrivateMessageItemModule(Model) { PageSize = 0}; %>
               <%
               module.List(Html); %>
                <% Html.RenderPartial("AddWidget", new PrivateMessageItemObject() { REL_Id = Model.Id, REL_ObjectType = Model.REL_ObjectType }); %>
                    </div>
                    <!--/комменты-->
                </div>
            </div>
            <div class="block2">
                <% Html.RenderPartial("BannerBlock"); %>
            </div>
        </div>
    </div>
</asp:Content>
