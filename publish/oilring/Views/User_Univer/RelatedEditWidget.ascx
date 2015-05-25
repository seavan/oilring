<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_UniverObject>>" %>
<dt>Образование:</dt>
<dd class="_User_UniversList">
    <%foreach(var item in Model) {%><% Html.RenderPartial("ListItemForEdit", item); %><%} %>
	
	<span class="more _AjaxFormForProfile" rel="/<%:Html.LC().LANG_CODE %>/User_Univer/GetUserUniverForm" rev="._User_UniversList"><span>Добавить</span></span>
</dd>