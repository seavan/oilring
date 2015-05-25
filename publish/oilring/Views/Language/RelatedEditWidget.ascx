<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<LanguageObject>>" %>

<dt>Владение языками:</dt>
<dd class="language">
	<ul class="_editLanguageList">
        <%foreach(var item in Model) {%><% Html.RenderPartial("ListItemForEdit", item); %><%} %>		
	</ul>

    <span class="more _AjaxFormForProfile _popapAjax" rel="/<%:Html.LC().LANG_CODE %>/Language/GetLanguageForm" rev="body"><span>Добавить</span></span>
	
</dd>
