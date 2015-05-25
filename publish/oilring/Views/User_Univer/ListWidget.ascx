<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_UniverObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>�����������:</dt>
<dd>
	<ul class="list">
        <%foreach (var item in Model){%>
        <li>
			<%: item.StartYear.Year %> �. � <%: item.EndYear.HasValue && !item.State ? item.EndYear.Value.Year + " �." : "��������� �����"%><br />
			<a href="#"><%= HttpUtility.HtmlDecode(item.Title) %></a><br />
			<%if(!string.IsNullOrEmpty(item.Faculty)) {%><span>���������:</span> <%:item.Faculty%><br /><%} %>
			<%if(!string.IsNullOrEmpty(item.Department)) {%><span>�������:</span> <%:item.Department %><br /><%} %>
			<%if(!string.IsNullOrEmpty(item.Group)) {%><span>������:</span> <%:item.Group %><%} %>
		</li>
        <%} %>		
	</ul>							
</dd>
<%} %>