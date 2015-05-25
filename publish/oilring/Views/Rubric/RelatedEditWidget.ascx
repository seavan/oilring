<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<RubricObject>>" %>
<!--по клику раскрываем-->
<div class="note">
    Вы должны выбрать рубрику ВАК первого уровня и рубрика ВАК второго уровня. Перечень
    подрубрик, загружается после выбора рубрики первого уровня.</div>
<div class="wrap">
    <!---->
    <div class="selectRubric">
        <dfn>Выберите рубрики:</dfn>
        <!--фильтр выпадашка-->
        <div class="filtrSelectBlock rubric">
            <div class="border borderAll10">
                <!-- при клике добавляем show к ul -->
                <ul class="borderAll10 _section">
                    
                </ul>
            </div>
        </div>
        <div class="filtrSelectBlock rubric">
            <div class="border borderAll10">
                <!-- при клике добавляем show к ul -->
                <ul class="borderAll10 _subSection">
                    
                </ul>
            </div>
        </div>
        <!--/фильтр выпадашка-->
        <!--Категории-->
        <div class="categoryList borderAll10 _category">
            <ul>
                
            </ul>
            <ul>
                
            </ul>
            <ul>
                
            </ul>
        </div>
        <!--/Категории-->
    </div>
    <!--/-->
    <!---->
    <div class="userAddRubric">
        <dfn>Выбранные рубрики:</dfn>
        <% Html.RenderPartial("RelatedListWidget2", Model); %>
    </div>
    <!--/-->
</div>
