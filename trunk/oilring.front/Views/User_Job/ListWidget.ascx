<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_JobObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>Работа:</dt>
<dd>
	<ul class="list">
        <%foreach (var item in Model){%>
        <li>
			<%: item.StartYear.ToString("MMMM yyyy г.", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")) %> — <%: item.EndYear.HasValue && !item.State ? item.EndYear.Value.ToString("MMMM yyyy г.", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")) : "настоящее время"%><br />
			<a href="#"><%= HttpUtility.HtmlDecode(item.Title) %></a><br />
			<%if(!string.IsNullOrEmpty(item.Division1)) {%><span>Департамент:</span> <%:item.Division1%><br /><%} %>			
			<%if(!string.IsNullOrEmpty(item.Position)) {%><span>Должность:</span> <%:item.Position%><%} %>
		</li>
        <%} %>		
	</ul>							
</dd>
<%} %>