<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db._AuthorLinkObject>()
        .Name("t__AuthorLink")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "_AuthorLink").
                                        Update("_Update", "_AuthorLink").
                                        Insert("_Insert", "_AuthorLink").
                                        Delete("_Delete", "_AuthorLink")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectId).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.IsUser).Width(80);
					
						c.Bound(col => col.UserId).Width(80);
					
						c.Bound(col => col.UserInfo).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("_AuthorLink");
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
