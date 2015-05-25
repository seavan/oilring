<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PrivateMessageObject>" %>
<div class="popup addMessageBlock _amb2">
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
        <%= Html.HiddenFor(m => m.REL_ReceiverUserId) %>
        <input type="hidden" class="_affect" rel="privatemessages" />
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
