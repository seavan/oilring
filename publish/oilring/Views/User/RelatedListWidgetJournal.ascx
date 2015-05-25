<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<div class="peopleBlock borderAll10" style="display: block;"> <!--�� ����� ����������-->
    <%if(Model.Count()>0) {%>

	<ul class="filtr">
		<li class="cur borderAll10">���</li>
		<li><a href="#">�������</a></li>
	</ul>

	<div class="slider">
		<span class="cur" title="1">&nbsp;</span>
		<span title="2">&nbsp;</span>
		<span title="3">&nbsp;</span>
		<span title="4">&nbsp;</span>
	</div>

	<div class="list">
        
		<ul>
            <%
                int counter = 0;
                foreach (var item in Model)
                {
                    if (counter == 3)
                    {%></ul><ul><%}
                    else
                    {
                        %>
                        <li>
                            <a href="<%= OilringHtml.SingleUri(item) %>"><img src="/Content/images/<%=item.SmallAvatar%>" alt="" /><%= item.DisplayName %></a><br />				            
				            ������ ������������� ����<br />
				            <span>������, ���������</span>
			            </li>
                        <%
                        ++counter;
                    }%>

            <%} %>
            </ul>	

	</div>
    <%} %>
</div>
