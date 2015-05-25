<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<LanguageObject>>" %>

<!--добавление языка-->
<div class="popup addLanguageBlock _ajaxFormLoad"> <!-- по клику показываем -->
	<div class="bgBlock">
		
			<dfn>Добавление языка</dfn>
			<div class="wrap iForm">
				<ul class="check">					
                    <%for(var i=0; i<Model.Count(); i = i+3){ %>        
                        <li><label for="ch_<%:Model.ElementAt(i).Id%>"><input type="checkbox" id="ch_<%:Model.ElementAt(i).Id%>" /><span><%:Model.ElementAt(i).Title%></span></label></li>
                    <%} %>
				</ul>
				<ul class="check">					
                    <%for(var i=1; i<Model.Count(); i = i+3){ %>
                        <li><label for="ch_<%:Model.ElementAt(i).Id%>"><input type="checkbox" id="ch_<%:Model.ElementAt(i).Id%>" /><span><%:Model.ElementAt(i).Title%></span></label></li>
                    <%} %>
				</ul>
				<ul class="check">					
                    <%for(var i=2; i<Model.Count(); i = i+3){ %>
                        <li><label for="ch_<%:Model.ElementAt(i).Id%>"><input type="checkbox" id="ch_<%:Model.ElementAt(i).Id%>" /><span><%:Model.ElementAt(i).Title%></span></label></li>     
                    <%} %>
				</ul>
			</div>
			<div class="but">
                <input type="button" value="Добавить выбранные" class="ibutton _selectLanguage _ownAct" />&nbsp;&nbsp;&nbsp;
                <input type="button" value="Отмена" class="ibutton _cancelselectLanguage _ownAct" />
            </div>
		
	</div>
</div>
<!--/добавление языка-->