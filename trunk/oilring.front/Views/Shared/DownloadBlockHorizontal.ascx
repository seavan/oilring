<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Database.Entities.IDatabaseEntity>" %>
<%
    new FileAttachmentModule(Model) {}.ListWidget(Html);%>