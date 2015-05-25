<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ContactObject>" %>

<div class="field _id <%= Model.Id == 0 ? "_create" : ""%>" rel='<%= Model.Id %>' rev='<%= Model.ObjectType.Trim() %>'>
	<label for="f<%: Model.ContactType + Model.Id%>" class="name <%: Model.ContactType %>">
    <% 
        switch (Model.ContactType)
        {
            case "mail": Writer.WriteLine("e-mail"); break;
            case "phone": Writer.WriteLine("телефон"); break;
            default: Writer.WriteLine(Model.ContactType); break;
        } 
    %>
    </label>
	<div class="borderAll10 input"><div><input type="text" value="<%= Model.Value %>" id="f<%: Model.ContactType + Model.Id%>" class="_forValue"/></div></div>
	<span class="delete" title="Удалить">Удалить</span>

    <span class="_param" rel="ContactType" rev="<%= Model.ContactType %>"></span>   
    <span class="_param _frominput" rel="Value" rev="<%= Model.Value %>"></span>
</div>	