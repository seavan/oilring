<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.RubricObject>()
        .Name("t_Rubric")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Rubric").
                                        Update("_Update", "Rubric").
                                        Insert("_Insert", "Rubric").
                                        Delete("_Delete", "Rubric")
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
					
						c.Bound(col => col.Parent_Rubric_ID).Width(80);
					
						c.Bound(col => col.Alias).Width(80);
					
						c.Bound(col => col.Header).Width(80);
					
						c.Bound(col => col.MenuTitle_RU_I18N).Width(80);
					
						c.Bound(col => col.MenuTitle_EN_I18N).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Rubric");
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
