<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.NotificationObject>()
        .Name("t_Notification")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Notification").
                                        Update("_Update", "Notification").
                                        Insert("_Insert", "Notification").
                                        Delete("_Delete", "Notification")
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
					
						c.Bound(col => col.Text).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.AUTO_UsageCount).Width(80);
					
						c.Bound(col => col.IsEmailSent).Width(80);
					
						c.Bound(col => col.NotificationType).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					
                        // TODO: WTF?
						//c.Bound(col => col.Interaction_Entity_ID).Width(80);
					
						//c.Bound(col => col.Interaction_Entity_ObjectType).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Notification");
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
