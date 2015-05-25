
function createCkEditor() {
    $('._editor textarea._visual').ckeditor();
}


var TELERIK_MODAL_STACK = Array();

function closeTelerikTopMost() {
    var $modalWindow = $('.t-window');
    $modalWindow.each(function () {
        pushTelerikStack($(this));
    });
}

function popTelerikStackAll() {
    while (TELERIK_MODAL_STACK.length) {
        popTelerikStack();
    }
}

function popTelerikStack() {
    if (TELERIK_MODAL_STACK.length > 0) {
        var w = TELERIK_MODAL_STACK.pop();
        w.data('tWindow').open();
        w.data('tWindow').center();
    }
}

function pushTelerikStack($_tWindow) {

    $_tWindow.data('tWindow').close();
    TELERIK_MODAL_STACK.push($_tWindow);
}

function updateGrids() {
    createFieldButtons();
    createSubmitButtons();
    createLinkButtons();
    bindEvents();
    updateDisabled();
    createCkEditor();
}

function updateDisabled() {
    var $inp = $('._disabled input');
    $inp.attr('readonly', 'readonly');

    $inp = $inp.filter('*[name!="id"]');
    $inp.attr('id', null);
    $inp.attr('name', null);
}

function bindEvents() {
    
}

function toggleForeignField(obj) {
    var $obj = $(obj);

    var $cont = $obj.parent().parent().find('._foreign');
    var $key = $obj.parent().parent().find('._thisKey');
    var $display = $obj.parent().parent().find('._thisDisplay');
    var controller = $obj.parent().parent().find('._controller').text();

    $.ajax(
    {
        url: controller,
        type: 'POST',
        success: function (_data) {
            // close window if any
            closeTelerikTopMost();

            $cont.html('<div class="_modal"></div>');
            $modal = $cont.find('._modal');
            $modal.html(_data);
            $modal.dialog(
            {
                width: 1000,
                autoOpen: false,
                position: ['center', 10],
                close: function () {
                    $('._modal').remove();
                }
            });
            $modal.get(0).setValue =
                function (_val, _display) {
                    $key.val(_val);
                    $display.text(_display);
                };
            $modal.dialog('open');

        }
    });

}

function bindRow(_obj) {
    var $row = $(_obj.row);
    var $dialogCont = $row.parents('._modal').eq(0);
    if ($dialogCont.length > 0) {
        $row.click(
            function () {
                var i = $row.find('._gridId').text();
                var d = $row.find('._gridDisplay').text();

                $dialogCont.dialog('close');
                $dialogCont.get(0).setValue(i, d);
                popTelerikStackAll();
            }
        )
    }
}

function createFieldButtons() {
    var $field = $('._field ._expander');
    $field.each(
        function(index, obj) {
            $(obj).button().click(
                function () {
                    var $cont = $(obj).parent().parent().find('._foreign');

                    toggleForeignField(obj);
                }
            );
            });

    var $apply = $('._field ._apply');
    $apply.each(
        function (index, obj) {
            $(obj).button();
            $(obj).hide();
        });
    
}

function createSubmitButtons() {
    $('input:submit').button();
}

function createLinkButtons() {
    var $links = $('a._link');
    $links.button()

}

function gridEdit() {
    var win = $('.t-window').data('tWindow');
    win.center();
    updateGrids();
}

$(document).ready(

function () {
    updateGrids();
    
}
);