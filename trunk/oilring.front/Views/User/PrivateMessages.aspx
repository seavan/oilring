<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserObject>"  MasterPageFile="~/Views/Shared/MainUser.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<%
    new UserModule().LinkRouteData().SingleWidget(Html, "PrivateMessagesWidget");%>
</asp:Content>