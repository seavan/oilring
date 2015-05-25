<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserObject>" %>
<%
    UserObject cu = null;
    bool thisUser = false;
    var menu = new Dictionary<string, string>();
    
    if (Request.IsAuthenticated)
    {
        cu = ((UserPrincipal) HttpContext.Current.User).CurrentUser;
        thisUser = (cu.Id == Model.Id);
    }
%>
<div id="mainwrap">
    <% Html.RenderPartial("UserName"); %>
    <div id="middleWrap" class="borderBot10">
        <div class="block1 borderAll10">
            <% Html.RenderPartial("Menu"); %>
            <!--профиль-->
            <div class="profileBlock">
                <div class="block8">
                    <img src="<%= RES.IMAGE_CONTENT_URI %><%=Model.NormalAvatar%>" alt="" class="avatar" />
                    <!---->
                    <div class="personal">
                        <%if (Model.BirthDate.HasValue && Model.IsAgeVisible) {%>
                        <%: Model.BirthDate.Value.ToStringAge() %><br />
                        Дата рождения
                        <%: Model.BirthDate.Value.ToStringNormalDate() %><br />
                        <%} %>
                        <% if (Model.IsContactsVisible)
                           { %>
                        <%:Model.City%>
                        <% } %>
                        <% if (Request.IsAuthenticated)
                           { %>
                        <div class="addMessage addMessageDoor _messagePopup2">
                            <span>Написать сообщение</span></div>
                        <% Html.RenderPartial("AddToFriendsBlock"); %>
                        <% } %>
                    </div>
                    <!--/-->
                    <!---->
                    <dl class="personalInfo">
                        <% if(Model.IsContactsVisible)
         {
             (new ContactModule(Model)
                  {ViewName = "ListWidgetUser", REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType}).ListWidget(
                      Html); 
         }
                        %>
                        <% (new LanguageModule(Model) { ViewName = "ListWidgetUser", Relation = "UserLanguage" }).ListWidget(Html); %>
                        <% (new TagModule(Model) {ViewName = "RelatedListWidgetUser", Relation = "Tags"}).ListWidget(Html); %>
                    </dl>
                    <!--/-->
                </div>
                <div class="block9">
                    <!---->
                    <div class="personalInfo2">
                        <%if(Model.IsOnline) {%>
                        <div class="online">
                            Сейчас на сайте</div>
                        <%} %>
                        <h1>
                            <%: Model.FirstName %>
                            <%: Model.IsMiddleNameVisible ? Model.MiddleName : "" %>
                            <%: Model.LastName %>    <% if(thisUser)
       { %><a href="/ru/User/Edit/<%= Model.Id %>">редактировать</a>
    <% } %>
</h1>
                        <%if(!string.IsNullOrEmpty(Model.Specialty)) {%><div class="profession">
                            <%= Model.Specialty %></div>
                        <%} %>
                        <div class="date">
                            Зарегистрировался
                            <%: Model.RegistrationDate.ToStringNormalDate() %></div>
                    </div>
                    <!--/-->
                    <!---->
                    <dl class="userInfoList">
                        <% if (Model.IsInterestsVisible)
                           { %>
                        <dt>Интересующие категории ВАК:</dt>
                        <dd>
                            <% new RubricModule(Model) {ViewName = "RelatedListWidget2", Relation = "Rubrics"}.ListWidget(Html); %>
                        </dd>
                        <% } %>
                        <% 
                            (new User_DegreeModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html); 
                            if( Model.IsEducationVisible )
                            {
                                (new User_UniverModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).ListWidget(Html);
                            }
                        %>
                        <% if(Model.IsJobsVisible)
                           {
                               (new User_JobModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).
                                   ListWidget(Html);
                           }
                            %>
                        <dt>Опубликованные на сайте материалы:</dt>
                        <dd>
                            <% var amod = new ArticleModule(Model) { ViewName = "RelatedListWidgetUser", Relation = "ArticleAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <% var smod = new SeminarModule(Model) { ViewName = "UniversalRelatedListWidgetUser", Relation = "SeminarAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <% var cmod = new ConferenceModule(Model) { ViewName = "UniversalRelatedListWidgetUser", Relation = "ConferenceAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <% var dmod = new DiscussionModule(Model) { ViewName = "UniversalRelatedListWidgetUser", Relation = "DiscussionAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <% var gmod = new GrantModule(Model) { ViewName = "UniversalRelatedListWidgetUser", Relation = "GrantAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <% var tmod = new TechnoModule(Model) { ViewName = "UniversalRelatedListWidgetUser", Relation = "TechnoAuthorObject", Ajax = true, Delayed = true, PageSize = 6, Page = 1 }; %>
                            <!--фильтр-->
                            <ul class="filtr _userMaterialSelector">
                                <li class="cur borderAll10" rel="<%= amod.ModuleId %>"><span>Материалы</span></li>
                                <li rel="<%= smod.ModuleId %>"><span>Семинары</span></li>
                                <li rel="<%= cmod.ModuleId %>"><span>Конференции</span></li>
                                <li rel="<%= dmod.ModuleId %>"><span>Дискуссии</span></li>
                                <li rel="<%= gmod.ModuleId %>"><span>Гранты</span></li>
                                <li rel="<%= tmod.ModuleId %>"><span>Технологии</span></li>
                            </ul>
                            <!--/фильтр-->
                            <% amod.ListWidget(Html); %>
                            <% smod.ListWidget(Html); %>
                            <% cmod.ListWidget(Html); %>
                            <% dmod.ListWidget(Html); %>
                            <% gmod.ListWidget(Html); %>
                            <% tmod.ListWidget(Html); %>
                        </dd>
                    </dl>
                    <!--/-->
                </div>
            </div>
            <!--/профиль-->
        </div>
        <div class="block2">
            <% Html.RenderPartial("BannerBlock"); %>
        </div>
    </div>
</div>
