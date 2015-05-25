<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JournalObject>" %>	
<div class="journalsOne materialList">

	<%if(Request.IsAuthenticated) {%>
    <div class='icFavorite <%= Model.PSEUDO_IsUserFavourite ? "add" : "" %>'>���������</div>
    <%} %>

	<%= OilringExtension.DefaultImage(Model, ConstSizes.LARGE, "class='f'")%>

	<div class="descr">

		<h1><%= Model.Title %></h1>

		<div class="info">
			<span>����:</span> �������<br />
			<span>ISBN:</span> <%= Model.ISBN %>
		</div>

		<div class="txt"><%= HttpUtility.HtmlDecode(Model.ShortDescription)%></div>

		<div class="info">
			<span>���� ����������:</span> <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%><br />
			<span>���������� �����, �������������� � ������ ������:</span> <%= Model.AUTO_MaterialsCount %>
		</div>
		
        <!-- ������������� -->
        <% (new UserModule(Model) { Relation = "ObjectUserDelegate", ViewName = "RelatedListWidgetJournalDelegate" }).ListWidget(Html); %>
        <!-- /������������� -->

	</div>

	<div class="info2">
		���� ������ ������: <span class="_universalPeopleDoor peopleDoor borderTop10"><span><%: Model.AUTO_ReadersCount %></span></span> <!-- ��� ����� ��������� show -->
		<span class="read">� �����</span>
		<span class="rubricDoor borderTop10"><span class="h"><span>�������</span></span></span> <!-- ��� ����� ��������� show -->									
	</div>

	<!--�������-->
	<% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
	<!--/�������-->

	<!--����-->	
    <% Html.RenderPartial("Readers", Model); %>
	<!--/����-->

</div>			
<!---->
<dl class="materialBlockIn">
	<dt>��������� ����� � ������� �������</dt>
	<dd>				
		<%--<!--������ ��������� �����-->
		<div class="filtrSelectBlock months">
			<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
				<ul class="borderAll10"><!--ul class="borderAll10 show"-->
					<li>�����</li>
					<li><a href="#">������</a></li>
					<li><a href="#">�������</a></li>
					<li><a href="#">����</a></li>
					<li><a href="#">������</a></li>
					<li><a href="#">���</a></li>
					<li><a href="#">����</a></li>
					<li><a href="#">����</a></li>
					<li><a href="#">������</a></li>
					<li><a href="#">��������</a></li>
					<li><a href="#">������</a></li>
					<li><a href="#">�������</a></li>
				</!--ul>
			</div>
		</div>
		<!--/������ ��������� �����-->

		<!--������ ��������� ����-->
		<div class="borderBot10 filtrSelectBlock years">
			<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
				<ul class="borderAll10">
					<li>���</li>
					<li><a href="#">2011</a></li>
					<li><a href="#">2010</a></li>
					<li><a href="#">2009</a></li>
					<li><a href="#">2008</a></li>
				</ul>
			</div>
		</div>
		<!--/������ ��������� ����-->
        <div class="resetFiltr">��������</div>--%>

        <% var obj = new ArticleModule(Model) { PageSize = 2, Relation = "JournalArticle" }.LinkRouteData();%>
		<ul class="materialList">
            <% obj.List(Html); %>
		</ul>
		<!--���������-->
        <% obj.Pager(Html); %>
		<!--/���������-->
	</dd>
</dl>
		