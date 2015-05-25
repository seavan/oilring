<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<admin.web.common.SearchTypeSelection>" %>

<!--фильтр-->
<ul class="filtr">
<% foreach (var i in Model)
   {
       if (i.Count > 0)
       {%>
    <li class="<%= i.Selected ? "cur" : "" %> <%= i.Count > 0 ? "_selectable" : "_nonSelectable" %> borderAll10 _moduleAction _searchType _ajaxLink" rel="searchType" rev="<%= Model.ModuleId %>" data-type="<%= i.ObjectType %>"><%=i.DisplayName%> (<%=i.Count%>) </li>
<% }
       else
       {
           %><li class="_noSelect"><%=i.DisplayName%> (<%=i.Count%>) </li><%
       }

   } %>

</ul>
<!--/фильтр-->

