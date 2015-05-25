<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OuterLinkObject>>" %>
<%if(Model.Count() > 0){ %>
<dl class="infoBlocks links">
    <dt>—сылки:</dt>
    <dd>
        <ul class="list">
            <%
                foreach (var item in Model)
                {
            %>
            <li><a href="<%= item.Link %>" target="_blank"><%= !string.IsNullOrEmpty(item.Text) ? item.Text : item.Link%></a></li>
            <%
                } %>
        </ul>
    </dd>
</dl>
<%} %>