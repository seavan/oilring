<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" UICulture="ru-RU" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
			
    <%=
        Html.Partial("User_UniversityGrid", ViewData)%>
</asp:Content>
