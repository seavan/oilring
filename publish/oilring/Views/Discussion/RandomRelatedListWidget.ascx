<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DiscussionObject>>" %>
<dl class="infoBlocks links">
    <dt>Похожие дискуссии:</dt>
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
