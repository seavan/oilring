<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<User_JobObject>" %>

<div class="activity _id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<span class="delete" title="�������">�������</span>

	<div class="field">
		<span class="name">����� ������</span>
		<div class="years">
			<label for="from">�</label>
			<div class="dateInput field">				          
				<div class="borderAll10 input">
                    <label for="fStartDateJob<%:Model.Id %>" class="_autohide">��.����</label>
					<input type="text" value="<%: Model.StartYear.ToStringEditFromMonthDate() %>" id="fStartDateJob<%:Model.Id %>" maxlength="7" class="_forStartYear" />                    
				</div>
			</div>
			<label for="to">��</label>
			<div class="dateInput field">				
				<div class="borderAll10 input">
                    <label for="fEndDateJob<%:Model.Id %>" class="_autohide">��.����</label>
                    <%if(Model.State) {%>
					<input type="text" value="<%: Model.EndYear.HasValue ? Model.EndYear.Value.ToStringEditFromMonthDate() : ""%>" id="fEndDateJob<%:Model.Id %>" maxlength="7" class="_forEndYear" disabled="disabled"/>	
                    <%} else {%>
                    <input type="text" value="<%: Model.EndYear.HasValue ? Model.EndYear.Value.ToStringEditFromMonthDate() : ""%>" id="fEndDateJob<%:Model.Id %>" maxlength="7" class="_forEndYear"/>
                    <%} %>				
				</div>
			</div>
            			
            <label for="fStateJob<%:Model.Id %>" class="check2">
                <%if(Model.State) {%>
                <input checked="checked" id="fStateJob<%:Model.Id %>" type="checkbox" value="true" class="_forState _StateEntity" rel="_forEndYear" rev="activity"/>              
                <%} else {%>
                <input id="fStateJob<%:Model.Id %>" type="checkbox"  value="false" class="_forState _StateEntity" rel="_forEndYear" rev="activity"/>
                <%} %>
                �� ��������� �����
            </label>
		</div>
	</div>    

    <div class="field">
		<label for="fTitleCompanyJob<%:Model.Id %>" class="name">��������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Title %>" id="fTitleCompanyJob<%:Model.Id %>" class="_forTitle"/></div></div>
	</div>
    <div class="field">
		<label for="fDifisionJob<%:Model.Id %>" class="name">�����������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Division1 %>" id="fDifisionJob<%:Model.Id %>" class="_forDivision1"/></div></div>
	</div>
    <div class="field">
		<label for="fPositionJob<%:Model.Id %>" class="name">���������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Position %>" id="fPositionJob<%:Model.Id %>" class="_forPosition"/></div></div>
	</div>

    <span class="_param _frominput" rel="Title" rev="<%= Model.Title %>"></span>
    <span class="_param _frominput" rel="Division1" rev="<%= Model.Division1 %>"></span>
    <span class="_param _frominput" rel="Position" rev="<%= Model.Position %>"></span>
    <span class="_param _frominput" rel="StartYear" rev="<%= Model.StartYear %>"></span>
    <span class="_param _frominput" rel="EndYear" rev="<%= Model.EndYear %>"></span>
    <span class="_param _fromcheck" rel="State" rev="<%= Model.State %>"></span>
</div>