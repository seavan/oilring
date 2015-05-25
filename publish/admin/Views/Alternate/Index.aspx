
	<%--Admin view code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Generated on: Tue Jun 14 04:03:20 UTC+0400 2011
	Table alias:	Alternate
	File name: 	Alternate.controller.cs--%>
    			
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" UICulture="ru-RU" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("AlternateGrid", ViewData)%>
</asp:Content>
