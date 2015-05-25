<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<RubricObject>>" %>
<div class="borderAll10">
<ul>
    <% 
        var currentLevel = 0;
        foreach (var item in Model)
        {
            while (item.Level > currentLevel)
            {
                currentLevel++;
%>
               <ul>
               <%
            }
            while (item.Level < currentLevel)
            {
                currentLevel--;
%>
               </ul>
               <%
            }
%>
    <li>
        <% if( currentLevel > 0 ) { %>//&nbsp;&nbsp;<%}%><a href="<%= Html.SingleUri(item) %>"><%= item.Header %></a>
    </li>
  <%
        }
        
        while (currentLevel-- > 0)
           {
               %> </ul> <%
           }
%>
    </ul>
</div>
