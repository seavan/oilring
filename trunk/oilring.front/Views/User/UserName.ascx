<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div class="topPanel borderTop10">
	<div class="userName"><%: Model.FirstName %> <%: Model.MiddleName %> <%: Model.LastName %></div>
</div>