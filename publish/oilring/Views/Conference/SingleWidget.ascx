<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ConferenceObject>" %>
<div class="materialsOne">
    <div class="infoLine">
        <div class="date">
            ���������
            <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%>
            <%if (Model.ModificationDate.HasValue)
              { %>
            (��������� ���������
            <%= Model.ModificationDate.Value.ToStringNormalDate() + " " + Model.ModificationDate.Value.ToShortTimeString()%>)
            <%} %>
        </div>
        <span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span>
        <!-- ��� ����� ��������� show -->
    </div>
    <!--�������-->
    <% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget" }).ListWidget(Html); %>
    <!--/�������-->
    <!---->
    <div class="contentWrap">
        <div class="block6">
            <% Html.RenderPartial("FavouriteBlock"); %>
            <h1>
                <%= Model.Title %></h1>
            <!---->
            <div class="typical">
                <%= HttpUtility.HtmlDecode(Model.Text) %></div>
            <!--/-->
            <!---->
            <% Html.RenderPartial("DownloadBlockHorizontal"); %>
            <!--/-->
            <!---->
            <% Html.RenderPartial("SocialShare"); %>
            <!--/-->
            <!---->
            <% Html.RenderPartial("ReportBlock", Model); %>
            <!--/-->
            <!---->
            <% Html.RenderPartial("VisitorsSingle", Model); %>
            <!--/-->
            <!---->
            <%--<% Html.RenderPartial("InvitationBlock"); %>--%>
            <!--/-->
            <!--��������-->
            <div class="commentsBlock">
                <h4>
                    �����������</h4>
                <% (new CommentModule() { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html).AddWidget(Html); %>
            </div>
            <!--/��������-->
        </div>
        <div class="block7">
            <% Html.RenderPartial("EditBlock"); %>
            <!---->
            <dl class="infoBlocks2 dateBlock">
                <dt>���� � ����� ����������:</dt>
                <dd>
                    <%= Model.EventStartDate.ToStringNormalDate() %>,
                    <%if (Model.EventStartDate.Day == Model.EventEndDate.Day && Model.EventEndDate.Month == Model.EventStartDate.Month)
                      {%>
                    <%= Model.EventStartDate.ToShortTimeString() %>�<%= Model.EventEndDate.ToShortTimeString() %>
                    <%}
                      else
                      {%>
                    <%= Model.EventEndDate.ToStringNormalDate()%>
                    <%}%>
                    <%if (Model.EventEndDate >= DateTime.Now)
                      {%>
                    <span>(����������� ��� �� ������)</span>
                    <%}%>
                </dd>
            </dl>
            <!--/-->
            <!---->
            <dl class="infoBlocks">
                <dt>����� ����������:</dt>
                <dd>
                    <a href="#">
                        <%= Model.Place %></a>
                </dd>
            </dl>
            <!--/-->
            <!---->
            <% Html.RenderPartial("OrganizationBlock", Model); %>
            <!--/-->
            <div class="infoBlocks but">
                <% Html.RenderPartial("JoinEventBlock", Model); %>
            </div>
            <!---->
            <dl class="infoBlocks borderNone">
                <dt>����������� �� �����:</dt>
                <dd>
                    <a href="#">����������� ��� �������</a>
                </dd>
            </dl>
            <!--/-->
            <!---->
            <% ViewData["class"] = "infoBlocks"; %>
            <% Html.RenderPartial("AuthorBlock", Model, ViewData); %>
            <!--/-->
            <!---->
            <% (new RandomConferenceModule(Model)).ListRandom(Html); %>
            <!--/-->
            <!---->
            <% (new TagModule(Model) { ViewName = "RelatedListWidget", Relation = "Tags" }).ListWidget(Html); %>
            <!--/-->
        </div>
    </div>
    <!--/-->

</div>