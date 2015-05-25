<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.PrivateMessageItemObject>" %>
<% using (var form = new CustomForm(Html) { 
       Action = "AddMessage", 
       ListClass = "iForm addComment"}.Open() )
   {%>
    <%= Html.HiddenFor(model => model.REL_Id) %>
    <%= Html.HiddenFor(model => model.REL_ObjectType) %>
    <input type="hidden" class="_affect" rel="privatemessageitems" />
    <dt>Ответ</dt>
    <dd>
        <div class="buttons" style="display: none">
            <span class="bold">bold</span> <span class="italic">italic</span> <span class="underline">
                underline</span>
        </div>
        <div class="borderAll10 textarea">
            <div>
                <%= Html.TextAreaFor( model => model.Text) %></div>
        </div>
        <input type="submit" value="Отправить" class="ibutton _ajax _clean"/>
    </dd>
<%
   }
   %>
