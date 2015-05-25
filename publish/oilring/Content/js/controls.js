var MODULEPARAMS = new Object();
function universalOpener($tg, _openDoor, _openBlock, _otherDoor, _otherBlock) {

    $tg.find(_openDoor).unbind('click').click(

        function () {
            var $this = $(this);
            var $parent = $this.parents('.bgWrap, #middleWrap').first();

            var $relRubric = $parent.find(_openBlock);
            var $otherDoors = $parent.find(_otherDoor);
            var $otherSliders = $parent.find(_otherBlock);
            $otherDoors.removeClass('show');
            $otherSliders.slideUp();
            if ($this.hasClass('show')) {
                $this.removeClass('show');
                $relRubric.slideUp();
            }
            else {
                $this.addClass('show');

                var $moduleCheck = $relRubric.find('._module').add($relRubric.filter('._module'));

                if ($moduleCheck.hasClass('_delayed')) {
                    $moduleCheck.removeClass('_delayed');
                    updateModule($moduleCheck, false, function () { $relRubric.slideDown(); });
                }
                else {
                    $relRubric.slideDown();
                }
            }

        }
        )
}

function initForm($_anchor) {
    var $form = $_anchor.find('form');
    if ($form.length > 0) {
        
        var $submits = $_anchor.find('input[type=submit],input[type=button]').not('._ownAct');

        $submits.unbind('click');
        $submits.click(function (event) {
            event.preventDefault();
            // update ckeditor
            if (CKEDITOR && CKEDITOR.instances) {
                for (var k in CKEDITOR.instances) {
                    CKEDITOR.instances[k].updateElement();
                }
            }

            var self = this;
            var $this = $(self);
            var data = new Object();
            var $parentForm = $this.parents('form:first');
            //            $parentForm.addClass('_preloader');

            var command = $this.attr('rel');
            var uri = $parentForm.attr('action');
            var $controls = $parentForm.find('input[type=text], input[type=password], input[type=hidden], input[type=checkbox], input[type=radio]:checked, textarea');
            var $relations = $parentForm.find('._relation');

            var i = 0;
            for (i = 0; i < $controls.length; ++i) {
                var $i = $controls.eq(i);

                var name = $i.attr('name');

                if (name) {
                    var val = $i.val();

                    if (($i.attr('type') == 'hidden') && data[name] && data[name].length) {
                        continue;
                    }

                    if ($i.hasClass('_localField')) {
                        if ($i.hasClass('_dateField')) {
                            var $parent = $i.closest('.' + $i.attr('rel'));
                            var hour = $parent.find('input._localHour').val();
                            var min = $parent.find('input._localMinute').val();
                            if (val.length > 0 && hour.length > 0 && min.length > 0) {
                                if (hour.length == 1) hour = "0" + hour;
                                if (min.length == 1) min = "0" + min;
                                val = val + ' ' + hour + ':' + min + ":00.000";
                                data[name] = val;
                            }
                        }
                    }
                    else {
                        if (/*$i.attr('type') == 'radio' || */$i.attr('type') == 'checkbox') {
                            if ($i.attr('checked')) {
                                data[name] = 'True';
                            }
                            else {
                                data[name] = 'False';
                            }
                        }
                        else {
                            data[name] = val;
                        }
                    }
                }
            }

            for (i = 0; i < $relations.length; ++i) {
                var $i = $relations.eq(i);

                var rel = $i.attr('rel');
                var createType = $i.attr('rev');

                var relItems = new Object();
                var $rels = $i.find('._id');

                var relInfo = {}
                relInfo.Relation = rel;
                relInfo.ObjectType = createType;

                var rels = []
                for (var j = 0; j < $rels.length; ++j) {
                    var ri = $rels.eq(j).attr('rel');
                    var rv = $rels.eq(j).attr('rev');
                    var obj = { ObjectType: rv };
                    if (ri) obj.Id = ri;
                    rels.push(obj);
                    //                    rels.push(ri + ':' + rv);
                }

                relInfo.Relations = rels;

                var crs = [];
                var $creation = $i.find('._create');

                for (var j = 0; j < $creation.length; ++j) {
                    var $c = $creation.eq(j);
                    var ri = $c.attr('rel');
                    var rv = $c.attr('rev');
                    var obj = { ObjectType: rv };
                    if (ri) obj.Id = ri;
                    var $params = $c.find('._param');
                    for (var k = 0; k < $params.length; ++k) {
                        var $p = $params.eq(k);

                        if ($p.hasClass('_frominput')) {

                            var $inp = $c.find('input._for' + $p.attr('rel'));
                            if ($inp.length > 0) {
                                obj[$p.attr('rel')] = $inp.val();
                            }
                            else {
                                obj[$p.attr('rel')] = $p.attr('rev');
                            }
                        }
                        else if ($p.hasClass('_fromcheck')) {
                            var checked = (($c.find('input._for' + $p.attr('rel') + '[type=checkbox]:checked').length > 0) ? 'True' : 'False');
                            obj[$p.attr('rel')] = checked;
                        }
                        else {
                            obj[$p.attr('rel')] = $p.attr('rev');
                        }
                    }

                    //                    crs[ri] = rv;
                    crs.push(obj);
                    //crs.push(ri + ':' + rv);
                }

                relInfo.Creations = crs;

                data[rel] = JSON.stringify(relInfo);
            }


            data['_command'] = command;
            $parentForm.find('input[name=_command]').val(command);

            if ($this.hasClass('_blank')) {
                //$parentForm.attr('target', '_blank');
            }

            if ($this.hasClass('_clean')) {
                $controls.not('*[type=hidden]').val('');
            }

            var saver = function (_callbackSuccess, _callbackFail) {
                $submits.addClass('hide');
                $.ajax({
                    url: uri,
                    traditional: true,
                    type: 'POST',
                    data: data,
                    complete: function (data) {
                        $submits.removeClass('hide');
                        var $this = $(self);
                        var $parentForm = $this.parents('form:first');
                        $parentForm.removeClass('_preloader');
                        $parentForm.removeClass('_preloader');
                        var $affector = $parentForm.find('._affect');
                        $affector.each(function () {
                            var $this = $(this);
                            var rel = $this.attr('rel');
                            var $reflector = $('._react[rel=' + rel + ']');
                            var $module = $reflector.parents('._module:first');
                            updateModule($module);
                        });

                        $('._validationError').html('');
                        if ( (data.responseText != "success") && (data.responseText != "\"success\"") ) {
                            var obj = $.parseJSON(data.responseText);
                            for (var prop in obj) {
                                if (obj.hasOwnProperty(prop)) {
                                    var messages = obj[prop];
                                    if (messages && messages.length) {
                                        var $targetValidation = $('._validation._validationError[rel=' + prop + ']');
                                        $targetValidation.html('');
                                        for (var i = 0; i < messages.length; ++i) {
                                            $targetValidation.append("<div>" + messages[i] + "</div>");
                                        }

                                        $targetValidation.parents('dd').first().slideDown();
                                    }
                                }
                            }
                        } else {
                            if (_callbackSuccess) _callbackSuccess();
                            $(document).hidePopup();
                        }
                    }
                });
            }

            if ($this.hasClass('_ajax')) {
                saver();
            }
            else {
                if ($this.hasClass('_presave')) {
                    data['_command'] = 'draft';
                    saver(
                        function () {
                            $parentForm.submit();
                        }
                    );
                } else {
                    $parentForm.submit();
                }
            }

            return false;
        });



        (function () {
            $headerBlock = $form.find('.addMaterialsBlock dl.iForm dt span');

            $headerBlock.live('click', function () {
                var $dt = $(this).parent();
                var stt = $dt.next().is(':visible');


                $dt.siblings().not('.but.show').filter('dd:visible').slideUp();

                if (!stt)
                    $dt.next().slideDown();
            });
        })();

        (function () {
            $form.find('.addMaterialsBlock li .delete, .profileBlockEdit li div.delete, .profileBlockEdit .infoList span.delete ').live('click', function () {

                $del = $(this);

                if ($del.hasClass('_cycle')) {

                    var $addCycleBlock = $del.closest('._editList').prev();
                    $addCycleBlock.slideDown();
                    var $hiddens = $del.parent().find('input[type=hidden]');
                    $hiddens.each(function () {
                        var $hidden = $(this);
                        $hidden.val($hidden.attr('rel'));
                        $hidden.appendTo($addCycleBlock);
                    });
                }

                //Только для докладчиков: удалять доклад когда нет докладчиков
                if ($del.closest('.userAddReport').length > 0) {
                    var $block = $del.closest('div.block');
                    $del.parent().remove();
                    var $lists = $block.find('ul._editList');
                    var beUser = false;
                    for (var i = 0; i < $lists.length; i++) {
                        if ($lists[i].children.length > 0) {
                            beUser = true;
                        }
                    }
                    if (!beUser) $block.remove();
                }
                else {
                    $del.parent().remove();
                }
            });
            $form.find('.addMaterialsBlock .nameReport .delete').live('click', function () {
                $(this).closest('.nameReport').parent().remove();
            });
        })();

        (function () {
            $form.find('input[type=text], input[type=password], input[type=hidden], textarea').keydown(function (e) {
                var keyCode = e.keyCode || e.which;
                if (keyCode == 13) {
                    return false;
                }
            });
        })();

        (function () {

            $('input._autocompletename').keydown(function (e) {
                var keyCode = e.keyCode || e.which;
                if (keyCode == 13) {
                    $(this).closest('div.searchWrap').next('.add').click();
                    return false;
                }
            });

            $addNewElement = $form.find('.addMaterialsBlock div.add, .profileBlockEdit div.add');
            $addNewElement.live('click', function () {
                var $but = $(this);
                var $input = $but.prev('.searchWrap').find('._autocompletename');


                if ($input.val() != "") {
                    var $inputFild = $input.next('input[type=hidden]');

                    // check if exists
                    var $mod = $but.closest('._module');
                    if ($mod.find('*[rel=' + $inputFild.val() + '][rev=\'' + $inputFild.attr('rev') + '\']').length > 0) {
                        return;
                    }

                    //if ($inputFild.length > 0 && $inputFild.val() != "") {

                    $but.parent().addClass('_preloader');
                    var cfg = {};
                    var url = "";
                    if ($inputFild.length > 0) {
                        cfg['searchId'] = $inputFild.val();
                        url = $but.attr('rel');
                    }
                    else {
                        cfg['searchName'] = $input.val();
                        url = $but.attr('rev');
                    }

                    $.ajax({
                        traditional: true,
                        type: 'POST',
                        url: url,
                        data: cfg,
                        complete: function () {
                            $but.parent().removeClass('_preloader');
                        },
                        success: function (data) {
                            var $target;
                            var $targetsList = $but.closest('._module').find('ul._editList').not('.userAddReport ul._editList');
                            if ($targetsList.length > 0) {
                                $target = $targetsList[0];
                                for (var i = 1; i < $targetsList.length; i++) {
                                    if ($target.children.length > $targetsList[i].children.length) {
                                        $target = $targetsList[i];
                                    }
                                }

                                try {
                                    if (data != "" && ($(data).hasClass('_id') || $(data).hasClass('_ajaxLoadItem'))) {
                                        $(data).appendTo($target);
                                        if ($but.hasClass('_cycle')) {
                                            $but.parent().hide();

                                            var $hide1 = $but.next();
                                            if ($hide1.length > 0) {
                                                var $hide2 = $hide1.next();
                                                $hide1.remove();
                                                $hide2.remove();
                                            }
                                        }

                                    } else {
                                        alert('Не найдено в базе.');
                                    }
                                }
                                catch (e) {
                                    $target.html(data);
                                }
                                $input.val('');
                                $input.focus();
                                $input.blur();
                                if ($inputFild.length > 0) $inputFild.val('');
                            }
                        }
                    });
                } else {
                    alert('Введите текст.');
                }

            });
        })();

        (function () {
            var $ff = $form.find('._nowTime');
            $ff.click(function () {
                var $this = $(this);
                var $aff = $this.parents('.dateInput').first().find('._forEndYear').parents('.input').first();

                if ($this.is(':checked')) {
                    $aff.hide();
                    $aff.val(null);
                } else {
                    $aff.show();
                }
            });
        })();

        //OuterLinks
        (function () {
            $form.find('.addLinks ._addOuterLink').live('click', function () {
                $but = $(this);
                $addBlock = $but.closest('.addLinks');

                $inputAddres = $addBlock.find('input#faddresOuterLink');
                $inputText = $addBlock.find('input#fnameOuterLink');

                if ($inputAddres.val().length > 0) {
                    var prefix = (($inputAddres.val().indexOf('http://') > -1) ? "" : "http://");
                    $linkBlock = $addBlock.prev();
                    var text = (($inputText.val().length > 0) ? $inputText.val() : prefix + $inputAddres.val());
                    var $item = $('<li></li>').addClass('_id _create').attr('rel', '0').attr('rev', 'outerlink');
                    $item.html('<a href="' + prefix + $inputAddres.val() + '" target="_blank">' + text + '</a><span class="delete" title="Удалить">Удалить</span>');
                    $linkBlock.append($item);
                    SetCreationParam($item, 'Link', $inputAddres.val());
                    SetCreationParam($item, 'Text', $inputText.val());
                    $inputAddres.val('');
                    $inputText.val('');
                }
            });

            $form.find('.addLinks #faddresOuterLink').keydown(function (e) {
                var keyCode = e.keyCode || e.which;
                if (keyCode == 13) {
                    $(this).closest('div.addLinks').find('._addOuterLink').click();
                    return false;
                }
            });

        })();

        //Patents
        (function () {
            $form.find('.addPatentBlock ._addNewPatent').live('click', function () {
                $but = $(this);
                $addBlock = $but.closest('.addPatentBlock');

                $inputName = $addBlock.find('input#fnamePatent');
                $inputNumber = $addBlock.find('input#fnumberPatent');

                if (($inputName.val().length > 0) && ($inputNumber.val().length > 0)) {

                    var $target;
                    var $targetsList = $but.closest('._module').find('ul._editList');
                    if ($targetsList.length > 0) {
                        $target = $targetsList[0];
                        for (var i = 1; i < $targetsList.length; i++) {
                            if ($target.children.length > $targetsList[i].children.length) {
                                $target = $targetsList[i];
                            }
                        }

                        var $item = $('<li></li>').addClass('_id _create').attr('rel', '0').attr('rev', 'patent');
                        $item.html('<div class="delete" title="Удалить">Удалить</div>' + $inputName.val() + ', ' + $inputNumber.val());

                        $item.appendTo($target);

                        SetCreationParam($item, 'Title', $inputName.val());
                        SetCreationParam($item, 'Number', $inputNumber.val());
                        $inputName.val('');
                        $inputNumber.val('');
                    }
                }

            });
            $form.find('.addPatentBlock input#fnamePatent').keydown(function (e) {
                var keyCode = e.keyCode || e.which;
                if (keyCode == 13) {
                    $(this).closest('div.addPatentBlock').find('._addNewPatent').click();
                    return false;
                }
            });
        })();
        //Reports
        (function () {
            $form.find('._addReports ._addNewReport').live('click', function () {
                $but = $(this);
                $addBlock = $but.parent().find('.addReport');

                $inputName = $addBlock.find('input#fnameReport');

                $reporters = $addBlock.next('.userAddPeople').find('ul._editList');

                if ($reporters.find('li').length <= 0) return false;

                if (($inputName.val().length > 0)) {
                    $target = $but.parent().find('.userAddReport');

                    var $dateStart = $addBlock.find('input#hiddenStartReportDate');
                    var $dateEnd = $addBlock.find('input#hiddenEndReportDate');
                    var $hourStart = $addBlock.find('input#_startReportHour');
                    var $hourEnd = $addBlock.find('input#_endReportHour');
                    var $minStart = $addBlock.find('input#_startReportMin');
                    var $minEnd = $addBlock.find('input#_endReportMin');

                    if ($dateStart.val().length > 0 && $dateEnd.val().length > 0 && $hourStart.val().length > 0 && $hourEnd.val().length > 0 && $minStart.val().length > 0 && $minEnd.val().length > 0) {

                        var showDate = "";
                        if ($dateStart.val() == $dateEnd.val()) {
                            showDate = $dateStart.val() + ', ' + $hourStart.val() + ':' + $minStart.val() + '—' + $hourEnd.val() + ':' + $minEnd.val();
                        }
                        else {
                            showDate = $dateStart.val() + ', ' + $hourStart.val() + ':' + $minStart.val() + '—' + $dateEnd.val() + ', ' + $hourEnd.val() + ':' + $minEnd.val();
                        }

                        var $item = $('<div></div>').addClass('_id _create block').attr('rel', '0').attr('rev', 'report');
                        var $innerName = $('<div></div>').addClass('nameReport');
                        $innerName.html($inputName.val() + '<span>(' + showDate + ')</span>&nbsp;<span class="delete" title="Удалить">Удалить</span>')
                        var $innerUser = $('<div></div>').addClass('userAddPeople');

                        $innerName.appendTo($item);

                        $reporters.each(function () {
                            var $list = $(this).clone();
                            $list.appendTo($innerUser);
                        });

                        $innerUser.appendTo($item);
                        $item.appendTo($target);

                        var stDate = $dateStart.val() + ' ' + $hourStart.val() + ':' + $minStart.val() + ':00';
                        var enDate = $dateEnd.val() + ' ' + $hourEnd.val() + ':' + $minEnd.val() + ':00';

                        SetCreationParam($item, 'Title', $inputName.val());
                        SetCreationParam($item, 'StartDate', stDate);
                        SetCreationParam($item, 'EndDate', enDate);

                        $inputName.val('');
                        $reporters.empty();

                        $dateStart.val('');
                        $dateEnd.val('');
                        $hourStart.val('');
                        $hourStart.blur();
                        $hourEnd.val('');
                        $hourEnd.blur();
                        $minStart.val('');
                        $minEnd.val('');
                        $minStart.blur();
                        $minEnd.blur();

                        $addBlock.find('.dateDoor._datepicker span').text('Выбрать дату');
                    }
                }

            });
        })();
        //Publications
        (function () {
            var $inputPDate = $form.find('.addEditionBlock input#fDatePublic');
            var re = new RegExp("(0[1-9]{1}|1[012]{1})(\\.{1})((19|20){1}\\d\\d)");

            $inputPDate.keydown(function (e) {
                var keyCode = e.keyCode || e.which;
                //alert(keyCode);
                if ((keyCode > 57 || keyCode < 48) && keyCode != 8 && keyCode != 46 && keyCode != 78 && keyCode != 190 && keyCode != 39 && keyCode != 37) {
                    return false;
                }
                //$form.find('.addEditionBlock input#fnumberPublic').val($(this).val() + ' ' + re.test($(this).val()));

            });

            $inputPDate.live('blur', function () {
                if (!re.test($(this).val())) {
                    $(this).focus();
                    return false;
                }
            });


            $form.find('.addEditionBlock ._addNewPublication').live('click', function () {
                $but = $(this);
                $addBlock = $but.parent().parent();

                $inputName = $addBlock.find('input#fnameEditionPublic');

                if (($inputName.val().length > 0)) {
                    $inputFildID = $inputName.next('input[type=hidden]');

                    $inputType = $addBlock.find('input#ftypePublic');
                    $inputISBN = $addBlock.find('input#fISBNPublic');
                    $inputISSN = $addBlock.find('input#fISSNPublic');

                    $inputDate = $addBlock.find('input#fDatePublic');
                    $inputNumber = $addBlock.find('input#fnumberPublic');

                    $inputLangCode = $addBlock.find('input#fserverLangCode');

                    var $target;
                    var $targetsList = $addBlock.prev('.userAddEdition').find('ul._editList');

                    if ($targetsList.length > 0) {
                        $target = $targetsList[0];
                        for (var i = 1; i < $targetsList.length; i++) {
                            if ($target.children.length > $targetsList[i].children.length) {
                                $target = $targetsList[i];
                            }
                        }

                        var $item = $('<li></li>').addClass('_id _create').attr('rel', '0').attr('rev', 'publicationlink');

                        var date = "";
                        if (($inputDate.val().length == 7) && ($inputDate.val().indexOf('.') == 2)) {
                            var mass = $inputDate.val().split('.');
                            date = ", " + ConvertMonth(mass[0]) + " `";
                            date = date + mass[1].substr(2);
                        }

                        var text = $inputName.val() + date;
                        var id = "";
                        if ($inputFildID.length > 0) {
                            if (($inputFildID.val().length > 0) && (parseInt($inputFildID.val()) > 0)) {
                                id = $inputFildID.val();
                                text = '<a href="/' + $inputLangCode.val() + '/Journal/Single/' + id + '">' + $inputName.val() + '</a>' + date;
                            }
                        }

                        $item.html('<div class="delete" title="Удалить">Удалить</div>' + text);

                        var $span = $('<span></span>');
                        var ISBN = (($inputISBN.val().length > 0) ? "ISBN " + $inputISBN.val() : "");
                        var ISSN = (($inputISSN.val().length > 0) ? "ISSN " + $inputISSN.val() : "");
                        var br = ((ISBN.length > 0 && ISSN.length > 0) ? "<br/>" : "");
                        $span.html(ISBN + br + ISSN);

                        $span.appendTo($item);
                        $item.appendTo($target);

                        SetCreationParam($item, 'PublicationTitle', $inputName.val());
                        SetCreationParam($item, 'ISBN', $inputISBN.val());
                        SetCreationParam($item, 'ISSN', $inputISSN.val());
                        SetCreationParam($item, 'Lang', $inputLangCode.val());
                        SetCreationParam($item, 'TypePublication', $inputType.val());
                        SetCreationParam($item, 'NumberEdition', $inputNumber.val());
                        SetCreationParam($item, 'DatePublication', '01.' + $inputDate.val());
                        SetCreationParam($item, 'REF_Journal_Id', id);

                        $inputName.val('').blur();
                        $inputISBN.val('').blur();
                        $inputISSN.val('').blur();
                        $inputType.val('').blur();
                        $inputNumber.val('').blur();
                        $inputDate.val('').blur();
                        if ($inputFildID.length > 0) {
                            $inputFildID.val('');
                        }
                    }
                }

            });
        })();
        //Uploader files
        (function () {

            $uploadField = $form.find('._uploadingBlock input#ffileUploadField[type=file]');

            function hdrFileUpload(_data) {
                $target = $form.find('._uploadingBlock ul.download');

                $form.find('._uploadingBlock input#ffileUploadField[type=file]').parent().removeClass('_preloader');
                var $it = $form.find('._uploadingBlock');


                $temp = $('<div></div>');

                if ($it.hasClass('_avatar')) {
                    $it.append(_data);
                    window.location.reload();
                    return;
                }

                try {
                    if (_data != "") {
                        $temp.append($(_data))
                        var $li = $temp.find('li._id');
                        if ($li.length > 0) {
                            $li.appendTo($target);
                        }
                        else {
                            alert('Ошибка загрузки.');
                        }
                    }
                }
                catch (e) {
                    $target.html(_data);
                }
            }

            var convertTimeout = null;

            function hdrFileUpdate(_data, _id) {
                var $elem = $('._converterCaption');
                if (_data.responseText == "queue") {
                    $elem.text("В очереди...");

                }
                else if (_data.responseText == "converting") {
                    $elem.text("Конвертация...");

                }
                else if (_data.responseText == "converted") {
                    $elem.text("Сконвертировано");
                    window.clearInterval(convertTimeout);
                    convertTimeout = null;
                    var url = '/ru/FileAttachment/GetFileContents?id=' + _id;
                    $.ajax({
                        url: url,
                        traditional: true,
                        type: 'GET',
                        complete: function (data) {
                            if (CKEDITOR && CKEDITOR.instances) {
                                for (var k in CKEDITOR.instances) {
                                    CKEDITOR.instances[k].setData(data.responseText);
                                }
                            }
                        }
                    });
                }
                else {
                    $elem.text("Ошибка конвертации");
                }
            }

            function hdrFileConvert(_data) {
                var id = parseInt(_data);
                var url = '/ru/FileAttachment/GetFileState?id=' + id;
                convertTimeout = window.setInterval(function () {
                    $.ajax({
                        url: url,
                        traditional: true,
                        type: 'GET',
                        complete: function (_data) {
                            hdrFileUpdate(_data, id);
                        }
                    });
                }, 2000);

            }

            var _hdr = function (ev) {

                $input = $(ev.target || ev.srcElement);
                var converter = $input.hasClass('_convertField');

                $idObjectField = $input.closest('dl.iForm').find('input#Id[type=hidden]');
                $typeObjectField = $idObjectField.next('input#ObjectType[type=hidden]');
                $input.parent().addClass('_preloader');
                var lang = 'ru';
                var url = '/' + lang + '/FileAttachment/' + (converter ? 'ConvertFiles' : 'UploadFiles');
                ajaxUpload({ form: $form[0]
                                      , formAction: url
                                      , onComplete: converter ? hdrFileConvert : hdrFileUpload
                                      , inputs: [$input[0], $idObjectField[0], $typeObjectField[0]]
                });
            };

            $uploadField.live('change', _hdr);
        })();

        //Date validator (00.0000)
        (function () {

            $form.find('.dateDoor._datepicker').live('click', function () {
                $(this).next().show();
                $(this).next().find('input._datepickerInput').focus();
                $(this).next().hide();
            });
            $form.find('input._datepickerInput').datepicker({
                yearRange: "-70:-10",
                changeMonth: true,
                changeYear: true,
                showAnim: 'fadeIn',
                onSelect: function (dateText, inst) {
                    $(this).closest('._datepickerHide').prev().find('span').text(dateText);
                }
            });

        })();

        //Disabled fild, when is check
        (function () {
            $form.find('input._StateEntity[type=checkbox]').live('click', function () {
                var $checker = $(this);
                var $parent = $checker.closest('.' + $checker.attr('rev'));
                var $entity = $parent.find('.' + $checker.attr('rel'));

                $disabled($entity, $checker.attr('checked'));
            });
        })();

        //Ajax Form For User Profile
        (function () {
            $form.find('._AjaxFormForProfile').live('click', function () {

                $but = $(this);

                $('._ajaxFormLoad').remove();
                $('._staticFormLoad').hide();

                var url = $but.attr('rel');
                var $toObj = $but.closest($but.attr('rev'));

                $but.addClass('_preloader');
                $.ajax({
                    traditional: true,
                    type: 'POST',
                    url: url,
                    complete: function () {
                        $but.removeClass('_preloader');
                    },
                    success: function (data) {
                        try {
                            if (data != "" && ($(data).hasClass('_id') || $(data).hasClass('_ajaxFormLoad'))) {
                                $(data).appendTo($toObj);
                                if (!$but.hasClass('_popapAjax')) {
                                    $but.appendTo($toObj);
                                }

                                UpdateLanguage();
                                UpdateField($(data));
                                AttachAutocomplete($form);
                            } else {
                                alert('Ошибка выполнения.');
                            }
                        }
                        catch (e) {
                            $toObj.html(data);
                        }
                    }

                });
            });

            function UpdateLanguage() {
                var $popapL = $('.popup.addLanguageBlock');
                if ($popapL.length <= 0) return;
                $popapL.myPopup();

                var $languageList = $('._editLanguageList li');
                for (var j = 0; j < $languageList.length; ++j) {
                    var $l = $languageList.eq(j);
                    $popapL.find('input#ch_' + $l.attr('rel')).attr('checked', 'checked');
                }
            }
            function UpdateField($block) {
                $block.find('.dateInput input').each(function () {
                    var $input = $(this);
                    //$input.focus();
                    $input.blur();
                });
            }
        })();

        // Select Language
        (function () {
            $('._selectLanguage').live('click', function () {

                var $selectorBlock = $(this).closest('.addLanguageBlock');
                var $languageList = $form.find('._editLanguageList');

                var $newLanguage = $selectorBlock.find('input[type=checkbox]:checked');

                $languageList.empty();

                for (var j = 0; j < $newLanguage.length; ++j) {
                    var $l = $newLanguage.eq(j);
                    var id = $l.attr('id').replace("ch_", "");
                    var $item = $('<li></li>').addClass('_id').attr('rel', id).attr('rev', 'language');
                    $item.html($l.next().text() + "&nbsp;&nbsp;&nbsp;");
                    var $del = $('<span class="delete" title="Удалить">Удалить</span>');
                    //var $par = $('<span class="_param" rel="Title" rev="' + $l.next().text() + '"></span>');
                    $del.appendTo($item);
                    //$par.appendTo($item);

                    $item.appendTo($languageList);

                    SetCreationParam($item, 'Title', $l.next().text());
                }

                $selectorBlock.remove();

            });

            $('._cancelselectLanguage').live('click', function () {
                $(this).closest('.addLanguageBlock').remove();
            });

        })();

        //Add Contact
        (function () {
            $form.find('._newContactForm').live('click', function () {
                $('._ajaxFormLoad').remove();

                var $addBlock = $(this).next();
                $addBlock.find('.filtrSelectBlock ul').removeClass('show');
                $addBlock.find('.filtrSelectBlock ul li').removeClass('choice').eq(0).addClass('choice');
                $addBlock.find('input#fnewContact').val('');
                $addBlock.show();

            });

            $form.find('._cancelAddedContact').live('click', function () {
                $(this).closest('.addContactBlock').hide();
            });

            $form.find('.addContactBlock .filtrSelectBlock ul li').live('click', function () {
                $(this).addClass('choice').siblings().removeClass('choice');

                var $ul = $(this).parent();
                if ($ul.hasClass('show')) {
                    $ul.removeClass('show');
                } else {
                    $ul.addClass('show');
                }
            });

            $form.find('.addContactBlock ._addNewContact').live('click', function () {
                var $blockAdd = $(this).closest('.addContactBlock');

                var $input = $blockAdd.find('input#fnewContact');

                if ($input.val().length > 0) {
                    var choice = $blockAdd.find('.filtrSelectBlock ul li.choice').attr('rel');

                    var $target = $blockAdd.prev().prev('._contactUserList');

                    var $item = $('<div></div>').addClass('field _id _create').attr('rel', '0').attr('rev', 'contact');

                    var label = '<label for="f' + choice + '0" class="name ' + choice + '">';
                    switch (choice) {
                        case "mail": { label = label + "e-mail"; break; }
                        case "phone": { label = label + "телефон"; break; }
                        default: { label = label + choice; break; }
                    }
                    label = label + "</label>";

                    $item.html(label + '<div class="borderAll10 input"><div><input type="text" value="' + $input.val() + '" id="f' + choice + '0" class="_forValue"/></div></div><span class="delete" title="Удалить">Удалить</span>');

                    SetCreationParam($item, 'ContactType', choice);
                    var $span = $('<span></span>').addClass('hiddenParam').addClass('_param _frominput').attr('rel', 'Value').attr('rev', $input.val());
                    $item.append($span);

                    $item.appendTo($target);

                    $blockAdd.hide();
                }


            });
        })();

        AttachAutocomplete($form);

    }
}

