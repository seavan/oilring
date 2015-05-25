<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SeminarObject>" %>

<div class="selectCycleSeminars" style='<%:(Model != null) ? "display:none;" : "" %>'>
	<label for="fnameCycleSeminars">Введите название цикла:</label>
	<div class="searchWrap">											
		<div class="borderAll10 input">
			<div class="bg">
                <input type="text" value="" id="fnameCycleSeminars" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Seminar/AutoCompleteSearchCycle"/>                            
            </div>						
		</div>											
	</div>
	<div class="add _cycle" title="Добавить" rel="/<%:Html.LC().LANG_CODE %>/Seminar/GetHtmlItemList" rev="/<%:Html.LC().LANG_CODE %>/Seminar/SearchHtmlItemList">Добавить</div>

    <%if(Model == null ) {%>
        <input type="hidden" id="<%:Html.IdFor(s=>s.REL_Id) %>" name="<%:Html.IdFor(s=>s.REL_Id) %>" value="0" rel="0" />
        <input type="hidden" id="<%:Html.IdFor(s=>s.REL_ObjectType) %>" name="<%:Html.IdFor(s=>s.REL_ObjectType) %>" value="seminar" rel="seminar" />
    <%} %>
</div>
<!--цикл может быть только 1, при добпавалении блок с формой убираем-->
<%--<div class="nameCycleSeminars">Длинное название цикла семинаров «Есть ли жизнь на марсе?»&nbsp;<span class="delete" title="Удалить">Удалить</span></div>--%>

<ul class="nameCycleSeminars _editList">    
    <% Html.RenderPartial("ItemForEdit", Model); %>        
</ul>