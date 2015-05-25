<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.OrganizationObject>()
        .Name("t_Organization")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Organization").
                                        Update("_Update", "Organization").
                                        Insert("_Insert", "Organization").
                                        Delete("_Delete", "Organization")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.Published).Width(80);
					
						c.Bound(col => col.Approved).Width(80);
					
						c.Bound(col => col.Title_RU_I18N).Width(80);
					
						c.Bound(col => col.IsApproved).Width(80);
					
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Organization");
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