function SetCreationParam($newObj, _nameParam, _valueParam) {
    var $span = $('<span></span>').addClass('hiddenParam').addClass('_param').attr('rel', _nameParam).attr('rev', _valueParam);
    $newObj.append($span);
}

function updateModule($modules, _initial, _complete) {

    $modules.not('._delayed').each(function () {
        var $module = $(this);
        if ($module.hasClass('_preventReloadOnce')) {
            $module.removeClass('_preventReloadOnce');
            return;
        }
        // reload module contents
        var tick = $module.attr('rel');
        var uri = $module.attr('rev')
        var view = $module.attr('view');
        var noReload = $module.hasClass('_noReload') && $module.hasClass('_loaded');
        var params = MODULEPARAMS[tick];
        params['ViewName'] = view;
        // prevent loading already rendered server-side modules
        if (_initial && params['DisablePreAjax']) { return; }
        if (noReload) { return; }

        $module.addClass('_preloader');
        $.ajax({
            traditional: true,
            type: 'POST',
            url: uri,
            data: params,
            complete: function () {
                $module.removeClass('_preloader');
            },
            success: function (data, i) {
                $module.html(data);
                $module.addClass('_loaded');
                bindModule($module);
                updateModule($module.find('._module'), true);
                if (_complete) _complete();
            }

        });


    });
}

