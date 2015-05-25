<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.OuterLinkObject>()
        .Name("t_OuterLink")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "OuterLink").
                                        Update("_Update", "OuterLink").
                                        Insert("_Insert", "OuterLink").
                                        Delete("_Delete", "OuterLink")
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
					
						c.Bound(col => col.Link).Width(80);
					
						c.Bound(col => col.Text).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("OuterLink");
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
