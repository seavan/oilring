var expr = new RegExp('^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$');
var nowErrorEmail = false;
var beErrorEmail = false;
function TestEmail($input) {
    if ($input.val().length > 0) {
        if (expr.test($input.val())) {
            nowErrorEmail = false;
            return '';
        }
        else {
            beErrorEmail = true;
            nowErrorEmail = true;
            return 'Неправильный формат электронной почты';
        }
    }
    else {
        if (beErrorEmail) return 'Укажите адрес электронной почты';
    }
}
function TestHasEmail($input, $error) {

    $.ajax({
        type: 'POST',
        traditional: true,
        url: $input.attr('rev'),
        data: { _email: $input.val() },
        success: function (_data) {
            if (_data.toLowerCase() == "true") {
                beErrorEmail = true;
                nowErrorEmail = true;
                $error.text('Такой EMail уже есть в системе');
            }
            else {
                $error.text('');
            }
        }
    });
    
}

var nowErrorPass = false;
var beErrorPass = false;
function TestPass($pass1, $pass2) {

    var $error = $pass1.parent().parent().next('.error');

    if ($pass1.val().length > 0 && $pass2.val().length > 0) {
        $error.text('');
        if ($pass1.val() == $pass2.val()) {
            nowErrorPass = false;
            return '';
        }
        else {
            nowErrorPass = true;
            beErrorPass = true;
            return 'Пароли должны совпадать';
        }
    }
    else {
        if (beErrorPass) {
            
            nowErrorPass = false;
            if ($pass1.val().length <= 0) {
                
                $error.text('Укажите пароль');
            }
            if ($pass2.val().length <= 0) {
                return 'Подтвердите пароль';
            }
            return '';
        }
    }
}

$(function () {

    //Email Validation
    (function () {
        var $email = $('.iForm.registrationBlock').find('input#EMail');
        var $error = $email.parent().parent().next('.error');

        $email.keyup(function () {
            if (beErrorEmail) {
                $error.text(TestEmail($email));
            }
        });
        $email.blur(function () {
            $error.text(TestEmail($email));
            if (!nowErrorEmail) {
                TestHasEmail($email, $error);
            }
        });
    })();

    //Password Validation
    (function () {
        var $pass = $('.iForm.registrationBlock').find('input#Password');
        var $passConf = $('.iForm.registrationBlock').find('input#PasswordConfirm');
        var $error = $passConf.parent().parent().next('.error');

        $pass.keyup(function () {
            if (beErrorPass) {
                $error.text(TestPass($pass, $passConf));
            }
        });
        $passConf.keyup(function () {
            if (beErrorPass) {
                $error.text(TestPass($pass, $passConf));
            }
        });

        $pass.blur(function () {
            $error.text(TestPass($pass, $passConf));

        });
        $passConf.blur(function () {
            $error.text(TestPass($pass, $passConf));
        });

    })();

    var beCheckPass = false;
    (function () {
        var $check = $('.iForm.registrationBlock').find('input#AgreementConfirm');
        var $error = $check.parent().next('.error');

        $check.live('click', function () {

            if ($check.attr('checked')) {
                $error.text('');
                $('.iForm.registrationBlock').find('input[type=submit]').removeClass('hide');
            }
            else {
                if (beCheckPass) {
                    $error.text('Вы должны подтвердить свое согласие');
                }
                $('.iForm.registrationBlock').find('input[type=submit]').addClass('hide');
            }
        });

    })();

    var $form = $('.iForm.registrationBlock');
    var $submits = $form.find('input[type=submit]');

    $submits.live('click', function (ev) {

        var $this = $(this);
        var $parentForm = $this.parents('form:first');

        if (nowErrorEmail) {
            ev.preventDefault();
        }

        if (nowErrorPass) {
            ev.preventDefault();
        }

        if ($form.find('input[type=checkbox]:checked').length <= 0) {
            ev.preventDefault();
            var $error = $form.find('input[type=checkbox]').parent().next('.error');
            $error.text('Вы должны подтвердить свое согласие');
            beCheckPass = true;
        }

    });

});