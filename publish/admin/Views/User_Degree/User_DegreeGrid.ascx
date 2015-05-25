<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.User_DegreeObject>()
        .Name("t_User_Degree")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User_Degree").
                                        Update("_Update", "User_Degree").
                                        Insert("_Insert", "User_Degree").
                                        Delete("_Delete", "User_Degree")
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
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.Specialty).Width(80);
					
						c.Bound(col => col.IssuePlace).Width(80);
					
						c.Bound(col => col.IssueDate).Width(80);
					
						c.Bound(col => col.WorkTitle).Width(80);
					
						c.Bound(col => col.Article_ID).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User_Degree");
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
