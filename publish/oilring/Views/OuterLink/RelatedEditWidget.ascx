<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OuterLinkObject>>" %>
<ul class="userAddLinks">
    <%foreach (var item in Model){%>
    <li class="_id" rel='<%= item.Id %>' rev='<%= item.ObjectType.Trim() %>'><a href="<%= item.Link %>" target="_blank"><%= !string.IsNullOrEmpty(item.Text) ? item.Text : item.Link %></a><span class="delete" title="�������">�������</span></li>
    <%} %>
</ul>

<div class="addLinks">
	<div class="field">
		<label for="fnameOuterLink" class="name">����� ������:</label>
		<div class="borderAll10 input"><input type="text" value="" id="fnameOuterLink" /></div>
	</div>
	<div class="field">
		<label for="faddresOuterLink" class="name">����� ������:</label>
		<div class="borderAll10 input"><input type="text" value="" id="faddresOuterLink" /></div>
	</div>
	<input type="button" value="��������" class="ibutton _addOuterLink _ownAct" />
</div>
