<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
            <div class="messageBlockIn">
						<div class="topic">
							<div class="selectAll"><input type="checkbox" value="" class="_selectAll"/></div>
							<!--фильтр выпадашка-->
							<div class="filtrSelectBlock actions">
								<div class="border borderAll10"><!-- при клике добавляем show к ul -->
									<ul class="borderAll10 _dropdown">
										<li class="choice _dropitem">Операции</li>
										<li class="_dropitem _deleteMessage" data-uri="<%= Html.SingleUserAction<UserObject>(Model, "DeleteMessages") %>">Удалить</li>
									</ul>
								</div>
							</div>
							<!--/фильтр выпадашка-->
							<div class="addMessageDoor _messagePopup">Написать письмо</div>
						</div>
                    <%
               var module = new PrivateMessageModule(Model) { PageSize = 8}; %>
               <%
               module.List(Html).Pager(Html); %>
            </div>
    </div>
            <div class="block2">
                <% Html.RenderPartial("BannerBlock"); %>
            </div>
        </div>
    </div>