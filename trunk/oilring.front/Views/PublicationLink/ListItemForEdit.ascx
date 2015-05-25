<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PublicationLinkObject>" %>
<li class="_id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<div class="delete" title="Удалить">Удалить</div>
    <%if(Model.REF_Journal_Id.HasValue){ %>
    <a href="<%: Url.Action("Single", "Journal", new { Lang = Html.LC().LANG_CODE, id = Model.REF_Journal_Id.Value })%>"><%= Model.PublicationTitle%></a>
    <%} else {%>
    <%= Model.PublicationTitle%>
    <%} %><%: Model.DatePublication.HasValue ? ", " + Model.DatePublication.Value.ToStringJournalDate() : "" %>

	<span>
        <%if(!string.IsNullOrEmpty(Model.ISBN)) {%>
		ISBN <%: Model.ISBN %>
        <%} %>
        <%if(!string.IsNullOrEmpty(Model.ISBN) && !string.IsNullOrEmpty(Model.ISSN)){%>
        <br />
        <%} %>
        <%if(!string.IsNullOrEmpty(Model.ISSN)) {%>
		ISSN <%: Model.ISSN %>
        <%} %>
	</span>


    <span class="_param" rel="PublicationTitle" rev="<%= Model.PublicationTitle %>"></span>
    <span class="_param" rel="ISBN" rev="<%= Model.ISBN %>"></span>  
    <span class="_param" rel="ISSN" rev="<%= Model.ISSN %>"></span>  
    <span class="_param" rel="Lang" rev="<%= Model.Lang %>"></span>  
    <span class="_param" rel="TypePublication" rev="<%= Model.TypePublication %>"></span>  
    <span class="_param" rel="NumberEdition" rev="<%= Model.NumberEdition %>"></span>
    <span class="_param" rel="DatePublication" rev="<%= Model.DatePublication %>"></span>
    <span class="_param" rel="REF_Journal_Id" rev="<%= Model.REF_Journal_Id %>"></span>
</li>