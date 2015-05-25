<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PatentObject>" %>
<li class="_id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
    <div class="delete" title="Удалить">Удалить</div>
    <%= Model.Title + ", " + Model.Number %>
    <span class="_param" rel="Title" rev="<%= Model.Title %>"></span>   
    <span class="_param" rel="Number" rev="<%= Model.Number %>"></span>
<%--    <span class="_param" rel="REL_Id" rev="<%= Model.REL_Id %>"></span>
    <span class="_param" rel="REL_ObjectType" rev="<%= Model.REL_ObjectType %>"></span>--%>
</li>