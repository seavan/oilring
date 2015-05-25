<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.SeminarObject>()
        .Name("t_Seminar")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Seminar").
                                        Update("_Update", "Seminar").
                                        Insert("_Insert", "Seminar").
                                        Delete("_Delete", "Seminar")
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
					
						c.Bound(col => col.State).Width(80);
					
						c.Bound(col => col.EventStartDate).Width(80);
					
						c.Bound(col => col.Place).Width(80);
					
						c.Bound(col => col.Owner_User_ID).Width(80);
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.AUTO_CommentCount).Width(80);
					
						c.Bound(col => col.ShortDescription).Width(80);
					
						c.Bound(col => col.Text).Width(80);
					
						c.Bound(col => col.EventEndDate).Width(80);
					
						c.Bound(col => col.AUTO_Comment_LastDateTime).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Guid).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Alt).Width(80);
					
						c.Bound(col => col.AUTO_ObjectUserVisitorCount).Width(80);
					
						c.Bound(col => col.PSEUDO_IsUserFavourite).Width(80);
					
						c.Bound(col => col.PSEUDO_NewCommentCount).Width(80);
					
                        // TODO: WTF?
						//c.Bound(col => col.Parent_Seminar_Id).Width(80);
					
						c.Bound(col => col.IsCycle).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Seminar");
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
