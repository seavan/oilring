	
<%--/*
	Admin view code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Generated on: Tue Jun 14 03:48:51 UTC+0400 2011
	Table alias:	New
	File name: 	New.controller.cs
*/--%>
			
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" UICulture="ru-RU" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("NewGrid", ViewData)%>
</asp:Content>
