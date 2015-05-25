<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<RubricObject>>" %>
<script language="javascript" type="text/javascript">
$(document).ready( function() {
<% 
if(Model!=null)
{
    foreach (var item in Model)
    {
        switch (item.Level)
        {
            case 0:
                Html.ViewContext.Writer.WriteLine("document.FILTER.addSection( {0}, true );", item.Id);
                break;
            case 1:
                Html.ViewContext.Writer.WriteLine("document.FILTER.addSubSection( {0}, true );", item.Id);
                break;
            case 2:
                Html.ViewContext.Writer.WriteLine("document.FILTER.addCategory( {0} );", item.Id);
                break;
            default:
                break;
        }
    }
}
%>
});
</script>

