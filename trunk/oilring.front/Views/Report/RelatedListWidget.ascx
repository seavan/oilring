<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ReportObject>>" %>
<% if (Model.Count() > 0){%>                
<dd>
    <dl class="list">
        <%foreach (var item in Model){%>
        <dt><%= HttpUtility.HtmlDecode(item.Title) %></dt>
        <dd>
            <div class="date"><%: item.StartDate.ToShortTimeString() %>-<%:item.EndDate.ToShortTimeString() %>, <%: item.StartDate.ToStringNormalDate() %></div>
            <%= HttpUtility.HtmlDecode(item.Text) %>
            <div class="autor">
                Докладчики<%-- конференции--%>: <% (new UserModule(item) { ViewName = "RelatedListWidgetReport", Relation = "ObjectAuthorReader" }).ListWidget(Html); %>
            </div>
        </dd>        
        <%} %>
    </dl>
</dd>
<%}%>
