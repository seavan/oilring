<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PublicationLinkObject>>" %>
<div class="note">Пояснение про список публикаций в печатном издании – содержит следующие элементы. Перечень добавленных публикаций, каждый элемент которого содержит.</div>
<div class="wrap">

	<!---->
	<div class="userAddEdition">
        <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>		
	</div>
	<!--/-->

	<!---->
	<div class="addEditionBlock">
		<div class="column">
            <input type="hidden" id="fserverLangCode" value="<%: Html.LC().LANG_CODE %>"/>
			<%--<!--фильтр выпадашка-->
			<div class="filtrSelectBlock language">
				<div class="border borderAll10"><!-- при клике добавляем show к ul -->
					<ul class="borderAll10">
						<li>Язык публикации</li>
						<li><a href="#">Русский</a></li>
						<li><a href="#">Английский</a></li>
					</ul>
				</div>
			</div>
			<!--/фильтр выпадашка-->--%>            
            			
            <div class="field">				
				<div class="borderAll10 input">
                    <label for="ftypePublic" class="_autohide">Тип издания</label>
                    <input type="text" value="" id="ftypePublic" class="inp" />                    
                </div>
			</div>

			<div class="field">				
				<div class="borderAll10 input">
                    <label for="fISBNPublic" class="_autohide">ISBN</label>
                    <input type="text" value="" id="fISBNPublic" />
                </div>
			</div>

            <div class="field">				
				<div class="borderAll10 input">
                    <label for="fISSNPublic" class="_autohide">ISSN</label>
                    <input type="text" value="" id="fISSNPublic" />
                </div>
			</div>

			<input type="button" value="Добавить" class="ibutton _addNewPublication _ownAct" />
		</div>

		<div class="column">
			<div class="field">												
				
				<div class="searchWrap">											
					<div class="borderAll10 input">
						<div class="bg">
                            <label for="fnameEditionPublic" class="_autohide">Название издания</label>
                            <input type="text" value="" id="fnameEditionPublic"  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Journal/AutoCompleteSearch"/>
                        </div>						
					</div>											
				</div>												
			</div>
			<div class="dateInput field">
				<span>Дата публикации</span>                
				<div class="borderAll10 input">
                    <label for="fDatePublic" class="_autohide">ММ.ГГГГ</label>
					<input type="text" value="" id="fDatePublic" maxlength="7" />					
				</div>
			</div>
		</div>

	</div>
	<!--/-->
</div>