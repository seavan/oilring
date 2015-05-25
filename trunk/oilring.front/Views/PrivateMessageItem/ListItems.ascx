<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PrivateMessageItemObject>>" %>
<input type="hidden" class="_react" rel="privatemessageitems" />
<ul class="commentsList">
<% foreach (var item in Model)
   { %>
    <li>
        <div class="descr">
            <div class="wrap">
                <div class="info">
				<a href="<%= Html.SingleUri(item.SenderUser) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SenderUser.SmallAvatar%>" alt="" /><%= item.SenderUser.DisplayName %></a>
                    <div class="date">
                        <%= item.CreationDate.ToStringVerboseDateTime() %></div>
                </div>
<%= item.Text %>
            </div>
        </div>
    </li>
<% } %>
</ul>