function ajaxCommand($item, _data, _callback) {

    $.ajax({
        traditional: true,
        type: 'POST',
        url: $item.attr('data-uri'),
        data: _data,
        complete: function () {
            //            $module.removeClass('_preloader');
            if (_callback) _callback();
        },
        success: function (data, i) {
            /*            $module.html(data);
            $module.addClass('_loaded');
            bindModule($module);
            updateModule($module.find('._module'), true);
            if (_complete) _complete();*/
        }

    });
}

function commentOpener($obj) {
    //    alert($obj.html());
    var $obj = $obj.find('._commentOpener');
    $obj.click(function () {
        var $this = $(this);
        var $module = $this.parent().find('._subAddComment');
        $module.removeClass('_delayed');
        updateModule($module);
    });
}

function newChecker($obj) {
    var $hooks = $obj.find("._newHook");
    var $currentDateTime = $("._lastVisit");
    if ($currentDateTime.length) {
        var dt = parseInt($currentDateTime.text());
        $hooks.each(function () {
            if (parseInt($(this).attr('rel')) > dt) {
                $(this).addClass('new');
            }
        })
    }
}

function favouritesSender($obj) {
    var $fav = $obj.find('._favSetter');
    $fav.click(function () {
        var $this = $(this);
        ajaxCommand($this, { set: !$this.hasClass('add') });
        $this.toggleClass('add');
    })
}

