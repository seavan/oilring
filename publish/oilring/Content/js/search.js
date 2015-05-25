$(document).ready(function () {
    $('.searchReult .searchBlock .searchDoor').click(function () {
        $('.searchReult .searchBlock2.borderAll10').toggle();
        $('.searchReult .filtr._allresult').toggle();
        if ($(this).text().indexOf('Расширенный') > -1) {
            $(this).text('Простой поиск');
        }
        else {
            $(this).text('Расширенный поиск');
        }
    });

    $('.searchBlock2.borderAll10 .filtr li').live('click', function () {
        alert($(this).first().text());
    });

    $('#quickSearchForm').submit(function (ev) {
        var val = $(this).find('input[type=text]').val();
        if (val.length > 2) {
            return true;
        }
        ev.preventDefault();
    });

    $('#singleSearchForm').submit(function (ev) {
        var val = $(this).find('input[type=text]').val();
//        alert(val);
        if (val.length > 2) {
            return true;
        }
        ev.preventDefault();
    });

    $("._searchBox").keydown(function (e) {
        if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
            //alert('aa');
            e.preventDefault();
            $(this).parents('form').submit();
//            $(this).closest('input[type=submit]').click();
        }
    });
});