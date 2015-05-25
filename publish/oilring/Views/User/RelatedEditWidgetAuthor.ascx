<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<!--по клику раскрываем-->
<div class="note">
    Авторами могут быть не только пользователи сайта – если автор ещё не является пользователем
    сайта, добавляющий статью может выслать ему по электронной почте приглашение на
    регистрацию.
</div>

<div class="wrap">
    <!---->
    <div class="selectPeople">
        <label for="fnameAuthor">Введите имя автора:</label>
        <div class="searchWrap">
            <div class="borderAll10 input">
                <div class="bg">
                    <input type="text" value="" id="fnameAuthor" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User/AutoCompleteSearch" />
                </div>
            </div>
        </div>
        <div class="add" title="Добавить"  rel="/<%:Html.LC().LANG_CODE %>/User/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/User/SearchHtmlItemList">Добавить</div>
    </div>
    <!--/-->
</div>
<!---->
<div class="userAddPeople">
    <dfn>Добавленные авторы:</dfn>
    <% Html.RenderPartial("RelatedListWidgetAuthor", Model); %>
</div>
<!--/-->
