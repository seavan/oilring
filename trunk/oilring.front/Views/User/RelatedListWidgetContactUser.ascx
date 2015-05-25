<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UserObject>>" %>
<dl class="autor">
    <dt>���������� ����:</dt>
    <dd>
        <%
            var counter = 0;
            foreach (var item in Model){%>
        <div class="persona"><a href="<%= Html.SingleUri(item) %>"><img src="<%= RES.IMAGE_CONTENT_URI %><%=item.SmallAvatar%>" alt="" /> <%= item.DisplayName %></a></div>
        <%
                ++counter;
                if (counter == 3) break;
            } %>

        <%if(Model.Count()>3) {%>
        <div class="more"><span>��� ��������</span></div>
        <%} %>

        <%--<div class="note">���� �� ��������� �������������� ���� �����������, ������ ��������� ������ �������������� �����.</div>
		<a href="#" class="ibutton">��������� ������</a>--%>
    </dd>
</dl>