<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserObject>"  MasterPageFile="~/Views/Shared/MainUser.master" %>	
<asp:Content ContentPlaceHolderID="m_Popups" runat="server">
    <% 
        Html.RenderPartial("../PrivateMessage/AddMessageBlockPopup2", new PrivateMessageObject() { REL_ReceiverUserId = Model.Id });
    %>

</asp:Content>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<%
    new UserModule().LinkRouteData().SingleWidget(Html);%>
</asp:Content>