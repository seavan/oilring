<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<RubricObject>>" %>

<div class="rubricBlock">
    <div class="line">
        <% 
        var currentLevel = 0;
        foreach (var item in Model)
        {
            while (item.Level > currentLevel)
            {
                currentLevel++;
                %><div class="<%: currentLevel == 1 ? "_choiseSubSection" : "_choiseCategory" %>" ><%
            }
            while (item.Level < currentLevel)
            {
                currentLevel--;
                %></div><%
            }

            if (currentLevel == 0)
            {
                %></div><div class="line"><div class="_choiseSection"><span  class="_id" rel='<%= item.Id %>' rev='<%= item.ObjectType.Trim() %>'><%= item.Header%></span></div><%
            }
            
            if (currentLevel > 0)
            {
                %><span  class="_id" rel='<%= item.Id %>' rev='<%= item.ObjectType.Trim() %>'>//&nbsp;&nbsp;&nbsp;<%= item.Header %>&nbsp;<span class="delete" title="Удалить категорию">Удалить</span></span><%
            }
        }
        while (currentLevel-- > 0)
        {
            %></div><%
        }
        %>
    </div>
</div>