<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.TechnoObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using (var form = new CustomEntityForm(Html, Model) { Title = "Добавление технологии", BlockClass = "addMaterialsBlock", ListClass = "iForm", Action = "SaveAjax" }.Open())
   {
       using (var group = new CustomGroup(Html, form) { Title = "Название технологии", DDClass = "show" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Title, true, "Максимум 250 символов");
           }
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
       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
           new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Ссылки на материал на сторонних ресурсах" }.Open())
       {
           new OuterLinkModule(Model) { Relation = "OuterLinks" }.RelatedEditWidget(Html); 
       }

       using (var group = new CustomGroup(Html, form) { Title = "Добавление авторов", DDClass = "addAutor" }.Open())
       {
           new UserModule(Model) { Relation = "ObjectAuthor", ViewName = "RelatedEditWidgetAuthor" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление организаций" }.Open())
       {
           new OrganizationModule(Model) { Relation = "OrganizationMembers" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление патентов" }.Open())
       {
           new PatentModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление грантов" }.Open())
       {
           new GrantModule(Model) { Relation = "TechnoGrant" }.RelatedEditWidget(Html);
       }
       
       using (var group = new CustomGroup(Html, form) { Title = "Список публикаций в печатном издании", DDClass = "addEdition" }.Open())
       {
           new PublicationLinkModule(Model) { Relation = "PublicationLinks" }.RelatedEditWidget(Html);
       }

       using (var group = new CustomGroup(Html, form) { Title = "Технология" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.DevelopmentStage);
               Html.RenderEditor(s => s.InnovativeFeatures);
               Html.RenderEditor(s => s.CompetitiveAdvantages);
               Html.RenderEditor(s => s.Scope);
               Html.RenderEditor(s => s.ResourcesDevelopment);
               Html.RenderEditor(s => s.WayCommercialization);
               Html.RenderEditor(s => s.RestrictionsCommercialization);
               Html.RenderEditor(s => s.ExpectedMarket);
               Html.RenderEditor(s => s.CommercialExperience);
               Html.RenderEditor(s => s.AdditionalInformation);
               Html.RenderEditor(s => s.ShortDescription);
               Html.RenderEditor(s => s.Text);
           }
       }
       using (var control = new CustomSubmitRow(Html).Open().ObjectEditToolbar())
       {

       }  
                
   }

%>
</asp:Content>
