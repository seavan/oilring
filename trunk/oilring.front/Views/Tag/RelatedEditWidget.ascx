<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TagObject>>" %>
<!---->
<div class="selectTags">
    <label for="ftagsSearch">Введите тэги:</label>
    <div class="searchWrap">
        <div class="borderAll10 input">
            <div class="bg">
                <input type="text" value="" id="ftagsSearch" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Tag/AutoCompleteSearch" />
            </div>
        </div>
    </div>
    <div class="add" title="Добавить" rel="/<%:Html.LC().LANG_CODE %>/Tag/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Tag/SearchHtmlItemList">Добавить</div>
</div>
<!--/-->
<!---->
<ul class="userAddTags _editList">
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>    
</ul>
<!--/-->
