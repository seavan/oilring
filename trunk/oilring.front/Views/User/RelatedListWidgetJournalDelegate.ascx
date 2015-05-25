<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>

<%if(Model.Count()>0) {%>
<dl class="autorJournal">
	<dt>Представител<%: Model.Count() > 1 ? "и" : "ь" %></dt>
    <%foreach (var item in Model){%>
	<dd>
		<a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a><br />
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%= item.City %></span>						
	</dd>
    <%} %>
</dl>	
<%} %>

