
$(function () {

    var $body = $('body');

    $.datepicker.regional['ru'] = {
        closeText: 'Закрыть',
        prevText: '&#x3c; Пред',
        nextText: 'След &#x3e;',
        currentText: 'Сегодня',
        monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
		        'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн',
		        'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
        dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
        dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
        dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        weekHeader: 'Не',
        dateFormat: 'dd.mm.yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['ru']);


    /* Blind hands */
    (function () {

        $('ul').unselectable();


        // li's
        $('ul.filtr, ul._menuMain').each(function () {
            var $ul = $(this);

            $ul.find('li').not('._noSelect').click(function () {
                $(this).addClass('cur borderAll10').siblings('.cur').removeClass('cur').removeClass('borderAll10');
            });
        });


        

    })();


    /* index */

    (function () {

        // taglist
        var $tagList = $('dl.tagList');

        $tagList.find('ul li').live('click', function () { $(this).toggleClass('cur'); });


        // # Seminars
        /*
        // calendar
        var $seminars = $('dl.listInfoBlock');

        var $calendar = $seminars.find('div.calendarBlock');
        var $month = $calendar.find('div.months');

        var $next = $month.find('a.next');
        var $prev = $month.find('a.prev');
        */

        // # Grants

        // # Discussions

    })();



    // # filter : bak
    (function () {

        var filter = new CFilter($('.mainFiltr._bak'));
        document.FILTER = filter;
        var filterU = new UFilter($('.mainFiltr._user'));
        document.FILTERU = filterU;
    })();

    (function () {
        $('ul.alphabet li').live('click', function () {
            $li = $(this);
            if (!$li.hasClass('lang')) {
                $li.siblings().removeClass('cur');
                $li.addClass('cur');
            }
        });
    })();

    // structure
    (function () {
        /* trash */
        var data = [
               { name: '1', child: [{ name: 'Много строк<br>Много строк<br>Много строк', child: [] }, { name: '12 sdf sda f das', child: [{ name: '121 sadf as', child: [] }, { name: '122 fsdafs d', child: []}] }, { name: '13 asdfds', child: []}] }
             , { name: '2', child: [{ name: '21 asdf', child: [] }, { name: '22 sadf', child: [] }, { name: '12 sdf sda f das', child: [{ name: '121 sadf as', child: [] }, { name: '122 fsdafs d', child: [{ name: '121 sadf as', child: [] }, { name: '122 fsdafs d', child: []}]}]}] }
             , { name: '3', child: [{ name: '31 asdf', child: [] }, { name: '32 asdf', child: [] }, { name: '33 sdf asd fas df das', child: []}] }
          ];

        /* trash */

        var $root = $('ul.tree').hide();

        if ($root.length == 0) return;
        var item = document.createElement('li');

        item.innerHTML = '<div class="treenavi">&nbsp;</div><div class="treecontent"></div>';
        item.className = 'treeitem';

        function AddItem(_node, _data) {

            var slot = item.cloneNode(true);

            slot.firstChild.nextSibling.innerHTML = _data.name;
            _node.appendChild(slot);

            if (_data.child != null && _data.child.length > 0) {
                slot.className += ' close';
                slot.innerHTML += '<ul class="treecontainer"></ul>';

                for (var i = 0; i < _data.child.length; i++)
                    AddItem(slot.lastChild, _data.child[i]);

                slot.lastChild.lastChild.className += ' last';
            } else {
                slot.className += ' leaf';
            }
        };

        // build
        for (var i = 0; i < data.length; i++)
            AddItem($root[0], data[i]);


        // animation
        var list = $root[0].getElementsByTagName('li');

        // click navi
        function naviclick(ev) {
            ev = ev || window.event;

            var navi = ev.target || ev.srcElement
            var li = navi.parentNode;
            var container;

            // navi
            $(li).toggleClass('open close');

            // container
            container = $(li.lastChild)
            if (typeof $.browser.msie == 'undefined')
                container.slideToggle(333);
            else
                container.toggle(0);
        };

        // attach
        for (var i = 0; i < list.length; i++) {
            item = list[i];

            if (/\bclose\b|\bopen\b/.test(item.className)) {
                if (typeof item.firstChild.addEventListener != 'undefined') item.firstChild.addEventListener('click', naviclick, false)
                else if (typeof item.firstChild.attachEvent != 'undefined') item.firstChild.attachEvent('on' + 'click', naviclick);
            };
        };

        $root.show();
    })();
});


// возвращает cookie если есть или undefined
function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
	  "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
	))
    return matches ? decodeURIComponent(matches[1]) : undefined
}

