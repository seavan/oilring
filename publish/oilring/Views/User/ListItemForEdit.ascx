<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>	

<li class="_id" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
    <div class="delete" title="Удалить">Удалить</div>
    <a href="<%= Html.SingleUri(Model) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=Model.SmallAvatar%>" alt="" /><%= Model.DisplayName %></a><br/>
            
    <%if (!string.IsNullOrEmpty(Model.Specialty)){ %><%= Model.Specialty%><br/><%} %>

    <span><%= Model.City %></span>
</li>