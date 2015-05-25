<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GrantObject>" %>	
<div class="materialsOne">
	<div class="infoLine">
		<div class="date">
            ��������� <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%>
            <%if (Model.ModificationDate.HasValue){ %> 
            (��������� ��������� <%= Model.ModificationDate.Value.ToStringNormalDate() + " " + Model.ModificationDate.Value.ToShortTimeString()%>)
            <%} %>
        </div>
		<span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span> <!-- ��� ����� ��������� show -->
	</div>

	<!--�������-->
	<% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
	<!--/�������-->

	<!---->
	<div class="contentWrap">					
		<div class="block6">
			<% Html.RenderPartial("FavouriteBlock", Model); %>
			<h1><%= Model.Title %></h1>
			<!---->
			<div class="typical"><%= HttpUtility.HtmlDecode(Model.Text) %></div>
			<!--/-->
			<!---->
			<% Html.RenderPartial("DownloadBlockHorizontal"); %>
			<!--/-->

			<!---->
			<% Html.RenderPartial("SocialShare"); %>
			<!--/-->
			<!--/-->
			<!---->
			 <% Html.RenderPartial("VisitorsSingle", Model); %>
			<!--/-->

			<!--��������-->
			<div class="commentsBlock">
				<h4>�����������</h4>
				<% (new CommentModule() { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType}).ListWidget(Html).AddWidget(Html); %>
			</div>
			<!--/��������-->

		</div>
		<div class="block7">
			<% Html.RenderPartial("EditBlock"); %>

			<!---->
			<div class="infoBlocks2">
				<dl>                    
					<dt>������� ���� ������ ������:</dt>
					<dd><%= Model.OrderDeadline.ToStringNormalDate() %></dd>                    
					<dt>����� ������:</dt>
					<dd><%= Model.Sum.ToStringNormalSum()%> <%= Model.SumCurrency.Replace(" ", "")%>.</dd>
				</dl>
                <% if (Model.OrderDeadline >= DateTime.Now)
                   { %>
                <% Html.RenderPartial("JoinEventBlock", Model); %>
                <% } %>
			</div>
			<!--/-->

			<!---->
			<% (new UserModule(Model) { ViewName = "RelatedListWidgetGrant", Relation = "ObjectAuthor", PageSize = int.MaxValue, Page = 1 }).ListWidget(Html); %>
			<!--/-->

			<!---->
			<%--<% Html.RenderPartial("OrganizationBlock", Model); %>--%>
            <% (new OrganizationModule(Model) { ViewName = "RelatedListWidgetTechno", Relation = "Organizers" }).ListWidget(Html); %>
			<!--/-->

			<!---->
			<% (new RandomGrantModule(Model)).ListRandom(Html); %>
			<!--/-->

			<!---->
			<% (new TagModule(Model) {ViewName = "RelatedListWidget", Relation = "Tags"}).ListWidget(Html); %>
			<!--/-->	

			<!---->
			<% (new OuterLinkModule(Model) {ViewName = "RelatedListWidget", Relation = "OuterLinks"}).ListWidget(Html); %>
			<!--/-->	
            						
		</div>
	</div>
	<!--/-->
</div>