<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<admin.db.ConferenceObject>>" %>
<% foreach (var item in Model){%>
<li>
    <div class="bgWrap">

        <% Html.RenderPartial("FavouriteBlock", item); %>

        <% Html.RenderPartial("AuthorBlock", item); %>

        <div class="descr <%= OilringExtension.DefaultPhotoAvailable(item) ? "fotoIn" : "" %>">
            <a href="<%= Html.SingleUri(item) %>" class="name">
                <%= OilringExtension.DefaultImage(item, ConstSizes.MID) %>
                <%= item.GetSafeTitle() %>
            </a>

            <div class="date"><%= item.PublicationDate.HasValue ? item.PublicationDate.Value.ToStringNormalDate() : item.CreationDate.ToStringNormalDate()%></div>

            <%= item.ShortDescription%>

            <div class="source" style="display: none">// ����������� �� ����� <a href="#">�������� ����� ���</a></div>

            <dl class="info">
                <dt>���� ����������:</dt>
                <dd><b>
                <%= item.EventStartDate.ToStringNormalDate()%>, 
                <%if(item.EventStartDate.Day == item.EventEndDate.Day && item.EventEndDate.Month == item.EventStartDate.Month) {%>
                <%= item.EventStartDate.ToShortTimeString()%>�<%= item.EventEndDate.ToShortTimeString()%>
                <%} else{%>&nbsp;&mdash;&nbsp;
                <%= item.EventEndDate.ToStringNormalDate()%>
                <%}%>
                </b></dd>
                <dt>����� ����������:</dt>
                <dd><a href="#"><%= item.Place %></a></dd>
                <dt>����������� ��������:</dt><% (new OrganizationModule(item) { Relation = "Organizers", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
            </dl>
        </div>

        <div class="comment">
            <a href="<%= Html.SingleUri(item, "comments") %>" class="icComment"><%= item.AUTO_CommentCount %> ������������ <%--<b>(2)</b>--%></a> 
            <% if (item.AUTO_Comment_LastDateTime != null && item.AUTO_CommentCount > 0){%>(��������� <%= OilringExtension.ToStringVerboseDateTime(item.AUTO_Comment_LastDateTime.Value) %>) <%}%>
            
            <span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span>
            <!-- ��� ����� ��������� show -->
            <span class="peopleDoor _universalPeopleDoor borderTop10"><span>�� ����������� ��������</span> (<%= item.AUTO_ObjectUserVisitorCount %>)</span>
            <!-- ��� ����� ��������� show -->

        </div>

        <!--�������-->
        <% (new RubricModule(item) { Relation = "Rubrics", ViewName = "RelatedListWidget", Ajax = true, Delayed = true }).ListWidget(Html); %>
        <!--/�������-->

        <!--�������� �� �����������-->        
        <% Html.RenderPartial("Visitors", item); %>        
        <!--/�������� �� �����������-->

    </div>
</li>
<%} %>