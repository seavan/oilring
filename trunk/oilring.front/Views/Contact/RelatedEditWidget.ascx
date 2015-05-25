<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ContactObject>>" %>

<div class="_contactUserList">
<%foreach(var item in Model) {%>
    <% Html.RenderPartial("ListItemForEdit", item); %>
<%} %>
</div>

<span class="more _newContactForm"><span>Добавить</span></span>

<div class="popup addContactBlock _staticFormLoad" style="top: 300px;"> <!-- по клику показываем -->
	<div class="bgBlock">
			<dfn>Добавление контактной информации</dfn>
			<div class="wrap iForm">
				<!--фильтр выпадашка-->
				<div class="filtrSelectBlock contact">
					<div class="border borderAll10"><!-- при клике добавляем show к ul -->
						<ul class="borderAll10">
							<li rel="mail" class="choice">E-Mail</li>
							<li rel="icq">Icq</li>
							<li rel="skype">Skype</li>
                            <li rel="phone">Телефон</li>
						</ul>
					</div>
				</div>
				<!--/фильтр выпадашка-->
				<div class="field">
					<div class="borderAll10 input"><div><input type="text" value="" id="fnewContact" /></div></div>
				</div>
			</div>
			<div class="but">
                <input type="button" value="Добавить" class="ibutton _addNewContact _ownAct" />&nbsp;&nbsp;&nbsp;
                <input type="button" value="Отмена" class="ibutton _cancelAddedContact _ownAct" />
            </div>
	</div>
</div>
