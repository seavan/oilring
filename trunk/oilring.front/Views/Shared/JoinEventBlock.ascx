<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IJoinableEventEnhancable>" %>
<% if(Request.IsAuthenticated) {
      if (Model.PSEUDO_IsJoinRequestAccepted)
      {
%>
<div class="ibutton addColleag hide">������� ������������</div>
<%
      }
      else if (Model.PSEUDO_IsJoinRequestSent)
      {
          %>
<div class="ibutton addColleag hide">��������� ������</div>
          <%
      }
      else
      {
          %>
<div class="ibutton addColleag _joinRequest" data-uri='<%=Html.SingleUserAction<UserObject>(Model, "JoinEvent")%>'>������ ������</div>
          <%
      }
} %>