function friendRequestSender($obj) {
    var $fav = $obj.find('._friendRequest');
    $fav.click(function () {
        var $this = $(this);
        ajaxCommand($this, {});
        $this.unbind("click");
        $this.text("Отправлен запрос");
        $this.addClass("hide");
    })
}

function joinSender($obj) {
    var $fav = $obj.find('._joinRequest');
    $fav.click(function () {
        var $this = $(this);
        ajaxCommand($this, {});
        $this.unbind("click");
        $this.text("Отправлен запрос");
        $this.addClass("hide");
    })
}

function notificationSender($obj) {
    var $fav = $obj.find('._notificationAction');

    $fav.click(function () {
        var $this = $(this);
        $this.parents('._module').first().addClass('_preloader');
        ajaxCommand($this, {},
            function () {

                updateModule($this.parents('._module').first());
            });
    })
}

function filteredRubricsSelector($obj) {
    var $fav = $obj.find('._rubricFilterSelector');

    $fav.click(function () {
        var $this = $(this);
        $this.parents('._module').first().addClass('_preloader');
        ajaxCommand($this, {}
        /*        function () {
        updateModule($this.parents('._module').first());
        }*/);
    })
}

function deleteFriendGroup($obj) {
    var $fav = $obj.find('._deleteFriendGroup');

    $fav.click(function () {
        var $this = $(this);
        $this.parents('._module').first().addClass('_preloader');
        ajaxCommand($this, {},
            function () {
                updateAllModules();
            });
    })
}

