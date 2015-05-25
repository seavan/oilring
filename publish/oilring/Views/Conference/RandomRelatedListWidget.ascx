<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ConferenceObject>>" %>
<dl class="infoBlocks links">
    <dt>Похожие конференции:</dt>
    <dd>
        <ul class="list">
        <% foreach (var item in Model)
           {%>
            <li><a href="<%=Html.SingleUri(item)%>" class="name"><%=item.Title%></a></li>
            <%
           }%>
        </ul>
    </dd>
</dl>
