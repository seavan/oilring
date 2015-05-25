<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int>" %>
<%
    var met = ViewData.ModelMetadata;
    var id = met.PropertyName;
    var combo = met.AdditionalValues["Combo"] as Web.Common.Metadata.ComboValuesAttribute;
        
%>
<div class="filtrSelectBlock privacy">
    <div class="border borderAll10">
        <!-- при клике добавляем show к ul -->
        <ul class="borderAll10 _dropdown" rel="<%= id %>">
            <% if (combo != null)
               {
                   
                   foreach (var item in combo.Values)
                   {  %>
                   <li class="<%= Model == item.Key ? "choice" : "" %> _dropitem" rel="<%= item.Key %>"><%= item.Value %></li>
                   <%
                   }%>
            <% } %>
        </ul>
        <input type="hidden" id="<%= id %>" name="<%= id %>" value="<%= Model %>"/>
    </div>
</div>