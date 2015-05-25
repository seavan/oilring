<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.ArticleObject>>" %>
<% foreach (var item in Model){%>
<li>
    <div class="bgWrap">
        <% Html.RenderPartial("FavouriteBlock", item); %>
        <!-- authors -->
        <% (new UserModule(item) { ViewName = "RelatedListWidgetArticle", Relation = "ObjectAuthor", PageSize = 3, Page = 1 }).ListWidget(Html); %>
        <!-- /authors -->

        <div class="descr <%= OilringExtension.DefaultPhotoAvailable(item) ? "fotoIn" : "" %>">

            <a href="<%= Html.SingleUri(item) %>" class="name"><%= OilringExtension.DefaultImage(item, ConstSizes.MID) %><%= item.GetSafeTitle() %></a>

            <div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>
            <%= item.ShortDescription%>
            <% (new PublicationLinkModule(item) { ViewName = "RelatedListWidgetShort", Relation = "PublicationLinks" }).ListWidget(Html); %>
        </div>
        <div class="comment">
            <a href="<%= Html.SingleUri(item, "comments") %>" class="icComment"><%= item.AUTO_CommentCount %> <% if (item.PSEUDO_NewCommentCount > 0)
{%><b>(<%=item.PSEUDO_NewCommentCount%>)</b><%
}%> комментариев <%--<b>(2)</b>--%></a> 
            <% if (item.AUTO_Comment_LastDateTime != null && item.AUTO_CommentCount > 0){%>(последний <%= OilringExtension.ToStringVerboseDateTime(item.AUTO_Comment_LastDateTime.Value) %>) <%}%>
            <span class="rubricDoor borderTop10"><span class="h"><span>Рубрики</span></span></span><!-- при клике добавляем show -->
        </div>
        <!--рубрики-->
		 <% (new RubricModule(item) { Delayed = true, Ajax = true, Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
		<!--/рубрики-->
    </div>
</li>
<%}%>