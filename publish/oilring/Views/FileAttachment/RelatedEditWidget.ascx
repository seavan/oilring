<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<FileAttachmentObject>>" %>
<div class="_uploadingBlock">
    <ul class="download">
        <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>
    </ul>
    <div>
        <input type="file" id="ffileUploadField" name="ffileUploadField" />
        <span class="addFileDoor _uploadFilesButton"><span>Добавить файл</span></span>
        <input type="hidden" id="fserverLangCode" value="<%: Html.LC().LANG_CODE %>"/>
    </div>
</div>
