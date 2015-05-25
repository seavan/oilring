<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_UniverObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>Образование:</dt>
<dd>
	<ul class="list">
        <%foreach (var item in Model){%>
        <li>
			<%: item.StartYear.Year %> г. — <%: item.EndYear.HasValue && !item.State ? item.EndYear.Value.Year + " г." : "настоящее время"%><br />
			<a href="#"><%= HttpUtility.HtmlDecode(item.Title) %></a><br />
			<%if(!string.IsNullOrEmpty(item.Faculty)) {%><span>Факультет:</span> <%:item.Faculty%><br /><%} %>
			<%if(!string.IsNullOrEmpty(item.Department)) {%><span>Кафедра:</span> <%:item.Department %><br /><%} %>
			<%if(!string.IsNullOrEmpty(item.Group)) {%><span>Группа:</span> <%:item.Group %><%} %>
		</li>
        <%} %>		
	</ul>							
</dd>
<%} %>