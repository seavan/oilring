<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IUserEnhancable>" %>
<%if(Request.IsAuthenticated && Model.PSEUDO_IsUserEditable) {%>
<div class="edit" style="display: block"><% Html.EditLink((Database.Entities.IDatabaseEntity)Model, "Редактировать"); %></div>
<%} %>