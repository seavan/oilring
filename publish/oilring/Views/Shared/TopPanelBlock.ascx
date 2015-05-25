<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="topPanel borderTop10">
    <div>
        <%if (Request.IsAuthenticated)
          {%>
        <!---->
        <ul class="filtr">
            <li class="_mainFilterOpener _rubricFilterSelector" data-uri='/ru/User/UseSelectedRubrics'>
                <a href="#">Моя подборка</a></li>
            <!-- при наведении добавляем эти классы тоже class="cur borderAll10" -->
            <li class="_allSelector _rubricFilterSelector" data-uri='/ru/User/UseAllMaterials'><a
                href="#">Все материалы сайта</a></li>
            <li class="_oneFilterOpener" style="display: none"><a href="#">Только один раздел</a></li>
        </ul>
        <!--/-->
        <dfn></dfn>
        <%
  }%>
    </div>
</div>
