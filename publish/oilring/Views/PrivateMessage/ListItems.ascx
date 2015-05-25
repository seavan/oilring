<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PrivateMessageObject>>" %>
<input type="hidden" class="_react" rel="privatemessages" />
<ul class="materialList">
    <%
        var m  = Model.Where(s => s.SenderUser != null);
        foreach (var item in m)
       { %>
    <li>
        <div class="bgWrap">
            <input type="checkbox" class="_selectedMessages _selection" value="" rel="<%= item.Id %>"/>
            <div class="date">
                <%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringVerboseDateTime() : item.CreationDate.ToStringVerboseDateTime()%></div>
            <div class="autor">
				<a href="<%= Html.SingleUri(item.SenderUser) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SenderUser.SmallAvatar%>" alt="" /><%= item.SenderUser.DisplayName %></a>
				</div>
            <div class="descr">
                <a href="<%= Html.SingleUri(item) %>"><%= item.AUTO_Subject.Ellipsis(70) %> (<%= item.AUTO_Item_Count %>)</a><br>
                <%= item.AUTO_Text.Ellipsis(70) %></div>
        </div>
    </li>
    <% } %>
</ul>