// уcтанавливает cookie
function setCookie(name, value, props) {
    props = props || {}
    var exp = props.expires
    if (typeof exp == "number" && exp) {
        var d = new Date()
        d.setTime(d.getTime() + exp * 1000)
        exp = props.expires = d
    }
    if (exp && exp.toUTCString) { props.expires = exp.toUTCString() }

    value = encodeURIComponent(value)
    var updatedCookie = name + "=" + value
    for (var propName in props) {
        updatedCookie += "; " + propName
        var propValue = props[propName]
        if (propValue !== true) { updatedCookie += "=" + propValue }
    }
    document.cookie = updatedCookie

}

// удаляет cookie
function deleteCookie(name) {
    setCookie(name, null, { expires: -1 })
}

function submitenter(myfield, e, _callback) {
    var keycode;
    if (window.event) keycode = window.event.keyCode;
    else if (e) keycode = e.which;
    else return true;

    if (keycode == 13) {
        _callback(e);
        return false;
    }
    else
        return true;
}


(function () {
    var $addDoor = $('.userMaterialsBlock .addDoor');
    $addDoor.live('click', function () {
        $('.createEntryBlock').slideToggle();
    })
})();


function ConvertMonth(month) {
    switch (month) {
        case '1':
        case '01':
            return 'январь';
        case '2':
        case '02':
            return 'февраль';
        case '3':
        case '03':
            return 'март';
        case '4':
        case '04':
            return 'апрель';
        case '5':
        case '05':
            return 'май';
        case '6':
        case '06':
            return 'июнь';
        case '7':
        case '07':
            return 'июль';
        case '8':
        case '08':
            return 'август';
        case '9':
        case '09':
            return 'сентябрь';        
        case '10':
            return 'октябрь';        
        case '11':
            return 'ноябрь';        
        case '12':
            return 'декабрь';
    }
}

function $disabled(_$elList, _stt) {

    for (var i = 0; i < _$elList.length; i++) {
        var $p = _$elList.eq(i);

        if (_stt)
            $p.attr('disabled', 'disabled');
        else
            $p.removeAttr('disabled');
    }
};

jQuery.fn.center = function () {
    var $window = $(window);
    this.css("position", "absolute");
    this.css('margin-left', 0);
    this.css('margin-top', 0);
    this.css("top", (($window.height() - this.outerHeight()) / 2) + $window.scrollTop() + "px");
    this.css("left", (($window.width() - this.outerWidth()) / 2) + $window.scrollLeft() + "px");
    return this;
}

jQuery.fn.myPopup = function (_ok, _cancel) {
    var self = this;
    this.addClass('_popup');
    this.center();
    //this.show();
    this.fadeIn();
    this.find('input[type=text]').first().focus();
    this.find('input[type=text]').unbind('keyup').keyup(function (e) {
        return;
        if (e.keyCode == 13) {
            if (_ok) _ok(self.find('._ok'), self);
            self.find('input[type=text]').val('');
            $(document).hidePopup();
        }
    });

    this.find('._ok').unbind('click').click(function () {
        if (_ok) _ok($(this), self);
        self.find('input[type=text]').val('');
        self.hidePopup();
    });

    this.find('._cancel').unbind('click').click(function () {
        self.hidePopup();
        self.find('input[type=text]').val('');
        if (_cancel) _cancel($(this), self);
    });

    return this;
}

jQuery.fn.hidePopup = function () {
    var $popups = this.andSelf().find('._popup');
    $popups.removeClass('_popup');
    //this.hide();
    $popups.fadeOut();
    return this;
}


