
Sys.Mvc.ValidatorRegistry.validators["isTrue"] = function (rule) {

    // we return the function that actually does the validation 
    return function (value, context) {

        if (context.fieldContext.elements[0].type == "checkbox") {
            // чекбокс не проставлен
            if(!context.fieldContext.elements[0].checked && value)
                return rule.ErrorMessage;        
        }

        if (!value) return rule.ErrorMessage;

        return true;
    };
};
Sys.Mvc.ValidatorRegistry.validators["needonlyone"] = function (rule) {
    return function (value, context) {

        var otherPropertyControl = $("#" + rule.ValidationParameters.otherProperty);
        if (otherPropertyControl == null) {
            return rule.ErrorMessage;
        }
        
        var otherPropertyValue = otherPropertyControl[0].value;
        if (otherPropertyValue == "" && value == "") { return rule.ErrorMessage; }

        return true;
    };
};

Sys.Mvc.ValidatorRegistry.validators["passwordsEquality"] = function (rule) {
    return function (value, context) {
        //var otherPropertyControl = $("#" + rule.ValidationParameters.otherProperty);
        var otherPropertyControl = $("input[id$='" + rule.ValidationParameters.otherProperty + "']");
        if (otherPropertyControl == null) {
            return rule.ErrorMessage;
        }

        var otherPropertyValue = otherPropertyControl[0].value;
        if (otherPropertyValue != value) { return rule.ErrorMessage; }

        return true;
    };
};

Sys.Mvc.ValidatorRegistry.validators["entryKeyWords"] = function (rule) {
    return function (value, context) {

        //Если поле не пустое, нет смысла проверять дальше
        //Проверяем только на число ключевых слов.
        if (value != "") {
            var arr = value.split(',');
            if (arr.length > 5) return "Допускается ввод не более 5 ключевых слов";
            return true;
        }

        //Сюда попадаем только если value == ""

        var userMessage = "Вы уверены, что хотите создать запись без ключевых слов? В таком случае ее будет сложнее найти и оценить.";

        //Если доп. свойство указано, пытаемся вычислить его значение и проверить.
        if (rule.ValidationParameters.otherProperty == "EntryType") {
            var otherPropertyControl = $("#" + rule.ValidationParameters.otherProperty);
            if (otherPropertyControl != null) {
                var otherPropertyValue = otherPropertyControl[0].value;
                if (otherPropertyValue == "DiscussionEntry") { return rule.ErrorMessage; }
            }
        } else if (rule.ValidationParameters.otherProperty == "Publisher") {
            userMessage = "Вы уверены, что хотите создать публикацию без ключевых слов? В таком случае ее будет сложнее найти и оценить.";
        } else if (rule.ValidationParameters.otherProperty == "isSpecial") {
            userMessage = "Вы уверены, что хотите сохранить судебное решение без ключевых слов? В таком случае его будет сложнее найти и оценить.";
        }

        //Хотим без ключевых слов?
        if (confirm(userMessage)) {
            return true;
        } else {
            return rule.ErrorMessage;
        }


        return true;
    };
};

Sys.Mvc.ValidatorRegistry.validators["securePassword"] = function (rule) {
    return function (value, context) {

        var isTruePass = true;

        if (value.length > 0 && value.length < 8) isTruePass = false;

//        if (isTruePass && value.length >= 8) {
//            var re1 = new RegExp('[a-z]');
//            var re2 = new RegExp('[A-Z]');
//            var re3 = new RegExp('[0-9]');

//            if (re1.test(value) && re2.test(value) && re3.test(value)) {
//                isTruePass = true;
//            }
//            else isTruePass = false;
//        }

//        if (!isTruePass) {
//            if (confirm("Вы уверены, что хотите использовать текущий небезопасный пароль?")) {
//                return true;
//            } else {
//                return rule.ErrorMessage;
//            }
//        }

        if (!isTruePass) return rule.ErrorMessage;

        return true;
    };
};