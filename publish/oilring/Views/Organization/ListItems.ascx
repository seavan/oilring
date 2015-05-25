<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OrganizationObject>>" %>	
<%
    string letter = string.Empty; 
    bool newletter = true;
    var m = Model.Where(s => s.Title.Length > 0);
    if (m.Count() > 0)
    {
        letter = m.First().Title.Substring(0, 1).ToUpper();
        newletter = false;        
        int counter = 0;
    
%>

<dt><%:letter%>.</dt>
<dd>
	<div class="line">
<% 
    foreach (var item in m){
        if (letter != item.Title.Substring(0, 1).ToUpper())
        {
            letter = item.Title.Substring(0, 1).ToUpper();
            newletter = true;
        }
        //++counter;
       
%>

<%if (newletter)
  {
      counter = 0;%>        
    </div>
</dd>
<dt><%:letter%>.</dt>
<dd>
	<div class="line">
<%} %>

        <%if (counter % 2 == 0) {counter=0;%>
        </div>
        <div class="line">
        <%}%>
		<%--<%if (counter <= 2) {%>	--%>		
            <div class="block">
				<img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" />
				<div class="name"><a href="<%= Html.SingleUri(item) %>"><%= item.Title %></a></div>
				Работают или работали здесь: <a href="#"><%: ((long)item.AUTO_WorkerCount).ToCounterWordForm("пользователь", "пользователя", "пользователей", false)%></a><br />
				Учатся или учились здесь: <a href="#"><%: ((long)item.AUTO_ScholarCount).ToCounterWordForm("пользователь", "пользователя", "пользователей", false)%></a>								
			</div>
		<%--<%} else{counter=0;%>
        </div>
        <div class="line">
        <%} %>--%>
		
	
<%newletter = false;++counter;} %>
       
    </div>
</dd>
<%} %>		