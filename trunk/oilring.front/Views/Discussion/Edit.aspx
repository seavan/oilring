<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.DiscussionObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using (var form = new CustomEntityForm(Html, Model) { Title = "Добавление дискуссии", BlockClass = "addMaterialsBlock", ListClass = "iForm", Action = "SaveAjax" }.Open())
   {
       using (var group = new CustomGroup(Html, form) { Title = "Добавление рубрики", DDClass = "addRubric show" }.Open())
       {
           new RubricModule(Model) { Relation = "Rubrics" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Дискуссия" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Title, true, "Максимум 250 символов");
               Html.RenderEditor(s => s.ShortDescription);
           }
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
           new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Прикрепленные файлы" }.Open())
       {
           new FileAttachmentModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var control = new CustomSubmitRow(Html).Open().ObjectEditToolbar())
       {

       }    
   }

%>
</asp:Content>
