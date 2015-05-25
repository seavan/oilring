<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PublicationLinkObject>>" %>
<%
    foreach (var item in Model){%>
    <div class="source">//&nbsp;Опубликовано в 
       <%if(item.REF_Journal_Id.HasValue){ %>
       <a href="<%: Url.Action("Single", "Journal", new { Lang = Html.LC().LANG_CODE, id = item.REF_Journal_Id.Value })%>"><%= item.PublicationTitle%></a>        
        <%} else {%>
        <%= item.PublicationTitle%>
        <%} %>
       </div>
  <%
} %>