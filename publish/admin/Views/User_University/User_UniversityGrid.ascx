<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.User_UniversityObject>()
        .Name("t_User_University")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User_University").
                                        Update("_Update", "User_University").
                                        Insert("_Insert", "User_University").
                                        Delete("_Delete", "User_University")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.User_ID).Width(80);
					
						c.Bound(col => col.StartYear).Width(80);
					
						c.Bound(col => col.EndYear).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.Faculty).Width(80);
					
						c.Bound(col => col.Department).Width(80);
					
						c.Bound(col => col.Group).Width(80);
					
						c.Bound(col => col.Specialty).Width(80);
					
						c.Bound(col => col.State).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User_University");
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
