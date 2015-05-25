<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PatentObject>>" %>
<% if (Model.Count() > 0){%>
<dl class="infoBlocks">
	<dt>Патент<%: Model.Count() > 1 ? "ы" : "" %>:</dt>
	<dd>
        <%foreach (var item in Model){%>
		<%: item.Number %>, Россия, Тип защиты<br />
        <%} %>		
	</dd>
</dl>
<%}%>
