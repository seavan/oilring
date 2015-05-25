<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>

<div style="float: right">

    <% if (String.IsNullOrEmpty(Model))
       {%>
    изображение отсутствует
    <%
   }
       else
       {
    %>
    <img src="/Content/temp/<%= Model %>" alt style="border: 1px solid black"/>
    <%
   }%>
</div>
<div>
    <span>Загрузить изображение: </span>
    <%= Html.Telerik().Upload()
    .Name(fname)
    .Multiple(false)


     %>
</div>
