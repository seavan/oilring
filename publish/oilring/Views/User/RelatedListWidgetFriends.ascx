<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<dl class="peopleBlock">
    <dt>Не в списках:</dt>
    <dd>
        <div class="list">
        <ul>
        <%
            var counter = 0;
            foreach (var item in Model)
            {%>
            
			<li>
                <div title="Удалить" class="delete _deleteUserLink" rel="<%= item.Id %>">Удалить</div>
				<a href="<%=Html.SingleUri(item)%>"><img src="<%=RES.IMAGE_CONTENT_URI%><%=item.SmallAvatar%>" alt="" /><%=item.DisplayName%></a><br />
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%=item.City%></span>
			</li>
            <%
                if ((++counter%3) == 0)
                {%>
        </ul>
        <ul>
            <%
                }
            }%>
               </ul>
         </div>
    </dd>
</dl>