function createFriendGroupPopup($obj) {
    var $engager = $('._createUserGroupPopup');
    $engager.click(function (event) {
        event.preventDefault();
        var $popup = $('.popup.addUserGroupBlock');
        $popup.myPopup(
            function ($this, $form) {
                var title = $form.find('._title').val();
                if (title.length < 3) return;
                ajaxCommand($this,
                {
                    title: title
                }, function () {
                    updateModule($('._userGroupList').find('._module').first());
                });
            }
        );
        return false;
    });
}

function manageFriendsGroupPopup($obj) {
    var $engager = $('._addPeopleControl');
    
    $engager.unbind('click');
    $engager.click(function (event) {
        var self = $(this);
        var title = self.parents('li').first().find('._groupTitle').text();
        var group_id = self.parents('li').first().find('._addPeopleControl').attr('rel');
        var $thismod = self.parents('li').find('._module');

        //event.preventDefault();
        var $popup = $('.popup.addUserBlock');
        $popup.find('._groupTitle').text(title);


        var $mod = $popup.find('._module');

        var func = function () {
            $popup.myPopup(
            function ($this, $form) {
                var ids = $.map($form.find("input[type=checkbox]:checked"), function (n, i) { return parseInt($(n).attr('rel')); });
                ajaxCommand($this,
                {
                    REL_Id1: group_id,
                    REL_ObjectType1: "user_group",
                    ids: ids
                },
                        function () {
                            updateModule($('.availableUsers'));
                            updateModule($thismod);
                        });
            }
        );
        };

        if ($mod.hasClass('_delayed')) {
            $mod.removeClass('_delayed');
            updateModule($mod, false, func);
        } else {
            func();
        }

        return false;
    });
}

