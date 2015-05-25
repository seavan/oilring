<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RubricObject>" MasterPageFile="~/Views/Shared/MainInnerNoMenu.master" %>

<asp:Content ContentPlaceHolderID="m_Middle" runat="server" ID="m_Middle">
    <div class="searchReult">
        <h1>
            Поиск по рубрике &laquo;<%= Model.Header %>&raquo;</h1>
            <% var mod = (new Dummy_SearchObjectModule() { ViewName = "SearchResult", PageSize = 5 }); %>
            <% mod.SetSearchRubricId(Model.Id); %>

            <% mod.EntityTypeFilter(Html); %>
            <% mod.ListWidget(Html); %>
            <% mod.Pager(Html, "Pager"); %>
    </div>
</asp:Content>
