
function autoCompleteObject( _objTitle, _objId, _urlToGet) {


    var isSelected = false;
    var $el = $( '#' + _objTitle );

    $el.autocomplete({
        minLength: 3
        , source: function (request, response) {
            if ($el.parent('.bg').length > 0) {
                $el.parent('.bg').addClass('load');
            }
            $.ajax({

                type: 'POST'
                , dataType: 'json'
                , url: _urlToGet
                , data: { searchString: request.term }

                , success: function (data) {

                    if ($el.parent('.bg').length > 0) {
                        $el.parent('.bg').removeClass('load');
                    }

                    //Создаем массив для объектов ответа
                    var suggestions = [];

                    //Новый запрос, обнуляем, что был выбор
                    isSelected = false;

                    //Обрабатываем ответ 
                    $.each(data, function (i, val) {
                        var span = {
                            'id': val.Id,
                            'title': val.Title,
                            'additional': val.Additional,
                            'image': val.Icon
                        };
                        if (span.additional == null) span.additional = "";
                        if (span.image == null) span.image = "";
                        suggestions.push(span);
                    });

                    //Передаем массив обратному вызову
                    response(suggestions);
                }
            });
        }
        , search: function () {
            //Новый запрос, обнуляем, что был выбор
            //console.log('search');
            isSelected = false;

        }
        , select: function (event, ui) {
            isSelected = true;
            this.value = ui.item.title;

            FillFildForId($(this), ui.item.id, 'user');

            return false;
        }

        , focus: function (event, ui) {
            this.value = ui.item.title;
            FillFildForId($(this), ui.item.id, 'user');

            return false;
        }
        , change: function () {

            if (!isSelected || $("#" + _objTitle).val() == "") {
                if (_objId == null || _objId == "") {
                    ClearFildForId($("#" + _objTitle));
                }
                else {
                    $("#" + _objId).val("");
                }

            }
        }

    }).data('autocomplete')._renderItem = function (ul, item) {
        ul.addClass('list');
        var img = "";
        if (item.image != "") {
            img = '<img src="' + IMAGE_CONTENT_URI  + item.image + '" alt=""/>';
        }
        return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a>" + img + item.title + "<small>" + item.additional + "</small></a>")
				.appendTo(ul);
    };
}

function FillFildForId(_$input, val, rev) {
    if (_$input.next('input[type=hidden]').length == 0) {
        $inputId = $('<input type="hidden" />');
        _$input.after($inputId);
    };
    var $hidden = _$input.next('input[type=hidden]');
    var newId = _$input.attr('id') + "Id";
    $hidden.val(val).attr('rev', rev).attr('id', newId).attr('name', newId);
}
function ClearFildForId(_$input) {
    if (_$input.next('input[type=hidden]').length > 0) {
        _$input.next('input[type=hidden]').val('');
    }    
}


function split(val) {
    return val.split(/,\s*/);
}
function extractLast(term) {
    return split(term).pop();
}
function autoCompleteKeyWords(_objTitle, _urlToGet) {

    var $el = $('#' + _objTitle);

    $el.autocomplete({
        source: function (request, response) {
            $.ajax({
                url: _urlToGet,
                data: {
                    newTag: extractLast(request.term)
                },
                dataType: "json",
                type: "POST",
                success: function (data) {
                    response(data);
                }
            });
        },
        search: function () {
            // custom minLength
            var term = extractLast(this.value);
            if (term.length < 2) {
                return false;
            }
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var terms = split(this.value);
            // remove the current input
            terms.pop();
            // add the selected item
            terms.push(ui.item.value);
            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join(", ");
            return false;
        }
    });
}