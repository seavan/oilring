<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>
<% if (Model.Count() > 0){%>
<div class="firm">
    <span>Организации:</span> 

    <%foreach (var item in Model){%>

    <a href="<%=Html.SingleUri(item)%>"><%=item.Title%></a><%: item.Id == Model.Last().Id ? "" : ", " %>

    <%}%>
  
</div>     
<%}%>
