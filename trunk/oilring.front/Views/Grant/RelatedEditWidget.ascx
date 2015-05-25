<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GrantObject>>" %>
<div class="selectFirm">
	<label for="fgrantSearch">Введите номер гранта:</label>
	<div class="searchWrap">											
		<div class="borderAll10 input">
			<div class="bg">
                <input type="text" value="" id="fgrantSearch" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Grant/AutoCompleteSearch" />
            </div>			
		</div>											
	</div>
	<div class="add" title="Добавить" rel="/<%:Html.LC().LANG_CODE %>/Grant/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Grant/SearchHtmlItemList">Добавить</div>
</div>
<!--/-->
<!---->
<div class="userAddFirm">
	<dfn>Добавленные гранты:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>    
</div>