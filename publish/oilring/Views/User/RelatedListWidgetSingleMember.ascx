<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<div class="list">

	<ul>
		<%
            int i = 0;
			foreach (var item in Model){%>
            <li>
                <a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a><br />				            
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%= item.City %></span>
			</li>
                <% if (((Model.Count() % 2) == 0 && (Model.Count() / 2) == (i+1)) || ((Model.Count() / 2) == i)) {%>
                </ul><ul>
            <% } %>
        <%++i;} %>
	</ul>

</div>
