<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.Organization_DeptObject>()
        .Name("t_Organization_Dept")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Organization_Dept").
                                        Update("_Update", "Organization_Dept").
                                        Insert("_Insert", "Organization_Dept").
                                        Delete("_Delete", "Organization_Dept")
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
					
						c.Bound(col => col.OrganizationId).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.Parent_OrganizationDept_ID).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Organization_Dept");
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
