<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<div class="selectFirm">
	<label for="forgsSearch">Введите название компании:</label>
	<div class="searchWrap">											
		<div class="borderAll10 input">
			<div class="bg">
                <input type="text" value="" id="forgsSearch" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Organization/AutoCompleteSearch"/>
            </div>			
		</div>											
	</div>
	<div class="add" title="Добавить" rel="/<%:Html.LC().LANG_CODE %>/Organization/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Organization/SearchHtmlItemList">Добавить</div>
</div>	
<!--/-->
<!---->
<div class="userAddFirm">
	<dfn>Добавленные компаний:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>    
</div>