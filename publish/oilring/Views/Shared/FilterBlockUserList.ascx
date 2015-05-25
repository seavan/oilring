<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% var tagModule = (new TagModule() { PageSize = 0, UserFilter = 1 }); %>
<!--подборка-->
<div class="mainFiltr borderTop1 _user" style="display: none"><!-- при клике показываем -->
		<!---->
		<dl class="userFiltrBlock">
			<dt>Моя подборка</dt>
			<dd>
				<span class="clearSelection">Очистить мою подборку</span>
				<span class="findLeader">Ищу науного руководителя</span>
				<div class="selectParam iForm">
					<div class="column">
						<div class="line">
							<div class="block">
								<dl class="age">
									<dt>Возраст:</dt>
									<dd>
										<div class="scrollWrap"></div>
                                        <input type="hidden" value="" id="startAgeRange" />
                                        <input type="hidden" value="" id="endAgeRange" />
									</dd>
								</dl>
								<!--фильтр выпадашка-->
								<div class="filtrSelectBlock rubric">
									<div class="border borderAll10"><!-- при клике добавляем show к ul -->
										<ul class="borderAll10">
											<li class="choice"  rel="">Химические науки</li>
											<li rel="1">Январь</li>
											<li rel="2">Февраль</li>
											<li rel="3">Март</li>
											<li rel="4">Апрель</li>
											<li rel="5">Май</li>
											<li rel="6">Июнь</li>
											<li rel="7">Июль</li>
											<li rel="8">Август</li>
											<li rel="9">Сентябрь</li>
                                            <li rel="10">Октфбрь</li>
											<li rel="11">Ноябрь</li>
											<li rel="12">Декабрь</li>
										</ul>
									</div>
								</div>
								<!--/фильтр выпадашка-->
								<ul class="check sex">
									<li><label for="man"><input type="checkbox" value="" id="man" />Мужчина</label></li>
									<li><label for="female"><input type="checkbox" value="" id="female" />Женщина</label></li>
								</ul>
							</div>
							<div class="block">
								<dl class="education">
									<dt>Квалификация</dt>
									<dd>
										<ul class="check">
											<li><label for="ch9"><input type="checkbox" value="" id="ch9" />Бакалавр</label></li>
											<li><label for="ch8"><input type="checkbox" value="" id="ch8" />Специалист</label></li>
											<li><label for="ch10"><input type="checkbox" value="" id="ch10" />Магистр</label></li>
										</ul>
									</dd>
								</dl>
								<dl class="education">
									<dt>Ученая степень</dt>
									<dd>
										<ul class="check">
											<li><label for="ch2"><input type="checkbox" value="" id="ch2" />Кандидат наук</label></li>
											<li><label for="ch4"><input type="checkbox" value="" id="ch4" />Доктор наук</label></li>
										</ul>
									</dd>
								</dl>
								<dl class="education">
									<dt>Ученое звание</dt>
									<dd>
										<ul class="check">
											<li><label for="ch5"><input type="checkbox" value="" id="ch5" />Доцент</label></li>
											<li><label for="ch6"><input type="checkbox" value="" id="ch6" />Профессор</label></li>
											<li><label for="ch7"><input type="checkbox" value="" id="ch7" />Член-корреспондент</label></li>
											<li><label for="ch11"><input type="checkbox" value="" id="ch11" />Академик</label></li>
										</ul>
									</dd>
								</dl>
							</div>
						</div>
								
						<dl class="tagList">
							<dt>Интересы:</dt>
							<dd>
								<ul>
									<% tagModule.ListWidget(Html); %>
								</ul>
							</dd>
						</dl>
					</div>
					<div class="column">
						<!---->
						<dl>
							<dt>Образование и место работы:</dt>
							<dd>
								<div class="activity">												
									
									<div class="searchWrap">											
										<div class="borderAll10 input">
											<div class="bg">
                                                <label for="fstudy1" class="_autohide">Учебное заведение</label>
                                                <input type="text" id="fstudy1" value="" class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User_Univer/AutoCompleteSearchUniver"/>
                                            </div>											
										</div>											
									</div>												
								</div>
								<div class="activity">												
									
									<div class="searchWrap">											
										<div class="borderAll10 input">
											<div class="bg">
                                                <label for="fstudy2" class="_autohide">Факультет</label>
                                                <input type="text" id="fstudy2" value=""  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User_Univer/AutoCompleteSearchFaculty"/>
                                            </div>											
										</div>											
									</div>												
								</div>
								<div class="activity">
									<div class="searchWrap">											
										<div class="borderAll10 input">
											<div class="bg">
                                                <label for="fstudy3" class="_autohide">Кафедра</label>
                                                <input type="text" id="fstudy3" value=""  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User_Univer/AutoCompleteSearchDepartment"/>
                                            </div>											
										</div>											
									</div>												
								</div>
								<div class="activity">
									<div class="searchWrap">											
										<div class="borderAll10 input">
											<div class="bg">
                                                <label for="fstudy4" class="_autohide">Группа</label>
                                                <input type="text" id="fstudy4" value=""  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User_Univer/AutoCompleteSearchGroup"/>
                                            </div>											
										</div>											
									</div>												
								</div>
								<div class="activity">
									<div class="searchWrap">											
										<div class="borderAll10 input">
											<div class="bg">
                                                <label for="fstudy5" class="_autohide">Место работы</label>
                                                <input type="text" id="fstudy5" value=""  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/User_Job/AutoCompleteSearchJob"/>
                                            </div>											
										</div>											
									</div>												
								</div>
								<div class="activity">
									<div class="borderAll10 input">
                                        <div>
                                            <label for="fprof" class="_autohide">Должность</label>
                                            <input type="text" id="fprof" value="" />
                                        </div>
                                    </div>											
								</div>
								<div class="activity">												
									<div class="filtrSelectBlock year"><!--фильтр выпадашка-->
										<div class="border borderAll10"><!-- при клике добавляем show к ul -->
											<ul class="borderAll10" style="max-height:100px; overflow-y:scroll;">
												<li class="choice" rel="">Год поступления</li>
												<%for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year-80); i--){
                                                    %><li rel="<%:i %>"><%:i %></li><%
                                                } %>
											</ul>
										</div>
									</div>
									<!--/фильтр выпадашка-->
									<!--фильтр выпадашка-->
									<div class="filtrSelectBlock year">
										<div class="border borderAll10"><!-- при клике добавляем show к ul -->
											<ul class="borderAll10" style="max-height:100px; overflow-y:scroll;">
												<li class="choice" rel="">Год окончания</li>
                                                <%for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year-80); i--){
                                                    %><li rel="<%:i %>"><%:i %></li><%
                                                } %>												
											</ul>
										</div>
									</div>
									<!--/фильтр выпадашка-->										
								</div>
							</dd>
						</dl>
						<!--/-->
					</div>
				</div>
			</dd>
		</dl>
		<!--/-->
		<div class="buttonsBlock">
			<span class="ibutton"><%= Html.LC().Command_Save %></span>
			<span class="ibutton"><%= Html.LC().Command_Cancel %></span>
		</div>
</div>
<!--/подборка-->
