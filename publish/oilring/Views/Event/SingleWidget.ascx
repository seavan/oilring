<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EventObject>" %>
<div class="newsOneBlock">
    <div class="date">
        <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%></div>
    <a href="<%= Html.Chapter<admin.db.EventObject>() %>" class="allList">��� �������</a>
    <h1>
        <%= Model.Title %></h1>
    <!--�������-->
    <div class="typical">
        <%= HttpUtility.HtmlDecode(Model.Text) %>
        <%if (!string.IsNullOrEmpty(Model.SourceLink) && !string.IsNullOrEmpty(Model.SourceTitle))
          {%>
        <p>
            ��������: <a href="<%= Model.SourceLink%>">
                <%= Model.SourceTitle%></a></p>
        <%}%>
    </div>
    <!--/�������-->
    <!---->
    <% Html.RenderPartial("SocialShare"); %>
    <!--/-->
    <!--��������-->
    <div class="commentsBlock">
        <h4>
            �����������</h4>
        <% (new CommentModule() { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html).AddWidget(Html); %>
    </div>
    <!--/��������-->
</div>
