<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.ViewUserMaterialObject>()
        .Name("t_ViewUserMaterial")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "ViewUserMaterial").
                                        Update("_Update", "ViewUserMaterial").
                                        Insert("_Insert", "ViewUserMaterial").
                                        Delete("_Delete", "ViewUserMaterial")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.Lang).Width(80);
					
						c.Bound(col => col.Published).Width(80);
					
						c.Bound(col => col.Approved).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.ShortDescription).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ObjectAuthorId).Width(80);
					
						c.Bound(col => col.ObjectAuthorType).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("ViewUserMaterial");
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
