<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PatentObject>>" %>
<% if (Model.Count() > 0){%>
<dl class="infoBlocks">
	<dt>������<%: Model.Count() > 1 ? "�" : "" %>:</dt>
	<dd>
        <%foreach (var item in Model){%>
		<%: item.Number %>, ������, ��� ������<br />
        <%} %>		
	</dd>
</dl>
<%}%>
