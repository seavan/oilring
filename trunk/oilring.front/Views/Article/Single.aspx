﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.ArticleObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<%
    new ArticleModule().LinkRouteData().SingleWidget(Html);%>
</asp:Content>
