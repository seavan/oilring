<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<div class="list">
 	<ul>
        <%
            int counter = 0;
            int counterUl = 1;
            foreach (var item in Model)
            {
                if (counter % 3 == 0)
                {%></ul><ul <%: counterUl > 3 ? "style=display:none;" : "" %>><%++counterUl;}
                    %>
                    <li>
                        <a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a><br />			            
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%= item.City %></span>
			        </li>

        <%
                ++counter;
            } %>
        </ul>	

</div>
