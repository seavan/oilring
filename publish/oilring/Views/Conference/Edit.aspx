<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.ConferenceObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using (var form = new CustomEntityForm(Html, Model) { Title = "Добавление конференции", BlockClass = "addMaterialsBlock", ListClass = "iForm", Action = "SaveAjax" }.Open())
   {
       using (var group = new CustomGroup(Html, form) { Title = "Добавление рубрики", DDClass = "addRubric show" }.Open())
       {
           new RubricModule(Model) { Relation = "Rubrics" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Дата и время проведения" }.Open())
       {
           %>
           <div class="selectDate">
				<dfn>Начало</dfn>
				<div class="timeInput">
					<span>Время</span>
					<div class="borderAll10 input" style="position:relative;">
                        <label for="<%: Html.IdFor(m => m.StartHour)%>" class="_autohide">ЧЧ</label>
                        <label for="<%: Html.IdFor(m => m.StartMinute)%>" class="_autohide" style="left: 37px;">ММ</label>
                        <%: Html.TextBoxFor(m => m.StartHour, new { maxlength = "2", @class = "_localField _localHour" })%>.<%: Html.TextBoxFor(m => m.StartMinute, new { maxlength = "2", @class = "_localField _localMinute" })%>                        
                    </div>
				</div>				
                <% Html.RenderDateEditor(s => s.EventStartDate, "_dateField _localField", "selectDate");%>
			</div>
			<div class="selectDate">
				<dfn>Окончание</dfn>
				<div class="timeInput">
					<span>Время</span>
					<div class="borderAll10 input" style="position:relative;">                        
                        <label for="<%: Html.IdFor(m => m.EndHour)%>" class="_autohide">ЧЧ</label>
                        <label for="<%: Html.IdFor(m => m.EndMinute)%>" class="_autohide" style="left: 37px;">ММ</label>
                        <%: Html.TextBoxFor(m => m.EndHour, new { maxlength = "2", @class = "_localField _localHour" })%>.<%: Html.TextBoxFor(m => m.EndMinute, new { maxlength = "2", @class = "_localField _localMinute" })%>
                    </div>
				</div>				
                <% Html.RenderDateEditor(s => s.EventEndDate, "_dateField _localField", "selectDate");%>
			</div>
           <%
       }
       using (var group = new CustomGroup(Html, form) { Title = "Адрес" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Place, true, "Максимум 250 символов");
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Принадлежность к циклу" }.Open())
       {
           new ConferenceModule() { ViewName = "SingleCycleWidgetForEdit", Id = Model.REL_Id }.SingleWidget(Html, "SingleCycleWidgetForEdit");
       }
       using (var group = new CustomGroup(Html, form) { Title = "Прикрепленные файлы" }.Open())
       {
           new FileAttachmentModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Доклады" }.Open())
       {
           new ReportModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление организации" }.Open())
       {
           new OrganizationModule(Model) { Relation = "Organizers" }.RelatedEditWidget(Html);
       }
       //using (var group = new CustomGroup(Html, form) { Title = "Выбор языка" }.Open())
       //{
       //}

       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
           new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html);
       }

       using (var group = new CustomGroup(Html, form) { Title = "Ссылки на материал на сторонних ресурсах" }.Open())
       {
           new OuterLinkModule(Model) { Relation = "OuterLinks" }.RelatedEditWidget(Html); 
       }
       using (var group = new CustomGroup(Html, form) { Title = "Конференция" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Title, true, "Максимум 250 символов");
               Html.RenderEditor(s => s.ShortDescription);
           }
       }
       using (var control = new CustomSubmitRow(Html).Open().ObjectEditToolbar())
       {

       }
                
   }

%>
</asp:Content>
