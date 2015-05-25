<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<!--�� ����� ����������-->
<div class="note">
    �������� ����� ���� �� ������ ������������ ����� � ���� ����� ��� �� �������� �������������
    �����, ����������� ������ ����� ������� ��� �� ����������� ����� ����������� ��
    �����������.
</div>

<div class="wrap">
    <!---->
    <div class="selectPeople">
        <label for="fnameAuthor">������� ��� ������:</label>
        <div class="searchWrap">
            <div class="borderAll10 input">
                <div class="bg">
                    <input type="text" value="" id="fnameAuthor" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User/AutoCompleteSearch" />
                </div>
            </div>
        </div>
        <div class="add" title="��������"  rel="/<%:Html.LC().LANG_CODE %>/User/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/User/SearchHtmlItemList">��������</div>
    </div>
    <!--/-->
</div>
<!---->
<div class="userAddPeople">
    <dfn>����������� ������:</dfn>
    <% Html.RenderPartial("RelatedListWidgetAuthor", Model); %>
</div>
<!--/-->
