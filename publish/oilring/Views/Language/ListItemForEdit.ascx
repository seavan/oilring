<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<LanguageObject>" %>

<li  class="_id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'><%:Model.Title %>&nbsp;&nbsp;&nbsp;
    <span class="delete" title="Удалить">Удалить</span>

    <span class="_param" rel="Title" rev="<%= Model.Title %>"></span>   
</li>