<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<FileAttachmentObject>>" %>

<% foreach (var file in Model){%>
    <li class="<%: file.Title.ClassNameForTypeFile() %> _id <%= file.Id == 0 ? "_create" : ""%>" rel="<%= file.Id %>" rev="<%= file.ObjectType %>">
        
        <%if (file.Id > 0) {%>
        <a href="<%: Url.Action("DownloadFile", "FileAttachment", new { id = file.Id})%>"><%= file.Title %></a>
        <%} else {%>
        <%= file.Title %>
        <%} %>

        <br/>
        <%= file.PrettyFileSize %>
        <div class="delete" title="Удалить">Удалить</div>


        <span class="_param" rel="Title" rev="<%= file.Title %>"></span>        
    </li>
<%}%>