<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JournalObject>" %>	
<div class="journalsOne materialList">

	<%if(Request.IsAuthenticated) {%>
    <div class='icFavorite <%= Model.PSEUDO_IsUserFavourite ? "add" : "" %>'>избранное</div>
    <%} %>

	<%= OilringExtension.DefaultImage(Model, ConstSizes.LARGE, "class='f'")%>

	<div class="descr">

		<h1><%= Model.Title %></h1>

		<div class="info">
			<span>язык:</span> Русский<br />
			<span>ISBN:</span> <%= Model.ISBN %>
		</div>

		<div class="txt"><%= HttpUtility.HtmlDecode(Model.ShortDescription)%></div>

		<div class="info">
			<span>Дата публикации:</span> <%= Model.PublicationDate.HasValue ? Model.PublicationDate.Value.ToStringNormalDate() : Model.CreationDate.ToStringNormalDate()%><br />
			<span>Материалов сайта, опубликованных в данном номере:</span> <%= Model.AUTO_MaterialsCount %>
		</div>
		
        <!-- Представители -->
        <% (new UserModule(Model) { Relation = "ObjectUserDelegate", ViewName = "RelatedListWidgetJournalDelegate" }).ListWidget(Html); %>
        <!-- /Представители -->

	</div>

	<div class="info2">
		Этот журнал читают: <span class="_universalPeopleDoor peopleDoor borderTop10"><span><%: Model.AUTO_ReadersCount %></span></span> <!-- при клике добавляем show -->
		<span class="read">Я читаю</span>
		<span class="rubricDoor borderTop10"><span class="h"><span>Рубрики</span></span></span> <!-- при клике добавляем show -->									
	</div>

	<!--рубрики-->
	<% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
	<!--/рубрики-->

	<!--люди-->	
    <% Html.RenderPartial("Readers", Model); %>
	<!--/люди-->

</div>			
<!---->
<dl class="materialBlockIn">
	<dt>Материалы сайта в номерах журнала</dt>
	<dd>				
		<%--<!--фильтр выпадашка Месяц-->
		<div class="filtrSelectBlock months">
			<div class="border borderAll10"><!-- при клике добавляем show к ul -->
				<ul class="borderAll10"><!--ul class="borderAll10 show"-->
					<li>Месяц</li>
					<li><a href="#">Январь</a></li>
					<li><a href="#">Февраль</a></li>
					<li><a href="#">Март</a></li>
					<li><a href="#">Апрель</a></li>
					<li><a href="#">Май</a></li>
					<li><a href="#">Июнь</a></li>
					<li><a href="#">Июль</a></li>
					<li><a href="#">Август</a></li>
					<li><a href="#">Сентябрь</a></li>
					<li><a href="#">Ноябрь</a></li>
					<li><a href="#">Декабрь</a></li>
				</!--ul>
			</div>
		</div>
		<!--/фильтр выпадашка Месяц-->

		<!--фильтр выпадашка года-->
		<div class="borderBot10 filtrSelectBlock years">
			<div class="border borderAll10"><!-- при клике добавляем show к ul -->
				<ul class="borderAll10">
					<li>Год</li>
					<li><a href="#">2011</a></li>
					<li><a href="#">2010</a></li>
					<li><a href="#">2009</a></li>
					<li><a href="#">2008</a></li>
				</ul>
			</div>
		</div>
		<!--/фильтр выпадашка года-->
        <div class="resetFiltr">сбросить</div>--%>

        <% var obj = new ArticleModule(Model) { PageSize = 2, Relation = "JournalArticle" }.LinkRouteData();%>
		<ul class="materialList">
            <% obj.List(Html); %>
		</ul>
		<!--нумерация-->
        <% obj.Pager(Html); %>
		<!--/нумерация-->
	</dd>
</dl>
		