<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<bool?>" %>
<% var f = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty); %>
<% if(Model.HasValue  && Model.Value)
   {%>
<input type="checkbox" id="<%=f%>" name="<%=f%>" checked="checked" value="1" >
<%
   } else {%>
<input type="checkbox" id="<%=f%>" name="<%=f%>" value="0" >
   <%} %>

