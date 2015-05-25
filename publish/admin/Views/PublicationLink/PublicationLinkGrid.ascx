<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.PublicationLinkObject>()
        .Name("t_PublicationLink")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "PublicationLink").
                                        Update("_Update", "PublicationLink").
                                        Insert("_Insert", "PublicationLink").
                                        Delete("_Delete", "PublicationLink")
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
					
						c.Bound(col => col.PublicationTitle).Width(80);
					
						c.Bound(col => col.ISBN).Width(80);
					
						c.Bound(col => col.Publisher).Width(80);
					
						c.Bound(col => col.Editor).Width(80);
					
						c.Bound(col => col.REF_Journal_Id).Width(80);
					
						c.Bound(col => col.ISSN).Width(80);
					
						c.Bound(col => col.TypePublication).Width(80);
					
						c.Bound(col => col.DatePublication).Width(80);
					
						c.Bound(col => col.NumberEdition).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("PublicationLink");
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
