<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GrantObject>>" %>
<% if (Model.Count() > 0){%>
<dl class="infoBlocks links">
	<dt>�����<%: Model.Count() > 1 ? "�" : "" %>:</dt>
	<dd>
		<ul class="list">
            <%foreach (var item in Model){%>
			<li><%--����� ������<br />--%><a href="<%=Html.SingleUri(item)%>"><%=item.Title%></a></li>			
            <%}%>
		</ul>
	</dd>
</dl>
<%}%>