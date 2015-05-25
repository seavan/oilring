<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Main.master" %>
<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <!--меню-->
            <% Html.RenderPartial("Menu"); %>
            <!--/меню-->
            <!---->
            <div class="mainBlockIndex">
                <div class="block3">
                    <!--семинары-->
                    <% Html.RenderPartial("SeminarBlock"); %>
                    <!--/семинары-->
                    <!--Гранты-->
                    <% Html.RenderPartial("GrantBlock"); %>
                    <!--/Гранты-->
                </div>
                <div class="block4">
                    <!--Последние материалы-->
                    <% Html.RenderPartial("ArticleBlock"); %>
                    <!--/Последние материалы-->
                    <!--Дискуссии-->
                    <% Html.RenderPartial("DiscussionBlock"); %>
                    <!--/Дискуссии-->
                </div>
                <div class="block5">
                    <!--новости-->
                    <% Html.RenderPartial("EventBlock"); %>
                    <!--/новости-->
                </div>
            </div>
            <!--/-->
        </div>
        <div class="block2">
            <!--баннеры-->
            <% Html.RenderPartial("BannerBlock"); %>
            <!--/баннеры-->
        </div>
    </div>
</asp:Content>
