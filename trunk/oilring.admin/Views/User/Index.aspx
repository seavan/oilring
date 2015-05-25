<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" UICulture="ru-RU" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
			
    <%=
        Html.Partial("UserGrid", ViewData)%>
</asp:Content>
