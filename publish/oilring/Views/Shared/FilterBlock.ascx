<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% var tagModule = (new TagModule() { PageSize = 0, UserFilter = 1 }); %>
<!--подборка-->
<div class="mainFiltr borderTop1 _bak">
    <!-- при наведении показываем -->
    <div class="generalWrap">
        <dl class="myChoice">
            <dt><%= Html.LC().Selector_My %> <span class="clearSelection"><%= Html.LC().Selector_Clear %></span> </dt>
            <dd><% Html.RenderAction("MyChoice", "Rubric", null); %></dd>
        </dl>
        <dl>
            <dt><%= Html.LC().Selector_Classification %></dt>
            <dd>
                <div class="field">
                    <span class="name"><%= Html.LC().Selector_Field %></span>
                    <ul class="sectionList _section borderAll10">
                    </ul>
                    <div class="add _addSection" title="Добавить область">
                        Добавить</div>
                </div>
                <div class="field">
                    <span class="name"><%= Html.LC().Selector_Field %></span>
                    <ul class="sectionList _subSection borderAll10">
                    </ul>
                    <div class="add _addSubSection" title="Добавить область">
                        Добавить</div>
                </div>
                <div class="field">
                    <span class="name"><%= Html.LC().Selector_Category %></span>
                    <div class="categoryList _category borderAll10">
                        <ul>
                        </ul>
                        <ul>
                        </ul>
                        <ul>
                        </ul>
                    </div>
                </div>
            </dd>
        </dl>
    </div>
    <dl class="tagList">
        <dt><%= Html.LC().Selector_CanUseTags %>:</dt>
        <dd>
            <ul>
                <% tagModule.ListWidget(Html); %>
            </ul>
        </dd>
    </dl>
    <div class="buttonsBlock">
        <span class="ibutton" rel="/<%:Html.LC().LANG_CODE %>/Rubric/SetSelectRubrics"><%= Html.LC().Command_Save %></span> <span class="ibutton"><%= Html.LC().Command_Cancel %></span>
    </div>
</div>
<!--/подборка-->
