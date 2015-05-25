<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
			
<%
    Html.Telerik().Grid<admin.db.UserObject>()
        .Name("t_User")
        .DataBinding(dataBinding => dataBinding.Ajax().
                                        Select("_Select", "User").
                                        Update("_Update", "User").
                                        Insert("_Insert", "User").
                                        Delete("_Delete", "User")
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
					
						c.Bound(col => col.LastVisitDate).Width(80);
					
						c.Bound(col => col.RegistrationDate).Width(80);
					
						c.Bound(col => col.IsOnline).Width(80);
					
						c.Bound(col => col.Photo).Width(80);
					
						c.Bound(col => col.FirstName).Width(80);
					
						c.Bound(col => col.LastName).Width(80);
					
						c.Bound(col => col.BirthDate).Width(80);
					
						c.Bound(col => col.City).Width(80);
					
						c.Bound(col => col.MiddleName).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Guid).Width(80);
					
						c.Bound(col => col.AUTO_DefaultPhoto_Alt).Width(80);
					
						c.Bound(col => col.Specialty).Width(80);
					
						c.Bound(col => col.UserLogin).Width(80);
					
						c.Bound(col => col.Password).Width(80);
					
						c.Bound(col => col.Activation_guid).Width(80);
					
						c.Bound(col => col.Sex).Width(80);
					
						c.Bound(col => col.Options_SubscribeNews).Width(80);
					
						c.Bound(col => col.Options_SubscribePrivateMessages).Width(80);
					
						c.Bound(col => col.Options_SubscribeNewComments).Width(80);
					
						c.Bound(col => col.Options_SubscribeJoin).Width(80);
					
						c.Bound(col => col.Options_SubscribeFriendRequest).Width(80);
					
						c.Bound(col => col.Options_ShowAge).Width(80);
					
						c.Bound(col => col.Options_ShowContacts).Width(80);
					
						c.Bound(col => col.Options_ShowJobs).Width(80);
					
						c.Bound(col => col.Options_ShowEducations).Width(80);
					
						c.Bound(col => col.Options_ShowMiddleName).Width(80);
					
						c.Bound(col => col.Options_ShowInterests).Width(80);
					
						c.Bound(col => col.Recoverpass_guid).Width(80);
					
						c.Bound(col => col.IsAdmin).Width(80);
					
						c.Bound(col => col.UseSelectedRubrics).Width(80);
					
						c.Bound(col => col.OneRubricSelection).Width(80);
					                                 
					c.Bound( col => col.Id ).Width(100).Edit("User");
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
