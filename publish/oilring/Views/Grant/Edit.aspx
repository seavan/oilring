<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.GrantObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using (var form = new CustomEntityForm(Html, Model) { Title = "Добавление гранта", BlockClass = "addMaterialsBlock", ListClass = "iForm", Action = "SaveAjax" }.Open())
   {
       using (var group = new CustomGroup(Html, form) { Title = "Название гранта", DDClass = "show" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Title, true, "Максимум 250 символов");
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Номер гранта" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Number);
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление организации" }.Open())
       {
           new OrganizationModule(Model) { Relation = "Organizers" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление рубрики", DDClass = "addRubric" }.Open())
       {
           new RubricModule(Model) { Relation = "Rubrics" }.RelatedEditWidget(Html);
       }
       //using (var group = new CustomGroup(Html, form) { Title = "Выбор языка" }.Open())
       //{
       //}
       using (var group = new CustomGroup(Html, form) { Title = "Прикрепленные файлы" }.Open())
       {
           new FileAttachmentModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление авторов", DDClass = "addAutor" }.Open())
       {
           new UserModule(Model) { Relation = "ObjectAuthor", ViewName = "RelatedEditWidgetAuthor" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Сумма гранта" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Sum);
           }
       }

       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
           new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html);
       }
       
       using (var group = new CustomGroup(Html, form) { Title = "Ссылки на материал на сторонних ресурсах" }.Open())
       {
           new OuterLinkModule(Model) { Relation = "OuterLinks" }.RelatedEditWidget(Html); 
       }
       using (var group = new CustomGroup(Html, form) { Title = "Крайний срок подачи заявок" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addPeriod" }.Open())
           {
               Html.RenderDateEditor(s => s.OrderDeadline);
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Крайний срок выполнения" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addPeriod" }.Open())
           {
               Html.RenderDateEditor(s => s.CompleteDeadline);
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Описание" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.ShortDescription);
           }
       }
       using (var control = new CustomSubmitRow(Html).Open().ObjectEditToolbar())
       {

       }    
                
   }

%>
</asp:Content>
