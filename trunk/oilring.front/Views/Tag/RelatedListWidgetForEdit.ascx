<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TagObject>>" %>

<%foreach(var tag in Model) {%>
<li class="_id <%= tag.Id == 0 ? "_create" : "" %>" rel='<%= tag.Id %>' rev='<%= tag.ObjectType.Trim() %>'>
    <div class="delete" title="Удалить">Удалить</div>
    <span class="_param" rel="Text" rev="<%= tag.Text %>"><%: tag.Text %></span>
</li>
<%} %>