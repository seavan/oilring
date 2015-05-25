var firstSelect = true;
var isSelectDay = false;
var isSelectMonth = true;
var daysToEnable = [];

$(function () {

    function enableSpecificDates(date) {
        var month = date.getMonth();
        var day = date.getDate();
        var year = date.getFullYear();
        for (i = 0; i < daysToEnable.length; i++) {
            if ($.inArray((month + 1) + '.' + day + '.' + year, daysToEnable) != -1) {
                return [true];
            }
        }
        return [false];
    }

    $("._calendarEvent").datepicker({
        beforeShowDay: enableSpecificDates,
        dateFormat: 'mm.dd.yy',
        onSelect: function (dateText, inst) {
            //alert(dateText);
            //console.log("День выбран: " + dateText);
            if (!firstSelect) {

                var id = $(this).closest('._calendarEvent').attr('rev');
                var $mod = $('.' + id);
                var p = MODULEPARAMS[id];

                dateText = dateText.replace(new RegExp("\\.", 'g'), " ");
                var date = new Date(dateText);

                var date2 = new Date(date.getFullYear(), date.getMonth(), date.getDate(), 4, 0, 0);
                var curMilSec = date2.getTime(); //Math.round(date.getTime());

                p.CurrentDate = curMilSec;

                isSelectDay = true;
                isSelectMonth = false;
                updateModule($mod);
            }
            firstSelect = false;
        },
        onChangeMonthYear: function (year, month, inst) {

            //console.log("Месяц выбран: " + month); /*$("._calendarEvent").datepicker("setDate", null);*/
            var $parent = $(this).closest('._calendarEvent');
            if ($parent.hasClass('_forMain')) {
                var id = $parent.attr('rev');
                var $mod = $('.' + id);
                var p = MODULEPARAMS[id];
                var date = new Date(year, month - 1, 1, 4, 0, 0);
                var curMilSec = date.getTime();

                p.CurrentDate = 0;
                p.CurrentDateForMonth = curMilSec;

                isSelectDay = false;
                isSelectMonth = true;
                updateModule($mod);
            }
        }

    });

    // calendars
    $('._withCalendarBlock .calendarDoor').click(function () {
        // Календарь
        // Скрыть календарь
        var $btn = $(this);
        var $text = (($btn.find('span').length > 0) ? $btn.find('span') : $btn);
        var $calendar = $btn.closest('._withCalendarBlock').find('div.calendarBlock');


        if ($calendar.is(':visible')) {
            $calendar.slideUp(333);
            $text.text('Календарь');
        } else {
            $calendar.slideDown(333);
            $text.text('Скрыть календарь');
        };

    });

    var $closeButton = $('.calendarBlockPopup .calendarBlock .close');
    function CloseCalendar($but) {
        //var $but = $(this);
        var $text = $but.parent().prev().find('span');
        $but.parent().slideUp(333);
        $text.text('Календарь');
    }
    $closeButton.live('click', function () {
        CloseCalendar($(this));
    });

    $('._withCalendarBlock ._clearSelectDate').live('click', function () {
        //alert(1);
        var id = $(this).prev('._calendarEvent').attr('rev');
        var $mod = $('.' + id);
        var p = MODULEPARAMS[id];
        p.CurrentDate = 0;
        p.CurrentDateForMonth = 0;

        isSelectDay = false;
        isSelectMonth = true;
        updateModule($mod);
        CloseCalendar($(this));
    });

});
function UpdateCalendarDate() {
    if (isSelectMonth) {
        daysToEnable = SEMINARDATE;
    }
    if (!isSelectDay) {
        $("._calendarEvent").datepicker("refresh");
        if (isSelectMonth) {
            $("._calendarEvent").find('a').removeClass('ui-state-active');
        }
    }
    isSelectDay = false;
    isSelectMonth = true;
}
