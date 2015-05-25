<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.UserObject>()
        .Name("t_User")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User").
                                        Update("_Update", "User").
                                        Insert("_Insert", "User").
                                        Delete("_Delete", "User")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.Published).Width(80);
					
						c.Bound(col => col.Approved).Width(80);
					

					
						c.Bound(col => col.FirstName).Width(80);
					
						c.Bound(col => col.LastName).Width(80);

					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User");
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
