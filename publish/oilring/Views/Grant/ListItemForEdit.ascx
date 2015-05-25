<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GrantObject>" %>	
<li  class="_id" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<div class="delete" title="Удалить">Удалить</div>
	<a href="<%=Html.SingleUri(Model)%>"><%=Model.Title%></a>
</li>