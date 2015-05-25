<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_GroupObject>>" %>

<ul class="userPeopleList">
<% foreach (var ug in Model)
   {
       %>
    <li>
        <div>
            <span class="peopleDoor show borderTop10"><span class="_groupTitle"><%= ug.Title %></span> (<%= ug.AUTO_User_Count %>)</span>
            <span class="deleteList _deleteFriendGroup"  data-uri='<%=Html.SingleUserAction<User_GroupObject>(ug, "DeleteGroup")%>'>
            <span>Удалить список</span></span></div>
        <!-- при клике добавляем show -->
        <!--записаны на семинар-->
        <div class="peopleBlock borderTopLeftNone" style="display: block;">
            <!--по клику раскрываем-->
			<%
                var module = new UserModule(ug) { Relation = "GroupFriendLink", ViewName = "RelatedListWidgetFriendsGroup" };
                module.List(Html);
            %>
            <span class="more _addPeopleControl" rel="<%=ug.Id%>"><span>Добавить людей в этот список</span></span>
        </div>
        <!--/записаны на семинар-->
    </li>
    <%
   }%>
</ul>
