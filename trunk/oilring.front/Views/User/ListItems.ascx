<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>	
<%
    string letter = string.Empty; 
    bool newletter = true;

    if (Model.Count() > 0)
    {
        var m = Model.First();
        letter = m.LastName.Length > 0 ? m.LastName.Substring(0, 1).ToUpper() : "";
        newletter = false;
        int maxRow = Model.Count()/3;
        int counter = 0;
    
%>

<dt><%:letter%>.</dt>
<dd class="peopleBlock">
	<div class="list">
        <ul>
<% 
    foreach (var item in Model){
        if (item.LastName.Length > 0)
        {
            if (letter != item.LastName.Substring(0, 1).ToUpper())
            {
                letter = item.LastName.Substring(0, 1).ToUpper();
                newletter = true;
            }
        }
        counter++;
       
%>

<%if (newletter)
  {
      counter = 0;%>
        </ul>
    </div>
</dd>
<dt><%:letter%>.</dt>
<dd class="peopleBlock">
	<div class="list">
        <ul>
<%} %>

		<%if (counter <3) {%>
			<li>
				<a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayNameReverse %></a><br />
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%= item.City %></span>
			</li>
		<%} else{counter=0;%>
        </ul>
        <ul>
            <li>
				<a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /><%= item.DisplayNameReverse%></a><br />
				<%if (!string.IsNullOrEmpty(item.Specialty)){ %><%= item.Specialty%><br/><%} %>
				<span><%= item.City %></span>
			</li>
        <%} %>
		
	
<%newletter = false;} %>
        </ul>
    </div>
</dd>
<%} %>