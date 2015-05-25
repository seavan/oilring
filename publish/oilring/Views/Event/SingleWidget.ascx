<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EventObject>" %>
<div class="newsOneBlock">
    <div class="date">
        <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%></div>
    <a href="<%= Html.Chapter<admin.db.EventObject>() %>" class="allList">Все новости</a>
    <h1>
        <%= Model.Title %></h1>
    <!--контент-->
    <div class="typical">
        <%= HttpUtility.HtmlDecode(Model.Text) %>
        <%if (!string.IsNullOrEmpty(Model.SourceLink) && !string.IsNullOrEmpty(Model.SourceTitle))
          {%>
        <p>
            Источник: <a href="<%= Model.SourceLink%>">
                <%= Model.SourceTitle%></a></p>
        <%}%>
    </div>
    <!--/контент-->
    <!---->
    <% Html.RenderPartial("SocialShare"); %>
    <!--/-->
    <!--комменты-->
    <div class="commentsBlock">
        <h4>
            Комментарии</h4>
        <% (new CommentModule() { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html).AddWidget(Html); %>
    </div>
    <!--/комменты-->
</div>
