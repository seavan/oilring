<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ReportObject>>" %>
<%foreach(var item in Model) {%>
<div class="block _id" rel="<%: item.Id %>" rev="<%: item.ObjectType.Trim() %>">
    <div class="nameReport"><%= HttpUtility.HtmlDecode(item.Title) %> <span>(<%: item.StartDate.ToStringNormalDate() %>, <%: item.StartDate.ToShortTimeString() %>-<%:item.EndDate.ToShortTimeString() %>)</span>&nbsp;<span class="delete" title="Удалить">Удалить</span></div>
    <div class="userAddPeople">
        <% (new UserModule(item) { ViewName = "RelatedListWidgetAuthor", Relation = "ObjectAuthorReader" }).ListWidget(Html); %>
    </div>

    <span class="_param" rel="Title" rev="<%: item.Title %>"></span>
    <span class="_param" rel="StartDate" rev="<%: item.StartDate %>"></span>
    <span class="_param" rel="EndDate" rev="<%: item.EndDate %>"></span>
</div>
<%} %>