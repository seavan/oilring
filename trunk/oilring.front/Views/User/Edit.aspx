<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<UserObject>" MasterPageFile="~/Views/Shared/MainUser.master" %>

<asp:Content ContentPlaceHolderID="m_Middle" ID="m1" runat="server">
    <!--середина-->
    <div id="mainwrap">
        <div class="topPanel borderTop10">
            <div class="userName">
                <%: Model.FirstName %>
                <%: Model.MiddleName %>
                <%: Model.LastName %></div>
        </div>
        <div id="middleWrap" class="borderBot10">
            <div class="block1 borderAll10">
                <% Html.RenderPartial("Menu"); %>
                <!--профиль-->
                <% using (var form = new CustomUserForm(Html, Model) { BlockClass = "profileBlockEdit iForm", Action = "SaveAjax" }.Open())
                   {%>
                <div class="block8">
                    <div class="avatar">
                        <img src="<%= RES.IMAGE_CONTENT_URI %><%=Model.NormalAvatar%>" alt="" class="avatar" />
                        <div class="newFotoDoor _uploadingBlock _avatar">
                            <input type="file" id="ffileUploadField" name="ffileUploadField" />
                            <span class="addFileDoor _uploadFilesButton" style="width:100%"><span>Изменить фото</span></span>
                            <input type="hidden" id="fserverLangCode" value="<%: Html.LC().LANG_CODE %>" />
                        </div>
                    </div>
                    <ul class="sex check">
                        <li>
                            <label for="man">
                                <%:Html.RadioButtonFor(m => m.Sex, false, new { id = "manSex" })%>Мужчина</label></li>
                        <li>
                            <label for="female">
                                <%:Html.RadioButtonFor(m => m.Sex, true, new { id = "femaleSex" })%>Женщина</label></li>
                    </ul>
                </div>
                <div class="block9">
                    <!--личное-->
                    <div class="personal">
                        <div class="column">
                            <%
Html.RenderEditor(s => s.FirstName);
Html.RenderEditor(s => s.LastName);
Html.RenderEditor(s => s.MiddleName);
Html.RenderEditor(s => s.Specialty);
                            %>
                            <div>
                                <span>Дата рождения </span>
                                <% Html.RenderDateEditor(s => s.BirthDate);%>
                            </div>
                        </div>
                        <%--<div class="column">
							<div class="field">
								<label for="fnameeng" class="name">First name</label>
								<div class="borderAll10 input"><div><input type="text" value="" id="fnameeng" /></div></div>
							</div>
							<div class="field">
								<label for="fname2eng" class="name">Last name</label>
								<div class="borderAll10 input"><div><input type="text" value="" id="fname2eng" /></div></div>
							</div>
						</div>--%>
                    </div>
                    <!--/личное-->
                    <!---->
                    <dl class="infoList">
                        <dt>Контактная информация:</dt>
                        <dd class="contact">
                            <%Html.RenderEditor(s => s.City); %>
                            <% (new ContactModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).RelatedEditWidget(Html); %>
                        </dd>
                        <% (new LanguageModule(Model) { Relation = "UserLanguage" }).RelatedEditWidget(Html); %>
                        <% (new User_UniverModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).RelatedEditWidget(Html); %>
                        <% (new User_JobModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).RelatedEditWidget(Html); %>
                        <% (new User_DegreeModule(Model) { REL_ObjectID = Model.Id, REL_ObjectType = Model.ObjectType }).RelatedEditWidget(Html); %>
                        <dt>Интересующие категории ВАК:</dt>
                        <dd class="addRubric">
                            <%new RubricModule(Model) { Relation = "Rubrics" }.RelatedEditWidget(Html); %>
                        </dd>
                        <dt>Интересы:</dt>
                        <dd class="interests">
                            <%new TagModule(Model) { Relation = "Tags" }.RelatedEditWidget(Html); %>
                        </dd>
                    </dl>
                    <!--/-->
                    <div class="but">
                        <input type="submit" value="Сохранить изменения" class="ibutton _publish draft _ajax "
                            rel="draft" />
                        <%--<input type="submit" value="Сохранить изменения" class="ibutton" />--%>
                    </div>
                </div>
                <%} %>
                <!--/профиль-->
            </div>
            <div class="block2">
                <% Html.RenderPartial("BannerBlock"); %>
            </div>
        </div>
    </div>
    <!--/середина-->
</asp:Content>
