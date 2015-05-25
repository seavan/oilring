<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<PrivateMessageObject>" MasterPageFile="~/Views/Shared/MainUser.master" %>

<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
    <div id="mainwrap">
        <% Html.RenderPartial("../User/UserName", Model.OwnerUser); %>
        <div id="middleWrap" class="borderBot10">
            <div class="block1 borderAll10">
                <% Html.RenderPartial("../User/Menu", Model.OwnerUser); %>
                <!--�������-->
                <div class="messageBlockIn">
                    <div class="topic">
                        <a href="<%= OilringHtml.SingleAction("PrivateMessages", Model.OwnerUser)  %>" class="allMessage">��� ���������</a>
                        <!--������ ���������-->
                        <div class="filtrSelectBlock actions" style="display: none">
                            <div class="border borderAll10">
                                <!-- ��� ����� ��������� show � ul -->
                                <ul class="borderAll10">
                                    <li>��������</li>
                                    <li>�������</li>
                                </ul>
                            </div>
                        </div>
                        <!--/������ ���������-->
                        <div class="addMessageDoor" style="display: none">
                            �������� ������</div>
                    </div>
                    <!--��������-->
                    <div class="commentsBlock">
                        <h2>
                            <%= Model.AUTO_Subject %></h2>
                                            <%
               var module = new PrivateMessageItemModule(Model) { PageSize = 0}; %>
               <%
               module.List(Html); %>
                <% Html.RenderPartial("AddWidget", new PrivateMessageItemObject() { REL_Id = Model.Id, REL_ObjectType = Model.REL_ObjectType }); %>
                    </div>
                    <!--/��������-->
                </div>
            </div>
            <div class="block2">
                <% Html.RenderPartial("BannerBlock"); %>
            </div>
        </div>
    </div>
</asp:Content>
