var exprMail = new RegExp('^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$');
$(function () {
    var $body = $('body');

    (function () {
        $('#header .entryDoor').live('click', function () {
            $(this).parent().toggleClass('show');
        });
        $body.click(function (ev) {
            if ($(ev.target).closest('#header div.entryBlock').length == 0) {
                var $eb = $('#header div.entryBlock');
                $eb.removeClass('show');
                $eb.find('input[type=text]').val('');
                $eb.find('input[type=password]').val('');
                $eb.find('input[type=checkbox]').each(function () { this.checked = null; });
            }
        });

        var $form = $('#header .entryBlock form');
        var signInHandler = function (ev) {
            ev.preventDefault();
            var $this = $('#header .entryBlock form');
            var $parentForm = $this.closest('form');
            var $entryLoginBlock = $parentForm.closest('#loginBlock');
            var $login = $parentForm.find('input[type=text]');
            var $pass = $parentForm.find('input[type=password]')

            if ($login.val() == "") {
                $parentForm.find('.errorAuth').text('Введите имя пользователя');
            }
            else if (!exprMail.test(($login.val()))) {
                $parentForm.find('.errorAuth').text('Неправильный формат электронной почты');
            }
            else if ($pass.val() == "") {
                $parentForm.find('.errorAuth').text('Введите пароль');
            }
            else {

                var $preload = $parentForm.find('div.userEnter');
                $preload.addClass('_preloader');

                var $remember = $parentForm.find('input[type=checkbox]');
                var checked = (($parentForm.find('input[type=checkbox]:checked').length > 0) ? 'true' : 'false');
                var data = {};
                data[$login.attr('name')] = $login.val();
                data[$pass.attr('name')] = $pass.val();
                data[$remember.attr('name')] = checked;

                $.ajax({
                    url: $parentForm.attr('action')
	            , data: data
	            , type: 'post'
                , complete: function () {
                    $preload.removeClass('_preloader');
                }
	            , success: function (_data) {
	                //	                $header = $(_data);
	                //	                $entryLoginBlock.empty();
	                $('#loginBlock').html(_data);
	            }
                });
            }
        };

        //$form.live('submit', signInHandler);
        $form.find('.entryButton').unbind().live('click', signInHandler);
        $form.find('input[type=password]').keydown(function (e) {
            var keyCode = e.keyCode || e.which;
            if (keyCode == 13) {
                signInHandler(e);
                return false;
            }
        });

        $('#header .userPanel .exit').live('click', function () {
            $btn = $(this);
            var $entryLoginBlock = $btn.closest('#loginBlock');

            var $preload = $entryLoginBlock.find('div.userPanel');
            $preload.addClass('_preloader');

            $.ajax({
                url: $btn.attr('rel')
        	            , type: 'post'
                        , complete: function () {
                            $preload.removeClass('_preloader');
                        }
                        , success: function (_data) {
                            $header = $(_data);
                            $entryLoginBlock.empty();
                            $entryLoginBlock.append($header);

                            $body.find('._module').each(function () { updateModule($(this)) });
                        }
            });
        });

        var signInHandler2 = function (ev) {

            var $this = $('._staticAutch form');

            var $login = $this.find('input[type=text]');
            var $pass = $this.find('input[type=password]')

            if ($login.val() == "") {
                ev.preventDefault();
                $this.find('span[id*=Login]').text('Введите имя пользователя');
            }
            else if (!exprMail.test(($login.val()))) {
                ev.preventDefault();
                $this.find('span[id*=Login]').text('Неправильный формат электронной почты');
            }
            else if ($pass.val() == "") {
                ev.preventDefault();
                $this.find('span[id*=Password]').text('Введите пароль');
            }
        };
        var $form2 = $('._staticAutch form');
        $form2.find('.entryButton2').unbind().live('click', signInHandler2);
        $form2.find('input[type=password]').keydown(function (e) {
            var keyCode = e.keyCode || e.which;
            if (keyCode == 13) {
                $form2.find('.entryButton2').click();
                return false;
            }
        });


        var signInHandler3 = function (ev) {

            var $this = $('._recoverPass form');

            var $mail = $this.find('input._emailString');
            var $captcha = $this.find('input._CaptchaString');

            if ($mail.val() == "") {
                ev.preventDefault();
                $this.find('span[id*=EMail]').text('Укажите адрес электронной почты');
            }
            else if (!exprMail.test(($mail.val()))) {
                ev.preventDefault();
                $this.find('span[id*=EMail]').text('Неправильный формат электронной почты');
            }
            else if ($captcha.val() == "") {
                ev.preventDefault();
                $this.find('span[id*=Captcha]').text('Введите текст');
            }

        };
        var $form3 = $('._recoverPass form');
        $form3.find('.entryButton3').unbind().live('click', signInHandler3);
        $form3.find('._CaptchaString').keydown(function (e) {
            var keyCode = e.keyCode || e.which;
            if (keyCode == 13) {
                $form3.find('.entryButton3').click();
                return false;
            }
        });

        $form3.find(".code .update").live("click", function () {
            var $update = $(this);
            var $imageBlock = $update.prev('._captcha');
            $imageBlock.addClass('_preloader');
            $.ajax({
                type: 'POST',
                traditional: true,
                url: $update.attr('rel'),
                complete: function () {
                    $imageBlock.removeClass('_preloader');
                },
                success: function (_data) {
                    if (_data != null) {

                        $imageBlock.empty();                        
                        $(_data).appendTo($imageBlock);
                    }
                }
            });

        });

    })();

});