<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<%
    var met = ViewData.ModelMetadata;
    var id = met.PropertyName;
%>
<span class="_validation _validationError" rel="<%:id %>"></span>
<textarea class="ckeditor _ckeditor" id="<%= id %>" name="<%= id %>" rows="10" cols="70">
<%= Model %>
</textarea>