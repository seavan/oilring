<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ReportObject>>" %>
<div class="_addReports">
<div class="addReport">

	<div class="column">

		<div class="field">
			<label for="fnameReport" class="name">Название доклада:</label>
			<div class="borderAll10 input"><input type="text" value="" id="fnameReport" /></div>
		</div>		

		<!---->
		<div class="selectPeople">
            <label for="fnameAuthor">Введите имя докладчика:</label>
            <div class="searchWrap">
                <div class="borderAll10 input">
                    <div class="bg">
                        <input type="text" value="" id="fnameAuthor" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User/AutoCompleteSearch" />
                    </div>
                </div>
            </div>
            <div class="add" title="Добавить"  rel="/<%:Html.LC().LANG_CODE %>/User/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/User/SearchHtmlItemList">Добавить</div>
        </div>	
		<!--/-->
        										
	</div>

	<div class="column">
		<!---->
		<div class="selectDate">
			<dfn>Начало</dfn>
			<div class="timeInput">
				<span>Время</span>
				<div class="borderAll10 input" style="position:relative;">
                    <label for="_startReportHour" class="_autohide">ЧЧ</label>
                    <label for="_startReportMin" class="_autohide" style="left: 37px;">ММ</label>
                    <input type="text" value="" id="_startReportHour"/>.<input type="text" value="" id="_startReportMin"/>
                </div>
			</div>
			<span class="dateDoor _datepicker"><span>Выбрать дату</span></span>
            <div class='_datepickerHide'>
                <div class="borderAll10 input"><input type="text" id="hiddenStartReportDate" value="" maxlength="10" class="_datepickerInput"/></div>
            </div>
		</div>
		<div class="selectDate">
			<dfn>Окончание</dfn>
			<div class="timeInput">
				<span>Время</span>
				<div class="borderAll10 input" style="position:relative;">
                    <label for="_endReportHour" class="_autohide">ЧЧ</label>
                    <label for="_endReportMin" class="_autohide" style="left: 37px;">ММ</label>
                    <input type="text" value="" id="_endReportHour"/>.<input type="text" value="" id="_endReportMin"/>
                </div>
			</div>
			<span class="dateDoor _datepicker"><span>Выбрать дату</span></span>
            <div class='_datepickerHide'>
                <div class="borderAll10 input"><input type="text" id="hiddenEndReportDate" value="" maxlength="10" class="_datepickerInput"/></div>
            </div>
		</div>	
		<!--/-->											
	</div>

</div>
<!---->
<div class="userAddPeople">
	<dfn>Добавленные авторы:</dfn>
	<ul class="list _editList"></ul>
	<ul class="list _editList"></ul>
	<ul class="list _editList"></ul>
</div>	
<!--/-->
<input type="button" value="Добавить" class="ibutton _addNewReport _ownAct" />
<!---->
<div class="userAddReport">
	<dfn>Добавленные доклады:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>
</div>
</div>