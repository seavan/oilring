<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<admin.db.EventObject>>"  MasterPageFile="~/Views/Shared/MainInner.master" %>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
<div class="newsListBlock">
    <h1>Новости</h1>

    <% var obj = new EventModule() { PageSize = 5 };%>
    <ul class="materialList">
        <% obj.List(Html); %>
    </ul>    
    <% obj.Pager(Html); %>
</div>
</asp:Content>