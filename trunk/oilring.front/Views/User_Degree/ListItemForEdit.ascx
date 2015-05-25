<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<User_DegreeObject>" %>

<div class="activity _id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<span class="delete" title="Удалить">Удалить</span>

	<div class="field">
		<label for="fyearDegree<%:Model.Id %>" class="name">Год</label>
		<div class="years">
			<div class="borderAll10 input"><div><input type="text" value="<%:Model.IssueDate.Year %>" id="fyearDegree<%:Model.Id %>" maxlength="4" class="_forIssueDate"/></div></div>
		</div>
	</div>

    <div class="field">
		<label for="fTitleDegree<%:Model.Id %>" class="name">Степень</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Title %>" id="fTitleDegree<%:Model.Id %>" class="_forTitle"/></div></div>
	</div>

    <div class="field">
		<label for="fSpecialtyDegree<%:Model.Id %>" class="name">Специальность</label>
		<div class="borderAll10 input"><div><input type="text" value="<%= Model.Specialty %>" id="fSpecialtyDegree<%:Model.Id %>" class="_forSpecialty"/></div></div>
	</div>

    <div class="field">
		<label for="fWorkTitleDegree<%:Model.Id %>" class="name">Работа</label>
        <div class="searchWrap">
		<div class="borderAll10 input"><div class="bg">
            <input type="text" value="<%= Model.WorkTitle %>" id="fWorkTitleDegree<%:Model.Id %>" class="_forWorkTitle _autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Article/AutoCompleteSearch"/>
            <input type="hidden" value="<%= Model.Article_ID %>" id="fArticle_IDDegree<%:Model.Id %>" class="_forArticle_ID _autocompleteid"/>
        </div></div></div>
	</div>

    <span class="_param _frominput" rel="Title" rev="<%= Model.Title %>"></span>
    <span class="_param _frominput" rel="Specialty" rev="<%= Model.Specialty %>"></span>

    <span class="_param _frominput" rel="WorkTitle" rev="<%= Model.WorkTitle %>"></span>

    <span class="_param _frominput" rel="IssueDate" rev="<%= Model.IssueDate %>"></span>
    <span class="_param _frominput" rel="Article_ID" rev="<%= Model.Article_ID %>"></span>
</div>