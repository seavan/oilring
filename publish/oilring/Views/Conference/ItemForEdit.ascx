<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ConferenceObject>" %>

<%if(Model!=null) {%>
<li class="_ajaxLoadItem">
    <div class="delete _cycle" title="Удалить">Удалить</div>
    <%: Model.Title%>
    
    <input type="hidden" id="<%:Html.IdFor(s=>s.REL_Id) %>" name="<%:Html.IdFor(s=>s.REL_Id) %>" value="<%:Model.Id %>" rel="0"/>
    <input type="hidden" id="<%:Html.IdFor(s=>s.REL_ObjectType) %>" name="<%:Html.IdFor(s=>s.REL_ObjectType) %>" value="<%:Model.ObjectType %>" rel="<%:Model.ObjectType %>"/>

</li>
<%} %>