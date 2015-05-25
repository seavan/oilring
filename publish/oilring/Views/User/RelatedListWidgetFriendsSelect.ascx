<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<ul class="check">
    <%
        var counter = 0;
        var cnt = Model.Count() / 2;
        foreach (var item in Model)
        {
            counter++;
            if (counter > cnt)
            {%>
            </ul>
            <ul class="check">
            <%
            }
%>
    <li>
        <label for="ch<%= counter %>">
            <input type="checkbox" value="" rel="<%= item.Id %>" id="ch<%= counter %>" /><%= item.DisplayName %>
        </label>
    </li>

    <% 
        } %>
</ul>