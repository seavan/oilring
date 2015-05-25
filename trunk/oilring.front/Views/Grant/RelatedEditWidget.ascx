<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GrantObject>>" %>
<div class="selectFirm">
	<label for="fgrantSearch">������� ����� ������:</label>
	<div class="searchWrap">											
		<div class="borderAll10 input">
			<div class="bg">
                <input type="text" value="" id="fgrantSearch" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Grant/AutoCompleteSearch" />
            </div>			
		</div>											
	</div>
	<div class="add" title="��������" rel="/<%:Html.LC().LANG_CODE %>/Grant/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Grant/SearchHtmlItemList">��������</div>
</div>
<!--/-->
<!---->
<div class="userAddFirm">
	<dfn>����������� ������:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>    
</div>