<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_DegreeObject>>" %>
<dt>������ ������ � �������:</dt>
<dd class="_User_DegreesList">
    <%foreach(var item in Model) {%><% Html.RenderPartial("ListItemForEdit", item); %><%} %>
	
	<span class="more _AjaxFormForProfile" rel="/<%:Html.LC().LANG_CODE %>/User_Degree/GetUserDegreeForm" rev="._User_DegreesList"><span>��������</span></span>								
</dd>