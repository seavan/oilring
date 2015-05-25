<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.PhotoObject>()
        .Name("t_Photo")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Photo").
                                        Update("_Update", "Photo").
                                        Insert("_Insert", "Photo").
                                        Delete("_Delete", "Photo")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
					
						c.Bound(col => col.Id).Width(80);
					
						c.Bound(col => col.ObjectType).Width(80);
					
						c.Bound(col => col.REL_Id).Width(80);
					
						c.Bound(col => col.REL_ObjectType).Width(80);
					
						c.Bound(col => col.Published).Width(80);
					
						c.Bound(col => col.Approved).Width(80);
					
						c.Bound(col => col.Lang).Width(80);
					
						c.Bound(col => col.Owner_User_ID).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.UserFileName).Width(80);
					
						c.Bound(col => col.ImageFormat).Width(80);
					
						c.Bound(col => col.Guid).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.OrigWidth).Width(80);
					
						c.Bound(col => col.OrigHeight).Width(80);
					
						c.Bound(col => col.Width).Width(80);
					
						c.Bound(col => col.Height).Width(80);
					
						c.Bound(col => col.ThumbWidth).Width(80);
					
						c.Bound(col => col.ThumbHeight).Width(80);
					
						c.Bound(col => col.IsInText).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Photo");
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
