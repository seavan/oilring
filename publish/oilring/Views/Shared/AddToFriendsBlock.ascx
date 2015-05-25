<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<%if(Request.IsAuthenticated && !Model.PSEUDO_Self) {
      if (Model.PSEUDO_IsInFriends)
      {
%>
<div class="ibutton addColleag hide">Добавлен в коллеги</div>
<%
      }
      else if (Model.PSEUDO_IsFriendRequestSent)
      {
          %>
<div class="ibutton addColleag hide">Отправлен запрос</div>
          <%
      }
      else
      {
          %>
<div class="ibutton addColleag _friendRequest" data-uri='<%=Html.SingleUserAction<UserObject>(Model, "AddToFriends")%>'>Добавить в коллеги</div>
          <%
      }
} %>
