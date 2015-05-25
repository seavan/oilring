<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<div class="calendarBlock">
    <div class="close" title="Закрыть">Закрыть</div>
    <div class="_calendarEvent" rev="<%: Model %>"></div>  
    <a href="#" class="_clearSelectDate">Сбросить дату</a>  
</div>

