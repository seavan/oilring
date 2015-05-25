<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.CommentObject>>" %>
<input type="hidden" class="_react" rel="comments" />
<ul class="commentsList">
    <% 
        var currentLevel = 0;
        foreach (var comment in Model)
       {
           while (comment.Level > currentLevel)
           {
               currentLevel++;
               %>
               <ul>
               <%
           }
           while (comment.Level < currentLevel)
           {
               currentLevel--;
               %>
               </ul>
               <%
           }

%>
    <li>
        <div class="descr">
            <div class="_newHook" rel="<%= comment.CreationDate.ToJSCode() %>">
                &nbsp;</div>
            <div class="wrap">
                <div class="info">
                <% if (comment.OwnerUser != null)
{%>
                    <a href='<%= Html.SingleUri(comment.OwnerUser) %>'>
                        <img src="<%= RES.IMAGE_CONTENT_URI %><%= comment.OwnerUser.SmallAvatar %>" alt=""/>
                        <%= comment.OwnerUser.DisplayName %></a>
<%
} else {%>
                    <a >
                        <img src="<%= RES.IMAGE_CONTENT_URI %>pic4.jpg" alt=""/>
                        anonymous</a>
                        <%
}%>
                    <div class="date">
                        <%= comment.CreationDate
                        %></div>
                </div>
                <%= comment.Text %>
                <div class="replyDoor _commentOpener">
                    <span>Ответить</span></div>
                <% (new CommentModule() { Delayed = true, Behave = "_subAddComment", REL_ObjectID = comment.REL_Id, REL_ObjectType = comment.REL_ObjectType, ParentID = comment.Id}).AddWidget(Html); %>
            </div>
        </div>
        <!--2-->
        <%
       }%>
       <%
           while (currentLevel-- > 0)
           {
               %> </ul> <%
           }
%>
</ul>
