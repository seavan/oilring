<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.TechnoObject>()
        .Name("t_Techno")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "Techno").
                                        Update("_Update", "Techno").
                                        Insert("_Insert", "Techno").
                                        Delete("_Delete", "Techno")
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
					
						c.Bound(col => col.Title).Width(80);
					
						c.Bound(col => col.ShortDescription).Width(80);
					
						c.Bound(col => col.Text).Width(80);
					
						c.Bound(col => col.CreationDate).Width(80);
					
						c.Bound(col => col.PublicationDate).Width(80);
					
						c.Bound(col => col.ModificationDate).Width(80);
					
						c.Bound(col => col.AUTO_CommentCount).Width(80);
					
						c.Bound(col => col.AUTO_Comment_LastDateTime).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Guid).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Alt).Width(80);
					
						c.Bound(col => col.PSEUDO_IsUserFavourite).Width(80);
					
						c.Bound(col => col.PSEUDO_NewCommentCount).Width(80);
					
						c.Bound(col => col.DevelopmentStage).Width(80);
					
						c.Bound(col => col.InnovativeFeatures).Width(80);
					
						c.Bound(col => col.CompetitiveAdvantages).Width(80);
					
						c.Bound(col => col.Scope).Width(80);
					
						c.Bound(col => col.ResourcesDevelopment).Width(80);
					
						c.Bound(col => col.WayCommercialization).Width(80);
					
						c.Bound(col => col.RestrictionsCommercialization).Width(80);
					
						c.Bound(col => col.ExpectedMarket).Width(80);
					
						c.Bound(col => col.CommercialExperience).Width(80);
					
						c.Bound(col => col.AdditionalInformation).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("Techno");
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
