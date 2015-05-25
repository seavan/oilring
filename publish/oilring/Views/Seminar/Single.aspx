<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.SeminarObject>"  MasterPageFile="~/Views/Shared/MainInner.master" %>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<%
    new SeminarModule().LinkRouteData().SingleWidget(Html);%>
</asp:Content>