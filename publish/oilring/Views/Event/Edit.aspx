<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<admin.db.EventObject>"  MasterPageFile="~/Views/Shared/MainInner.master"%>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<% using(var form = new CustomForm(Html) { Title = "Добавление материала", BlockClass = "addMaterialsBlock", ListClass = "iForm"}.Open() )
   {
       using (var group = new CustomGroup(Html, form) { Title = "Добавление рубрики" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление авторов" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Выбор языка" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Прикрепленные файлы" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Добавление тэгов" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Список публикаций в печатном издании" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Ссылки на материал на сторонних ресурсах" }.Open())
       {
       }
       using (var group = new CustomGroup(Html, form) { Title = "Статья" }.Open())
       {
       }
                
   }

%>
</asp:Content>
