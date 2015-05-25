<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.MessageTemplateObject>()
        .Name("t_MessageTemplate")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "MessageTemplate").
                                        Update("_Update", "MessageTemplate").
                                        Insert("_Insert", "MessageTemplate").
                                        Delete("_Delete", "MessageTemplate")
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
					
						c.Bound(col => col.Text).Width(80);
					
						c.Bound(col => col.Alias).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.NotificationText).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("MessageTemplate");
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
