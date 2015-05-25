<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PublicationLinkObject>>" %>
<ul class="list _editList">
<%for(var i=0; i<Model.Count(); i = i+2){ %>        
        <% Html.RenderPartial("ListItemForEdit", Model.ElementAt(i)); %>    
<%} %>
</ul>
<ul class="list _editList">
<%for(var i=1; i<Model.Count(); i = i+2){ %>
        <% Html.RenderPartial("ListItemForEdit", Model.ElementAt(i)); %>      
<%} %>
</ul>