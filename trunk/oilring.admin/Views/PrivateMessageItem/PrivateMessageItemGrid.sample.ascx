<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.PrivateMessageItemObject>()
        .Name("t_PrivateMessageItem")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "PrivateMessageItem").
                                        Update("_Update", "PrivateMessageItem").
                                        Insert("_Insert", "PrivateMessageItem").
                                        Delete("_Delete", "PrivateMessageItem")
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
					
						c.Bound(col => col.Owner_User_ID).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.IsEmailSent).Width(80);
					
						c.Bound(col => col.EmailType).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					
						c.Bound(col => col.Subject).Width(80);
					
						c.Bound(col => col.Text).Width(80);
					
						c.Bound(col => col.REL_SenderUserId).Width(80);
					
						c.Bound(col => col.REL_ReceiverUserId).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("PrivateMessageItem");
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
