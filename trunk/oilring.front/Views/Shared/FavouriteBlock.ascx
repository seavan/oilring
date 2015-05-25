<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IUserEnhancable>" %>
<%if(Request.IsAuthenticated) {%>
<div class='_favSetter icFavorite <%= Model.PSEUDO_IsUserFavourite ? "add" : "" %>' data-uri='<%= Html.SingleUserAction<UserObject>(Model, "SetFavourite") %>'>избранное</div>
<%} %>
