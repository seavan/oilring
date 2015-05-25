<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PrivateMessageObject>" %>
<div class="popup addMessageBlock _amb1">
    <!-- по клику показываем -->
    <div class="bgBlock">
        <% using (var form = new CustomForm(Html)
           {
               Action = "AddMessageThread",
               ListClass = "iForm addComment"
           }.Open())
           {%>
        <dfn>Новое письмо</dfn>
        <div class="wrap iForm">
        <input type="hidden" class="_affect" rel="privatemessages" />
            <span class="_validation _validationError" rel="REL_ReceiverUserId"></span>
            <div class="field searchFriends">
                <label for="fnameAuthor">
                    Кому:</label>
                <div class="searchWrap">
                    <div class="borderAll10 input">
                            <div class="bg">
                            <input type="text" value="" id="REL_ReceiverUser" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE%>/User/AutoCompleteSearch" />
                            <input type="hidden" id="REL_ReceiverUserId" name="REL_ReceiverUserId" val="" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="field">
                <% Html.RenderEditor(m => m.AUTO_Subject); %>
            </div>
            <div class="field">
                <% Html.RenderEditor(m => m.AUTO_Text); %>
            </div>
        </div>
        <div class="but">
            <input type="submit" value="Отправить" class="ibutton _ajax _clean"/></div>
    </div>
    <% } %>
</div>
