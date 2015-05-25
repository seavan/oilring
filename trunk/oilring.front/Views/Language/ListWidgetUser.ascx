<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<LanguageObject>>" %>	
<%if(Model !=null && Model.Count()>0) { %>
<dt>Владение языками:</dt>
<dd>
	<ul>		
        <%foreach (var item in Model){%>
        <li><%: item.Title %></li>
        <%} %>
	</ul>							
</dd>
<%} %>