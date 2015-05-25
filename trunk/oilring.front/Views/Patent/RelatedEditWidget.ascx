<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PatentObject>>" %>
<div class="addPatentBlock">

	<%--<!--фильтр выпадашка-->
	<div class="filtrSelectBlock rubric2">
		<div class="border borderAll10"><!-- при клике добавляем show к ul -->
			<ul class="borderAll10">
				<li>Тип защиты интеллектуальной собственности</li>
				<li><a href="#">111</a></li>
				<li><a href="#">222</a></li>
			</ul>
		</div>
	</div>
	<!--/фильтр выпадашка-->--%>

	<div class="selectFirm">
		<label for="fnumberPatent" class="name">Введите номер патента:</label>
		<div class="borderAll10 input"><input type="text" value="" id="fnumberPatent" /></div>
	</div>	

	<%--<!--фильтр выпадашка-->
	<div class="filtrSelectBlock language">
		<div class="border borderAll10"><!-- при клике добавляем show к ul -->
			<ul class="borderAll10">
				<li>Страна патента</li>
				<li><a href="#">111</a></li>
				<li><a href="#">222</a></li>
			</ul>
		</div>
	</div>
	<!--/фильтр выпадашка-->	--%>
                                    								
	<!---->
	<div class="selectFirm">
		<label for="fnamePatent">Введите название патента:</label>
		<div class="searchWrap">											
			<div class="borderAll10 input">
				<input type="text" value="" id="fnamePatent" />				
			</div>											
		</div>
	</div>	
	<!--/-->
	<input type="button" class="ibutton _addNewPatent _ownAct" value="Добавить" />
</div>

<div class="userAddFirm">
	<dfn>Добавленные патенты:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>	
</div>	
