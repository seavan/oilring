<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ArticleObject>" %>	
<div class="materialsOne">
    <div class="infoLine">
        <div class="date">
            ��������� <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%>
            <%if (Model.ModificationDate.HasValue){ %> 
            (��������� ��������� <%= Model.ModificationDate.Value.ToStringNormalDate() + " " + Model.ModificationDate.Value.ToShortTimeString()%>)
            <%} %>
        </div>
        <span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span>        <!-- ��� ����� ��������� show -->
    </div>
    <!--�������-->
    <% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
    <!--/�������-->
    <!---->
    <div class="contentWrap">
        <div class="block6">
            <% Html.RenderPartial("FavouriteBlock"); %>
            
            <h1><%= Model.Title %></h1>
            <!---->
            <div class="typical">
                <%= HttpUtility.HtmlDecode(Model.Text) %>
            </div>
            <!--/-->
            <!---->
            <% Html.RenderPartial("DownloadBlockHorizontal"); %>
            <!--/-->
            <!---->
            <% Html.RenderPartial("SocialShare"); %>
            <!--/-->
            <!--��������-->
            <div class="commentsBlock">
                <h4>�����������</h4>
                <% (new CommentModule() { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType}).ListWidget(Html).AddWidget(Html); %>
            </div>
            <!--/��������-->
        </div>
        <div class="block7">
            <!--/-->
            <% Html.RenderPartial("EditBlock"); %>
            <!--/-->
            <% (new UserModule(Model) {ViewName = "RelatedListWidgetArticle", Relation = "ObjectAuthor", PageSize = 5, Page = 1}).ListWidget(Html); %>
            <!--/-->
            <!---->
            <% (new RandomArticleModule(Model)).ListRandom(Html); %>
            <!--/-->
            <!---->
            <% (new TagModule(Model) {ViewName = "RelatedListWidget", Relation = "Tags"}).ListWidget(Html); %>

            <!--/-->
            <!---->
            <% (new PublicationLinkModule(Model) {ViewName = "RelatedListWidget", Relation = "PublicationLinks"}).ListWidget(Html); %>            <!--/-->
            <!---->
            <% (new OuterLinkModule(Model) {ViewName = "RelatedListWidget", Relation = "OuterLinks"}).ListWidget(Html); %>                    <!--/-->
            <!---->
            <% Html.RenderPartial("DownloadBlockVertical"); %>

            <!--/-->
        </div>
    </div>
    <!--/-->
</div>

		