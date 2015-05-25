<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_JobObject>>" %>
<dt>Места работы:</dt>
<dd class="_User_JobsList">
    <%foreach(var item in Model) {%><% Html.RenderPartial("ListItemForEdit", item); %><%} %>
	
	<span class="more _AjaxFormForProfile" rel="/<%:Html.LC().LANG_CODE %>/User_Job/GetUserJobForm" rev="._User_JobsList"><span>Добавить</span></span>								
</dd>