<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<User_UniverObject>" %>

<div class="activity _id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<span class="delete" title="�������">�������</span>

	<div class="field">
		<span class="name">����</span>
		<div class="years">
			<label for="from">�</label>
			<div class="dateInput field">				          
				<div class="borderAll10 input">
                    <label for="fStartDateUni<%:Model.Id %>" class="_autohide">��.����</label>
					<input type="text" value="<%: Model.StartYear.ToStringEditFromMonthDate() %>" id="fStartDateUni<%:Model.Id %>" maxlength="7" class="_forStartYear" />                    
				</div>
			</div>
			<label for="to">��</label>
			<div class="dateInput field">				
				<div class="borderAll10 input">
                    <label for="fEndDateUni<%:Model.Id %>" class="_autohide">��.����</label>                    
                    <input type="text" value="<%: Model.EndYear.HasValue ? Model.EndYear.Value.ToStringEditFromMonthDate() : ""%>" id="fEndDateUni<%:Model.Id %>" maxlength="7" class="_forEndYear"/>
				</div>
                <div style="white-space: nowrap; float: right; margin-left: 5px;"><input type="checkbox" class="_nowTime" id="m_now"/>&nbsp;<label for="m_now">��������� �����</label></div>
			</div>            			
            
		</div>
	</div>    

    <div class="field">
		<label for="fTitleUni<%:Model.Id %>" class="name">���</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Title %>" id="fTitleUni<%:Model.Id %>" class="_forTitle _autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Organization/AutoCompleteSearch""/></div></div>
	</div>
    <div class="field">
		<label for="fFacultyUni<%:Model.Id %>" class="name">���������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Faculty %>" id="fFacultyUni<%:Model.Id %>" class="_forFaculty"/></div></div>
	</div>
    <div class="field">
		<label for="fDepartmentUni<%:Model.Id %>" class="name">�������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Department %>" id="fDepartmentUni<%:Model.Id %>" class="_forDepartment"/></div></div>
	</div>
    <div class="field">
		<label for="fGroupUni<%:Model.Id %>" class="name">������</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Group %>" id="fGroupUni<%:Model.Id %>" class="_forGroup"/></div></div>
	</div>

    <span class="_param _frominput" rel="Title" rev="<%= Model.Title %>"></span>
    <span class="_param _frominput" rel="Faculty" rev="<%= Model.Faculty %>"></span>
    <span class="_param _frominput" rel="Department" rev="<%= Model.Department %>"></span>
    <span class="_param _frominput" rel="Group" rev="<%= Model.Group %>"></span>
    <span class="_param _frominput" rel="StartYear" rev="<%= Model.StartYear %>"></span>
    <span class="_param _frominput" rel="EndYear" rev="<%= Model.EndYear %>"></span>
    
</div>