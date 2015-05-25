function UFilter($base) {

    //declaration
    var self = this;    
    this.$mainFilter = $base;

    this.$buttons = self.$mainFilter.find('div.buttonsBlock');
    this.$btnSave = self.$buttons.find('span.ibutton:first');
    this.$btnCancel = self.$buttons.find('span.ibutton:last');

    this.$mainFilterOpener = $('._userFilterOpener');

    this.$helpDescription = $('.topPanel dfn');

    this.$dropdownList = self.$mainFilter.find('.filtrSelectBlock ul li');

    this.$rangeSelector = self.$mainFilter.find('div.scrollWrap');
    this.$startRange = self.$mainFilter.find('input#startAgeRange');
    this.$endRange = self.$mainFilter.find('input#endAgeRange');

    this.open = function () {
        self.$mainFilter.slideDown();
    }

    this.close = function () {
        self.$mainFilter.slideUp();
    }

    this.CLOSING_TIMER = null;


    self.$helpDescription.hide();

    self.$btnCancel.click(function () {
        self.close();
    });

    self.$mainFilterOpener.hover(function () {
        //self.$helpDescription.text('Щелкните по пункту "Моя подборка", чтобы применить фильтр');
        
        self.open();
    });

    self.$mainFilterOpener.click(function () {
        self.open();

//        for (var i in MODULEPARAMS) {
//            var p = MODULEPARAMS[i];
//            if (p['UserFilter'] > 0) {
//                var $mod = $('.' + p['ModuleId']);
//                p['UserRubricFilter'] = self.getSelectedRubricsSemicolon();
//                updateModule($mod);

//            }
//        }
    });

    self.$dropdownList.click(function () {
        $(this).addClass('choice').siblings().removeClass('choice');

        var $ul = $(this).parent();
        if ($ul.hasClass('show')) {
            $ul.removeClass('show');
        } else {
            $ul.addClass('show');
        }
    });


    self.$rangeSelector.slider({
        range: true,
        min: 18,
        max: 100,
        values: [25, 55],
        slide: function (event, ui) {
            self.$startRange.val(ui.values[0]);
            self.$endRange.val(ui.values[1]);

            self.$rangeSelector.find(".ui-slider-handle:first span").html(ui.values[0]);
            self.$rangeSelector.find(".ui-slider-handle:last span").html(ui.values[1]);            
        }
    });
    self.$startRange.val(self.$rangeSelector.slider("values", 0));
    self.$endRange.val(self.$rangeSelector.slider("values", 1));

    self.$rangeSelector.find(".ui-slider-handle:first").html("<span class='_rangeViewData _start'>" + self.$rangeSelector.slider("values", 0) + "</span>");
    self.$rangeSelector.find(".ui-slider-handle:last").html("<span class='_rangeViewData _end'>" + self.$rangeSelector.slider("values", 1) + "</span>");



    self.$mainFilter.add(self.$mainFilterOpener).hover(
    function () {
        window.clearTimeout(self.CLOSING_TIMER);
        self.CLOSING_TIMER = null;
    },
    function () {
        if (self.CLOSING_TIMER) window.clearTimeout(self.CLOSING_TIMER);
        self.CLOSING_TIMER = window.setTimeout(self.close, 600);
    });
    
}