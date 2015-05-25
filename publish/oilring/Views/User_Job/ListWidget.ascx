<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_JobObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>������:</dt>
<dd>
	<ul class="list">
        <%foreach (var item in Model){%>
        <li>
			<%: item.StartYear.ToString("MMMM yyyy �.", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")) %> � <%: item.EndYear.HasValue && !item.State ? item.EndYear.Value.ToString("MMMM yyyy �.", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")) : "��������� �����"%><br />
			<a href="#"><%= HttpUtility.HtmlDecode(item.Title) %></a><br />
			<%if(!string.IsNullOrEmpty(item.Division1)) {%><span>�����������:</span> <%:item.Division1%><br /><%} %>			
			<%if(!string.IsNullOrEmpty(item.Position)) {%><span>���������:</span> <%:item.Position%><%} %>
		</li>
        <%} %>		
	</ul>							
</dd>
<%} %>