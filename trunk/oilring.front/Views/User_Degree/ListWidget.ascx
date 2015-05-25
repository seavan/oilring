<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<User_DegreeObject>>" %>	
<%if(Model!=null && Model.Count()>0) {%>
<dt>Ученые звания и степени:</dt>
<dd>
	<dl class="list">
        <%--<dt>Ученые степени:</dt>--%>
		<dd>
            <%foreach (var item in Model){%>
            <%: item.IssueDate.Year %> г. <%:item.Title %><br />
			<span>Специальность:</span> <%: item.Specialty %>
            <%if(!string.IsNullOrEmpty(item.WorkTitle)) {%>
                <br />
                <span>Работа:</span> 
                <%if(item.Article_ID.HasValue) {%>
                <a href="<%: Url.Action("Single", "Article", new {Lang =  Html.LC().LANG_CODE, id = item.Article_ID.Value})%>"><%= HttpUtility.HtmlDecode(item.WorkTitle) %></a>
                <%} else {%>
                <%= HttpUtility.HtmlDecode(item.WorkTitle) %>
                <%} %>
                <%: item.Id == Model.Last().Id ? "" : "<br /><br />"%>
            <%} %>
            <%} %>			
		</dd>

		<%--<dt>Ученые звания:</dt>
		<dd>
			2003 г. Бакалавр среденй категории<br />
			<span>Специальность:</span> биотехнолог<br />
			<span>Работа:</span> <a href="#">Биотехнологи завоёвывают Марс</a>
		</dd>
		<dt>Ученые степени:</dt>
		<dd>
			2003 г. Бакалавр среденй категории<br />
			<span>Специальность:</span> биотехнолог<br />
			<span>Работа:</span> <a href="#">Биотехнологи завоёвывают Марс</a><br /><br />
			2003 г. Бакалавр среденй категории<br />
			<span>Специальность:</span> биотехнолог<br />
			<span>Работа:</span> <a href="#">Биотехнологи завоёвывают Марс</a>
		</dd>
		<dt>Академические звания:</dt>
		<dd>
			2003 г. Бакалавр среденй категории<br />
			<span>Специальность:</span> биотехнолог<br />
			<span>Работа:</span> <a href="#">Биотехнологи завоёвывают Марс</a><br /><br />
			2003 г. Бакалавр среденй категории<br />
			<span>Специальность:</span> биотехнолог<br />
			<span>Работа:</span> <a href="#">Биотехнологи завоёвывают Марс</a>
		</dd>--%>
	</dl>
</dd>
<%} %>	