function deleteUserLinkPopup($obj) {
    var $engager = $('._deleteUserLink');
    var $thismod = $engager.parents('li').first().find('._module');
    $engager.click(function (event) {
        var self = $(this);
        var rel = $(this).attr('rel');
        var title = self.parents('li').eq(1).find('._groupTitle').text();
        var userTitle = self.next('a').text();
        var groupId = self.parents('.peopleBlock').first().find('._addPeopleControl').first().attr('rel');

        event.preventDefault();
        var $popup = $('.popup.deleteUserBlock');
        $popup.find('._groupTitle').text(title);
        $popup.find('._userTitle').text(userTitle);

        $popup.myPopup(
            function ($this, $form) {
                var deleteFromList = $form.find('._deleteFromList:checked').length;
                var deleteFromFriends = $form.find('._deleteFromFriends:checked').length;

                if (!(deleteFromList || deleteFromFriends)) return;

                ajaxCommand($this,
                {
                    userId: rel,
                    deleteFromList: deleteFromList,
                    deleteFromFriends: deleteFromFriends,
                    groupId: groupId
                }, function () {
                    updateModule($('.availableUsers'));
                    updateModule($thismod);
                });
            }
        );
        return false;
    });
}

function universalDropDowns($anchor) {
    $anchor.find('._dropdown ._dropitem').live('click', function () {
        $(this).addClass('choice').siblings().removeClass('choice');

        var $ul = $(this).parent();
        var $input = $ul.parent().find('input[type=hidden]');
        $input.val($(this).attr('rel'));
        if ($ul.hasClass('show')) {
            $ul.removeClass('show');
        } else {
            $ul.addClass('show');
        }
    });
}

