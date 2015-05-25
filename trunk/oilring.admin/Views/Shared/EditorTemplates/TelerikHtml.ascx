<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<% var f = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty); %>
<div>
<textarea id="<%= f %>" name="<%= f %>" rows="15" cols="70" class="_visual">
<%= Model %>
</textarea>
</div>
<script language="javascript" type="text/javascript">

</script>