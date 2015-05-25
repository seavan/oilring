<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<OrganizationObject>"  MasterPageFile="~/Views/Shared/MainInner.master" %>	
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="materialsOne firmBlock">
	<div class="infoLine">
		<div class="date">
            Размещена <%= Model.CreationDate.ToStringNormalDate()%>
            <%if (Model.ModificationDate.HasValue){ %> 
            (Последние изменения <%= Model.ModificationDate.Value.ToStringNormalDate() + " " + Model.ModificationDate.Value.ToShortTimeString()%>)
            <%} %>
        </div>
		<span class="rubricDoor borderTop10"><span class="h"><span>Рубрики</span></span></span> <!-- при клике добавляем show -->
	</div>
	<!--рубрики-->
	<% (new RubricModule(Model) { Relation = "Rubrics", ViewName = "RelatedListWidget"}).ListWidget(Html); %>
	<!--/рубрики-->
	<!---->
	<div class="contentWrap">					
		<div class="block6">
			<h1><%= HttpUtility.HtmlDecode(Model.Title) %></h1>
			<!---->
			<div class="typical">     
                <div class="orgInfoBlock">
                <%if (!string.IsNullOrEmpty(Model.NormalAvatar)) {%>
				<img src="<%= RES.IMAGE_CONTENT_URI %><%=Model.NormalAvatar%>" alt="" class="fotoLeft" />
                <%} %>

				<%= HttpUtility.HtmlDecode(Model.Description) %>		
                </div>	
				<%--<!---->
				<div class="structureDoorWrap">
					<span class="structureDoor show borderTop10"><span class="h"><span>Структура</span></span></span> <!-- при клике добавляем show -->
				</div>
				<!--рубрики-->
				<div class="structureBlock borderAll10" style="display: block;"> <!--по клику раскрываем-->
					<img src="<%= RES.IMAGE_CONTENT_URI %>structure.gif" alt="" />
				</div>
				<!--/рубрики-->
				<!--/-->--%>


				<h2>Контактная информация</h2>
				<dl>
                    <%if(!string.IsNullOrEmpty(Model.Address)){ %>
					<dt>Адрес:</dt>
					<dd>
						<%:Model.Address%><br />
						<a href="http://maps.yandex.ru/?text=<%:Model.Address%>" target="_blank">Посмотреть Яндекс картах</a>
					</dd>
                    <%} %>
                    <%if(!string.IsNullOrEmpty(Model.Phone)){ %>
					<dt>Телефон:</dt>
					<dd><%:Model.Phone%></dd>
                    <%} %>
                    <%if(!string.IsNullOrEmpty(Model.Email)){ %>
					<dt>E-mail:</dt>
					<dd><a href="mailto:<%:Model.Email %>"><%:Model.Email %></a></dd>
                    <%} %>
                    <%if(!string.IsNullOrEmpty(Model.Website)){ %>
					<dt>Официальный сайт:</dt>
					<dd><a href="<%:Model.Website %>" target="_blank"><%:Model.Website %></a></dd>
                    <%} %>
				</dl>
			</div>
			<!--/-->
			<!---->
			<% Html.RenderPartial("SocialShare"); %>
			<!--/-->
		</div>
		<div class="block7">
			<% Html.RenderPartial("EditBlock"); %>
			<!---->
			<div class="infoBlocks2">
				<dl>
					<dt>Работают или работали здесь:</dt>
					<dd><a href="#"><%: ((long)Model.AUTO_WorkerCount).ToCounterWordForm("пользователь", "пользователя", "пользователей", false)%></a></dd>
					<dt>Учатся или учились здесь:</dt>
					<dd><a href="#"><%: ((long)Model.AUTO_ScholarCount).ToCounterWordForm("пользователь", "пользователя", "пользователей", false)%></a></dd>
				</dl>
			</div>
			<!--/-->

			<!---->
			<% (new UserModule(Model) { ViewName = "RelatedListWidgetContactUser", Relation = "ContactUser", PageSize = int.MaxValue, Page = 1 }).ListWidget(Html); %>
			<!--/-->

		</div>
	</div>
	<!--/-->
</div>
</asp:Content>
