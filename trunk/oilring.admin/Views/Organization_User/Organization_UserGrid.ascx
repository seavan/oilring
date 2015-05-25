<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.Organization_UserObject>()
        .Name("t_Organization_User")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Organization_User").
                                        Update("_Update", "Organization_User").
                                        Insert("_Insert", "Organization_User").
                                        Delete("_Delete", "Organization_User")
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
					
						c.Bound(col => col.Organization_ID).Width(80);
					
						c.Bound(col => col.User_ID).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Organization_User");
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
