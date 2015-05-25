<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<%
    var met = ViewData.ModelMetadata;
    var id = met.PropertyName;
    DateTime? date = null;
    try
    {
        date = ((DateTime?) Model);
    }
    catch
    {
    }

    string addClass = null;
    string relParam = null;
    if (ViewData["additionalClassView"] != null) addClass = ViewData["additionalClassView"].ToString();
    if (ViewData["relParamView"] != null) relParam = ViewData["relParamView"].ToString(); 
%>
<span class="_validation _validationError" rel="<%:id %>"></span>
<div class="borderAll10 input"><input type="text" id="<%= id %>" name="<%= id %>" value="<%: date.HasValue ? date.Value.ToShortDateString() : "" %>" maxlength="10" class="_datepickerInput <%: addClass %>" rel="<%: relParam%>"/></div>