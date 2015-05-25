<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IJoinableEventEnhancable>" %>
<% if(Request.IsAuthenticated) {
      if (Model.PSEUDO_IsJoinRequestAccepted)
      {
%>
<div class="ibutton addColleag hide">Участие подтверждено</div>
<%
      }
      else if (Model.PSEUDO_IsJoinRequestSent)
      {
          %>
<div class="ibutton addColleag hide">Отправлен запрос</div>
          <%
      }
      else
      {
          %>
<div class="ibutton addColleag _joinRequest" data-uri='<%=Html.SingleUserAction<UserObject>(Model, "JoinEvent")%>'>Подать заявку</div>
          <%
      }
} %>
