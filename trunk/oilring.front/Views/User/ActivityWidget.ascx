<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
            <div class="materialBlockIn">
                <!--фильтр-->
                <% 
                    var amod = new ArticleModule(Model) { Relation = "ArticleAuthorObject", ShowDrafts = 1, Ajax = false, Delayed = false, PageSize = 6, Page = 1 }; %>
                <% var smod = new SeminarModule(Model) { Relation = "SeminarAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                <% var cmod = new ConferenceModule(Model) {  Relation = "ConferenceAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                <% var dmod = new DiscussionModule(Model) { Relation = "DiscussionAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                <% var gmod = new GrantModule(Model) { Relation = "GrantAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                <% var tmod = new TechnoModule(Model) { Relation = "TechnoAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                   <% var commentmod = new CommentModule(Model) { Ajax = true, Delayed = true, PageSize = 6, Page = 1 };

                   var filter = "<ul class=\"filtr\">" +
                   "<li class=\"cur borderAll10 _moduleAction _filterAll\" rel=\"filter\" rev=\"{0}\"><span>Все</span></li>" +
                   "<li class=\"_moduleAction _filterPublished\" rel=\"filter\" rev=\"{0}\"><span>Опубликованные</span></li>" +
                   "<li class=\"_moduleAction _filterDrafts\" rel=\"filter\" rev=\"{0}\"><span>Черновики</span></li>" +
                   "<li class=\"_moduleAction _filterFavourites\" rel=\"filter\" rev=\"{0}\"><span>Избранное</span></li>" +
               "</ul>";
                       
                       
                %>
                <ul class="filtr _userActivitySelector">
                    <li class="cur borderAll10" rel="<%= amod.ModuleId %>"><span>Материалы</span></li>
                    <li rel="<%= smod.ModuleId %>"><span>Семинары</span></li>
                    <li rel="<%= cmod.ModuleId %>"><span>Конференции</span></li>
                    <li rel="<%= dmod.ModuleId %>"><span>Дискуссии</span></li>
                    <li rel="<%= gmod.ModuleId %>"><span>Гранты</span></li>
                    <li rel="<%= tmod.ModuleId %>"><span>Технологии</span></li>
                    <!-- <li rel="<%= commentmod.ModuleId %>"><span>Комментарии</span></li> -->
                </ul>
                <!--/фильтр-->
                <!--фильтр-->
                <% amod.Tab(Html, filter); %>
                <% smod.Tab(Html, filter); %>
                <% cmod.Tab(Html, filter); %>
                <% dmod.Tab(Html, filter); %>
                <% gmod.Tab(Html, filter); %>
                <% tmod.Tab(Html, filter); %>
                <% commentmod.Tab(Html, filter); %>

            </div>
        </div>
        <div class="block2">
            <% Html.RenderPartial("BannerBlock"); %>
        </div>
    </div>
</div>
