<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_DegreeObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>������ ������ � �������:</dt>
<dd>
	<dl class="list">
        <%--<dt>������ �������:</dt>--%>
		<dd>
            <%foreach (var item in Model){%>
            <%: item.IssueDate.Year %> �. <%:item.Title %><br />
			<span>�������������:</span> <%: item.Specialty %>
            <%if(!string.IsNullOrEmpty(item.WorkTitle)) {%>
                <br />
                <span>������:</span> 
                <%if(item.Article_ID.HasValue) {%>
                <a href="<%: Url.Action("Single", "Article", new {Lang =  Html.LC().LANG_CODE, id = item.Article_ID.Value})%>"><%= HttpUtility.HtmlDecode(item.WorkTitle) %></a>
                <%} else {%>
                <%= HttpUtility.HtmlDecode(item.WorkTitle) %>
                <%} %>
                <%: item.Id == Model.Last().Id ? "" : "<br /><br />"%>
            <%} %>
            <%} %>			
		</dd>

		<%--<dt>������ ������:</dt>
		<dd>
			2003 �. �������� ������� ���������<br />
			<span>�������������:</span> �����������<br />
			<span>������:</span> <a href="#">������������ ���������� ����</a>
		</dd>
		<dt>������ �������:</dt>
		<dd>
			2003 �. �������� ������� ���������<br />
			<span>�������������:</span> �����������<br />
			<span>������:</span> <a href="#">������������ ���������� ����</a><br /><br />
			2003 �. �������� ������� ���������<br />
			<span>�������������:</span> �����������<br />
			<span>������:</span> <a href="#">������������ ���������� ����</a>
		</dd>
		<dt>������������� ������:</dt>
		<dd>
			2003 �. �������� ������� ���������<br />
			<span>�������������:</span> �����������<br />
			<span>������:</span> <a href="#">������������ ���������� ����</a><br /><br />
			2003 �. �������� ������� ���������<br />
			<span>�������������:</span> �����������<br />
			<span>������:</span> <a href="#">������������ ���������� ����</a>
		</dd>--%>
	</dl>
</dd>
<%} %>	