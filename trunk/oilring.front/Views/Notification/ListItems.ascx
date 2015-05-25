<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<NotificationObject>>" %>	
                <ul class="materialList">
<% foreach (var item in Model)
   {%>
    <li>
        <div class="bgWrap">
            <div class="date">
                <%= item.CreationDate.ToStringVerboseDateTime() %></div>
            <div class="autor">
            <% if (item.RelatedUser != null)
{ %>
                    <a href="<%=Html.SingleUri(item.RelatedUser)%>">
<img src="<%=RES.IMAGE_CONTENT_URI%><%=item.RelatedUser.SmallAvatar%>" alt="" /><%=item.RelatedUser.DisplayNameBr%></a> <% } %></div>
            <div class="descr">
                <%= item.Text %></div>
            <div class="actions">
                <% if (item.IsAcceptable && item.IsDenyable) { %><span class="take _notificationAction" data-uri='<%= Html.SingleUserAction<NotificationObject>(item, "AcceptNotification") %>'>Принять</span> &nbsp;&nbsp;/&nbsp;&nbsp; 
<span class="reject _notificationAction" data-uri='<%= Html.SingleUserAction<NotificationObject>(item, "RejectNotification") %>'>Отклонить</span><% } %> 
<% if (item.IsAccepted.HasValue && item.IsAccepted.Value)
{ %><span class="actionDone actionDoneAccept">Принято</span><% } %>
<% if (item.IsDenied.HasValue && item.IsDenied.Value)
{ %><span class="actionDone actionDoneReject">Отказано</span><% } %>
&nbsp;&nbsp; <span class="reject _notificationAction" data-uri='<%= Html.SingleUserAction<NotificationObject>(item, "DeleteNotification") %>'>Удалить</span>
            </div>
        </div>
    </li>

<%
   }%>
		</ul>