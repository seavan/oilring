<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.GrantObject>()
        .Name("t_Grant")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Grant").
                                        Update("_Update", "Grant").
                                        Insert("_Insert", "Grant").
                                        Delete("_Delete", "Grant")
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
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.AUTO_CommentCount).Width(80);
					
				
						c.Bound(col => col.Title).Width(80);

						c.Bound(col => col.CompleteDeadline).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Grant");
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
