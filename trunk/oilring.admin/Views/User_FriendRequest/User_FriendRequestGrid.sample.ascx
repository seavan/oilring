<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.User_FriendRequestObject>()
        .Name("t_User_FriendRequest")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User_FriendRequest").
                                        Update("_Update", "User_FriendRequest").
                                        Insert("_Insert", "User_FriendRequest").
                                        Delete("_Delete", "User_FriendRequest")
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
					
						c.Bound(col => col.Target_User_ID).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User_FriendRequest");
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
