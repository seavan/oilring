<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<div class="selectFirm">
	<label for="forgsSearch">������� �������� ��������:</label>
	<div class="searchWrap">											
		<div class="borderAll10 input">
			<div class="bg">
                <input type="text" value="" id="forgsSearch" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Organization/AutoCompleteSearch"/>
            </div>			
		</div>											
	</div>
	<div class="add" title="��������" rel="/<%:Html.LC().LANG_CODE %>/Organization/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Organization/SearchHtmlItemList">��������</div>
</div>	
<!--/-->
<!---->
<div class="userAddFirm">
	<dfn>����������� ��������:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>    
</div>