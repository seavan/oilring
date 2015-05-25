<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<%
    var met = ViewData.ModelMetadata;
    var id = met.PropertyName;
%>
<span class="_validation _validationError" rel="<%:id %>"></span>
<div class="borderAll10 textarea"><div><textarea rows="1" cols="1" id="<%:id %>" name="<%:id %>" ><%= Model %></textarea></div></div>