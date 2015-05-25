<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.ParagraphObject>()
        .Name("t_Paragraph")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Paragraph").
                                        Update("_Update", "Paragraph").
                                        Insert("_Insert", "Paragraph").
                                        Delete("_Delete", "Paragraph")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.Published).Width(80);
					
						c.Bound(col => col.Approved).Width(80);
					
						c.Bound(col => col.Lang).Width(80);
					
						c.Bound(col => col.Article_ID).Width(80);
					
						c.Bound(col => col.ParagraphNo).Width(80);
					
						c.Bound(col => col.Text).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Paragraph");
                    c.Command(cmd =>
                                  {
                                      cmd.Delete();
                                  }
                        ).Width(100);
                }
        )
        .Editable( s => s.Mode(GridEditMode.PopUp))
        .Resizable( rs => rs.Columns(true))
        .Sortable()
        .Filterable()
        .Pageable(
            pager => pager.PageSize(20)
        )
        .ClientEvents(events => events.OnEdit("gridEdit"))
        .Render();
%>
</asp:Content>
