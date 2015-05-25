<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ReportObject>>" %>
<div class="_addReports">
<div class="addReport">

	<div class="column">

		<div class="field">
			<label for="fnameReport" class="name">�������� �������:</label>
			<div class="borderAll10 input"><input type="text" value="" id="fnameReport" /></div>
		</div>		

		<!---->
		<div class="selectPeople">
            <label for="fnameAuthor">������� ��� ����������:</label>
            <div class="searchWrap">
                <div class="borderAll10 input">
                    <div class="bg">
                        <input type="text" value="" id="fnameAuthor" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User/AutoCompleteSearch" />
                    </div>
                </div>
            </div>
            <div class="add" title="��������"  rel="/<%:Html.LC().LANG_CODE %>/User/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/User/SearchHtmlItemList">��������</div>
        </div>	
		<!--/-->
        										
	</div>

	<div class="column">
		<!---->
		<div class="selectDate">
			<dfn>������</dfn>
			<div class="timeInput">
				<span>�����</span>
				<div class="borderAll10 input" style="position:relative;">
                    <label for="_startReportHour" class="_autohide">��</label>
                    <label for="_startReportMin" class="_autohide" style="left: 37px;">��</label>
                    <input type="text" value="" id="_startReportHour"/>.<input type="text" value="" id="_startReportMin"/>
                </div>
			</div>
			<span class="dateDoor _datepicker"><span>������� ����</span></span>
            <div class='_datepickerHide'>
                <div class="borderAll10 input"><input type="text" id="hiddenStartReportDate" value="" maxlength="10" class="_datepickerInput"/></div>
            </div>
		</div>
		<div class="selectDate">
			<dfn>���������</dfn>
			<div class="timeInput">
				<span>�����</span>
				<div class="borderAll10 input" style="position:relative;">
                    <label for="_endReportHour" class="_autohide">��</label>
                    <label for="_endReportMin" class="_autohide" style="left: 37px;">��</label>
                    <input type="text" value="" id="_endReportHour"/>.<input type="text" value="" id="_endReportMin"/>
                </div>
			</div>
			<span class="dateDoor _datepicker"><span>������� ����</span></span>
            <div class='_datepickerHide'>
                <div class="borderAll10 input"><input type="text" id="hiddenEndReportDate" value="" maxlength="10" class="_datepickerInput"/></div>
            </div>
		</div>	
		<!--/-->											
	</div>

</div>
<!---->
<div class="userAddPeople">
	<dfn>����������� ������:</dfn>
	<ul class="list _editList"></ul>
	<ul class="list _editList"></ul>
	<ul class="list _editList"></ul>
</div>	
<!--/-->
<input type="button" value="��������" class="ibutton _addNewReport _ownAct" />
<!---->
<div class="userAddReport">
	<dfn>����������� �������:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>
</div>
</div>