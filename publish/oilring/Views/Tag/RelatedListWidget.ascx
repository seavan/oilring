<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TagObject>>" %>
<dl class="infoBlocks">
    <dt>Теги:</dt>
         <dd>
<%
    int i = 0;
    var cnt = Model.ToList().Count;
    foreach (var item in Model)
{
        %><a href="<%= Html.SingleUri(item) %>"><%= item.Text %></a><%
        if( i++ < cnt - 1)
        {
            Html.ViewContext.Writer.WriteLine(", ");
        }
       %>
  <%
} %>
    </dd>
</dl>