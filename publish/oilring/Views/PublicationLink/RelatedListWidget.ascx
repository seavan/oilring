<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PublicationLinkObject>>" %>
<% if (Model.Count() > 0){%>
<dl class="infoBlocks links">
    <dt>Публикации в журналах:</dt>
    <dd>
        <ul class="list">
<%
    foreach (var item in Model)
{
       %>
            <li><%if(item.REF_Journal_Id.HasValue){ %>
       <a href="<%: Url.Action("Single", "Journal", new { Lang = Html.LC().LANG_CODE, id = item.REF_Journal_Id.Value })%>"><%= item.PublicationTitle%></a>        
        <%} else {%>
        <%= item.PublicationTitle%>
        <%} %><br/>
                ISBN: <%= item.ISBN %></li>
  <%
} %>
        </ul>
    </dd>
</dl>
<%}%>