function messagePopup($anchor) {
    $anchor.find('._messagePopup').click(function (event) {
        event.preventDefault();
        $('._amb1').myPopup();
        return false;
    });
    $anchor.find('._messagePopup2').click(function (event) {
        event.preventDefault();
        $('._amb2').myPopup();
        return false;
    });

}

function deleteMessage($obj) {
    var $fav = $obj.find('._deleteMessage');
    var $selectAll = $obj.find('._selectAll');
    $selectAll.click(function () {
        if ($(this).attr('checked')) {
            $('._selection').attr('checked', 'checked');
        } else {
            $('._selection').attr('checked', null);
        }

    });


    $fav.click(function (event) {
        event.preventDefault();
        var $this = $(this);
        $this.removeClass('choice');
        $this.siblings().first().addClass('choice');
        $this.parents('._dropdown').first().removeClass('show');
        $this.parents("._module").first().find('._module').addClass('_preloader');
        var ids = $.map($("input[type=checkbox]._selection:checked"), function (n, i) { return parseInt($(n).attr('rel')); });
        ajaxCommand($this,
        {
            ids: ids
        },
            function () {
                updateModule($this.parents("._module").first().find('._module'));
            });

        return false;
    })
}

function userMaterialSelector($anchor) {
    var $sels = $anchor.find('._userMaterialSelector li');
    $sels.click(function () {
        var $this = $(this);
        var $moduleCheck = $('.' + $this.attr('rel'));
        $moduleCheck.siblings('._module').slideUp();
        if ($moduleCheck.hasClass('_delayed')) {
            $moduleCheck.removeClass('_delayed');
            updateModule($moduleCheck, false, function () 
            { 
                $moduleCheck.slideDown(); 
            });
        }
        else {
            $moduleCheck.slideDown(); 
        }
    });
}

function userActivitySelector($anchor) {
    var $sels = $anchor.find('._userActivitySelector li');
    $sels.click(function () {
        var $this = $(this);
        var rel = '.' + $this.attr('rel');
        var $moduleCheck = $(rel);
        var $tab = $moduleCheck.parents('._tabItem').first();
        $tab.siblings('._tabItem').slideUp();
        if ($moduleCheck.hasClass('_delayed')) {
            $moduleCheck.html('<br/><br/>');
            $moduleCheck.removeClass('_delayed');
            updateModule($moduleCheck, false, function () {

                $tab.slideDown();
            });
        }
        else {
            $tab.slideDown();
        }
    });
}

function moduleRender(_class, _initial) {
    updateModule($('.' + _class), _initial);
}

