<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.ArticleObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using(var form = new CustomEntityForm(Html, Model) { Title = "Добавление материала", BlockClass = "addMaterialsBlock", ListClass = "iForm", Action = "SaveAjax"}.Open() )
   {
       
       using (var group = new CustomGroup(Html, form) { Title = "Добавление рубрики", DDClass = "addRubric show" }.Open())
       {
           new RubricModule(Model) { Relation = "Rubrics" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление авторов", DDClass = "addAutor" }.Open())
       {
           new UserModule(Model) { Relation = "ObjectAuthor", ViewName = "RelatedEditWidgetAuthor" }.RelatedEditWidget(Html);
       }
       /*using (var group = new CustomGroup(Html, form) { Title = "Выбор языка" }.Open())
       {
       }*/
       using (var group = new CustomGroup(Html, form) { Title = "Прикрепленные файлы" }.Open())
       {
           new FileAttachmentModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
           new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Список публикаций в печатном издании", DDClass = "addEdition" }.Open())
       {
           new PublicationLinkModule(Model) { Relation = "PublicationLinks" }.RelatedEditWidget(Html);
       }
       using (var group = new CustomGroup(Html, form) { Title = "Ссылки на материал на сторонних ресурсах" }.Open())
       {
           new OuterLinkModule(Model) { Relation = "OuterLinks" }.RelatedEditWidget(Html); 
       }
       using (var group = new CustomGroup(Html, form) { Title = "Статья" }.Open())
       {
           using (var wrap = new CustomWrap(Html) { Wrap = "addFileWrap" }.Open())
           {
%>
        <span class="_uploadingBlock _converter"><input type="file" id="ffileUploadField" class="_convertField" name="fileImportField" /></span>
        <div class="note">Поддерживаются форматы DOC, DOCX. Импорт статьи займет некоторое время. При импорте статьи содержимое статьи обновится.</div>
									<span class="addFileDoor"><span class="_converterCaption">Импортировать статью из файла</span></span>	
        <input type="hidden" id="fserverLangCode" value="<%: Html.LC().LANG_CODE %>"/>
<%
           }
           using (var wrap = new CustomWrap(Html) { Wrap = "addArticle" }.Open())
           {
               Html.RenderEditor(s => s.Title, true, "Максимум 250 символов");
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
