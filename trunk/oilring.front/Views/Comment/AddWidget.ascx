<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.db.CommentObject>" %>
<% using (var form = new CustomForm(Html) { 
       Action = "AddComment#commentAdd", 
       ListClass = "iForm addComment"}.Open() )
   {%>
    <%= Html.HiddenFor(model => model.Parent_Comment_ID) %>
    <%= Html.HiddenFor(model => model.REL_Id) %>
    <%= Html.HiddenFor(model => model.REL_ObjectType) %>
    <input type="hidden" class="_affect" rel="comments" />
    <dt>Оставить комментарий</dt>
    <dd>
        <div class="buttons" style="display: none">
            <span class="bold">bold</span> <span class="italic">italic</span> <span class="underline">
                underline</span>
        </div>
        <div class="borderAll10 textarea">
            <div>
                <%= Html.TextAreaFor( model => model.Text) %></div>
        </div>
        <input type="submit" value="Опубликовать" class="ibutton _ajax _clean"/>
    </dd>
<%
   }
   %>
