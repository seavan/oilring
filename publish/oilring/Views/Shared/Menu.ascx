<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% var Data = Url.RequestContext.RouteData.Values; %>

<%
   var classInn = "";
    if (Data.ContainsValue("Article") || Data.ContainsValue("Seminar") || Data.ContainsValue("Conference") || Data.ContainsValue("Discussion") ||
          Data.ContainsValue("Grant") || Data.ContainsValue("Techno") || Data.ContainsValue("Journal")  )
    {
        classInn = "inside";
    }%>
<ul class="menuMain borderTop10 <%:classInn %>">
    

    <%if (!Data.ContainsValue("Article") && !Data.ContainsValue("Seminar") && !Data.ContainsValue("Conference") && !Data.ContainsValue("Discussion") &&
          !Data.ContainsValue("Grant") && !Data.ContainsValue("Techno") && !Data.ContainsValue("Journal") && !Data.ContainsValue("Edit")){%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_All%></li>
    <%  } else {%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>"><%= Html.LC().Entities_All %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Article") && Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Materials%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Article"><%= Html.LC().Entities_Materials %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Seminar")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Seminars%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Seminar"><%= Html.LC().Entities_Seminars %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Conference")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Conferences%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Conference"><%= Html.LC().Entities_Conferences %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Discussion")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Discussions%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Discussion"><%= Html.LC().Entities_Discussions %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Grant")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Grants%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Grant"><%= Html.LC().Entities_Grants %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Techno")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Technologies%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Techno"><%= Html.LC().Entities_Technologies %></a></li>
    <%} %>
    <%if(Data.ContainsValue("Journal")&& Data.ContainsValue("List")) {%>
    <li class="borderAll10 cur"><%= Html.LC().Entities_Journals%></li>
    <%} else{%>
    <li class="borderAll10"><a href="/<%= Html.LC().LANG_CODE %>/Journal"><%= Html.LC().Entities_Journals %></a></li>
    <%} %>
</ul>