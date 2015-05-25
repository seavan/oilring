<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<FileAttachmentObject>>" %>
<% 
    if (Model.Count() > 0)
    {
        var counter = 0;
%>
<dl class="downloadBlock">
    <dt>Прикрепленные файлы к статье (<%=Model.Count()%>):</dt>
    <dd>
        <ul class="download">
        <% 
            foreach (var item in Model){
                if(counter == 3)
                {
                    counter = 0;
                    %></ul><ul class="download"><%
                }
        %>        
            <li class="<%: item.Title.ClassNameForTypeFile() %>">

            <a href="<%: Url.Action("DownloadFile", "FileAttachment", new { id = item.Id})%>"><%: item.Title %></a>
            
            <br /><%:item.PrettyFileSize %></li>
        <%} %>
        </ul>
    </dd>
</dl>
<%} %>