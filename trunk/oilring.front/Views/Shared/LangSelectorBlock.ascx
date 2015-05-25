<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<ul class="lang">
<%
    var lc = I18N.D.GetLocales();
    foreach (var l in lc)
    {
        if (l != Html.LC())
        {
            %><li><a href='/<%= l.LANG_CODE %>'><%= l.ShortTitle%></a></li><%
        }
        else
        {
            %><li><%= l.ShortTitle%></li><%
        }
    }
%>
</ul>
