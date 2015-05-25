<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ContactObject>>" %>	
<%if(Model != null && Model.Count()>0) {%>
<dt>Контактная информация:</dt>
    <dd>
	    <ul>
<%foreach(var item in Model) {%>
<%if(item.ContactType == "mail") {%>
<li><a href="mailto:<%: item.Value %>" class="<%: item.ContactType %>"><%: item.Value %></a></li>
<%} else {%>
<li class="<%: item.ContactType %>"><%: item.Value %></li>
<%} %>



<%} %>
        </ul>
    </dd>
<%} %>