function bindModule($anchor) {
    universalOpener($anchor, '.rubricDoor', '.rubricBlock', '._universalPeopleDoor', '.peopleBlock');
    universalOpener($anchor, '._universalPeopleDoor', '.peopleBlock', '.rubricDoor', '.rubricBlock');
    initForm($anchor);
    commentOpener($anchor);
    moduleActionNodes($anchor);
    newChecker($anchor);
    favouritesSender($anchor);
    friendRequestSender($anchor);
    joinSender($anchor);
    notificationSender($anchor);
    filteredRubricsSelector($anchor);
    deleteFriendGroup($anchor);
    createFriendGroupPopup($anchor);
    manageFriendsGroupPopup($anchor);
    deleteUserLinkPopup($anchor);
    universalDropDowns($anchor);
    messagePopup($anchor);
    deleteMessage($anchor);
    userMaterialSelector($anchor);
    userActivitySelector($anchor);
    AttachAutocomplete($anchor);
    var editorRubric = new RubricEditor($anchor.find('.selectRubric'));
}

function changeAllModuleParams(paramName, paramValue) {
    for (var mp in MODULEPARAMS) {
        MODULEPARAMS[mp][paramName] = paramValue;
    }
}

function updateAllModules() {
    for (var mp in MODULEPARAMS) {
        var $mod = $('.' + mp);
        if ($mod.parents('._module').length == 0) {
            updateModule($mod);
        }
    }

}

function moduleActionNodes($anchor) {
    var $a = $anchor.find('._moduleAction');
  //  alert($a.length);
    $a.each(function () {
        $(this).click(function (event) {
            event.preventDefault();
            var $this = $(this);
            var $src = $(event.srcElement ? event.srcElement : event.target);

            var cmd = $this.attr('rel');

            var id = $this.attr('rev');
            var $mod = $('.' + id);
            var $thisMod = $this.parents('._module').first();
            var p = MODULEPARAMS[id];
            switch (cmd) {
                case 'searchType':
                    var newdt = $this.attr('data-type');
                    if (newdt != p.REL_ObjectType) {
                        p.REL_ObjectType = newdt;
                        p.Page = 1;
                    }
                    else {
                        return;
                    }

                    $thisMod.addClass('_preventReloadOnce');
                    break;
                case 'nextPage': p.Page = parseInt(p.Page) + 1; break;
                case 'sort':
                    p.Page = 1;
                    if ($this.hasClass('_sortNew')) {
                        p.Order = 1;
                    }
                    else if ($this.hasClass('_sortCommented')) {
                        p.Order = 3;
                    }
                    else if ($this.hasClass('_sortComing')) {
                        p.Order = 6;
                    }
                    else if ($this.hasClass('_sortPassed')) {
                        p.Order = 7;
                    };
                    break;

                case 'filter':
                    p.Page = 1;
                    /*     public enum StatusList
                    {
                    Default = 0,
                    Member = 1,
                    AuthorReader = 2,
                    Organizer = 3,
                    Request = 4,
                    Author = 5
                    } */
                    if ($this.hasClass('_filterAll')) {
                        p.UserFavouriteFilter = 0;
                        p.UserStatusFilter = 0;
                        p.OnlyPublished = 0;
                        p.OnlyDrafts = 0;
                    }
                    else if ($this.hasClass('_filterMember')) {
                        p.UserStatusFilter = 1;
                    }
                    else if ($this.hasClass('_filterAuthorReader')) {
                        p.UserStatusFilter = 2;
                    }
                    else if ($this.hasClass('_filterOrganizer')) {
                        p.UserStatusFilter = 3;
                    }
                    else if ($this.hasClass('_filterRequest')) {
                        p.UserStatusFilter = 4;
                    }
                    else if ($this.hasClass('_filterFavourites')) {
                        p.UserFavouriteFilter = 1;
                        p.UserStatusFilter = 0;
                    }
                    else if ($this.hasClass('_filterPublished')) {
                        p.UserFavouriteFilter = 0;
                        p.UserStatusFilter = 0;
                        p.OnlyPublished = 1;
                        p.OnlyDrafts = 0;
                    }
                    else if ($this.hasClass('_filterDrafts')) {
                        p.UserFavouriteFilter = 0;
                        p.UserStatusFilter = 0;
                        p.OnlyPublished = 0;
                        p.OnlyDrafts = 1;
                    };

                    p.CurrentDate = 0;
                    break;

                case 'pager':
                    //$thisMod.addClass('_preventReloadOnce');
                    $src = $src.closest('._page').first();
                    if (!$src.length) { return; }

                    var newPage = parseInt($src.attr('rel') ? $src.attr('rel') : $src.text());

                    if (newPage > 0) {
                        if (newPage == p.Page) return;
                        p.Page = newPage;
                        $this.find('._page').removeClass('cur');
                        $src.addClass('cur');
                        break;
                    }
                    else {
                        return;
                    }


                case 'filterLetter':
                    {
                        if ($src.parent().hasClass('lang')) return;
                        if ($src.text().length > 1) {
                            p.FilterLetter = "";
                            $src.parent().find('li').removeClass('cur').filter('.all').addClass('cur');
                            p.Page = 1;
                        }
                        else {
                            p.FilterLetter = $src.text();
                            p.Page = 1;
                        }
                        break;
                    }

            }

            updateModule($mod);
        });
    });
}

function moduleBinder(_class) {
    var $anchor = $('.' + _class);
    bindModule($anchor);

}



function AttachAutocomplete(_$node) {

    _$node.find('input._autocompletename').each(function () {
        var $fld = $(this);

        var id = "";
        var $id = $fld.siblings('_autocompleteid');
        if ($id.length > 0) {
            id = $id[0].attr('id');
        }

        var $url = $fld.attr('rel');

        autoCompleteObject($fld.attr('id'), id, $url);

    });

    _$node.find('input._autocompletekeywords').each(function () {
        var $fld = $(this);
        var $url = $fld.attr('rel');

        autoCompleteKeyWords($fld.attr('id'), $url);
    });
};

function popupEnhancer() {
    var $document = $(document);
    $document.click(function (e) {
        var $e = $(e.target);
        var popupParents = $e.parents('._popup, .ui-autocomplete').length;
        var isPopup = $e.is('._popup') || $e.is('.ui-autocomplete');
        if (!(isPopup || popupParents)) {
            $(document).hidePopup();
        }
    });
    $document.keydown(function (e) {
        if (e.keyCode == 27) { $(document).hidePopup(); }
    });
}


