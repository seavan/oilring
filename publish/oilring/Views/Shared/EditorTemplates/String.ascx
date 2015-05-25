<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<%
    var met = ViewData.ModelMetadata;
    var id = met.PropertyName;
%>
<span class="_validation _validationError" rel="<%:id %>"></span>
<div class="borderAll10 input"><div><input type="text" id="<%:id %>" name="<%:id %>" value="<%:Model %>" /></div></div>