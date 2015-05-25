<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.User_UniverObject>()
        .Name("t_User_Univer")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User_Univer").
                                        Update("_Update", "User_Univer").
                                        Insert("_Insert", "User_Univer").
                                        Delete("_Delete", "User_Univer")
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
					
						c.Bound(col => col.StartYear).Width(80);
					
						c.Bound(col => col.EndYear).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.Faculty).Width(80);
					
						c.Bound(col => col.Department).Width(80);
					
						c.Bound(col => col.Group).Width(80);
					
						c.Bound(col => col.Specialty).Width(80);
					
						c.Bound(col => col.State).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User_Univer");
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
