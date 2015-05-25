Sys.Mvc.FieldContext.prototype = { $6: null, $7: null, $8: null, $9: null, defaultErrorMessage: null, formContext: null, replaceValidationMessageContents: false, validationMessageElement: null, addError: function (message) { this.addErrors([message]); }, addErrors: function (messages) { if (!Sys.Mvc._ValidationUtil.$0(messages)) { Array.addRange(this.$A, messages); this.$14(); } }, clearErrors: function () { Array.clear(this.$A); this.$14(); }, $B: function () { var $0 = this.validationMessageElement; if ($0) { if (this.replaceValidationMessageContents) { Sys.Mvc._ValidationUtil.$4($0, this.$A[0]); } Sys.UI.DomElement.removeCssClass($0, 'field-validation-valid'); Sys.UI.DomElement.addCssClass($0, 'field-validation-error'); } var $1 = this.elements; for (var $2 = 0; $2 < $1.length; $2++) { var $3 = $1[$2]; Sys.UI.DomElement.removeCssClass($3, 'input-validation-valid'); Sys.UI.DomElement.addCssClass($3, 'input-validation-error'); } }, $C: function () { var $0 = this.validationMessageElement; if ($0) { if (this.replaceValidationMessageContents) { Sys.Mvc._ValidationUtil.$4($0, ''); } Sys.UI.DomElement.removeCssClass($0, 'field-validation-error'); Sys.UI.DomElement.addCssClass($0, 'field-validation-valid'); } var $1 = this.elements; for (var $2 = 0; $2 < $1.length; $2++) { var $3 = $1[$2]; Sys.UI.DomElement.removeCssClass($3, 'input-validation-error'); Sys.UI.DomElement.addCssClass($3, 'input-validation-valid'); } }, $D: function ($p0) { if ($p0.target['__MVC_HasTextChanged'] || $p0.target['__MVC_HasValidationFired']) { this.validate('blur'); } }, $E: function ($p0) { $p0.target['__MVC_HasTextChanged'] = true; }, $F: function ($p0) { $p0.target['__MVC_HasTextChanged'] = true; if ($p0.target['__MVC_HasValidationFired']) { this.validate('input'); } }, $10: function ($p0) { if ($p0.rawEvent.propertyName === 'value') { $p0.target['__MVC_HasTextChanged'] = true; if ($p0.target['__MVC_HasValidationFired']) { this.validate('input'); } } }, enableDynamicValidation: function () { var $0 = this.elements; for (var $1 = 0; $1 < $0.length; $1++) { var $2 = $0[$1]; if (Sys.Mvc._ValidationUtil.$2($2, 'onpropertychange')) { var $3 = document.documentMode; if ($3 && $3 >= 8) { Sys.UI.DomEvent.addHandler($2, 'propertychange', this.$9); } } else { Sys.UI.DomEvent.addHandler($2, 'input', this.$8); } Sys.UI.DomEvent.addHandler($2, 'change', this.$7); Sys.UI.DomEvent.addHandler($2, 'blur', this.$6); } }, $11: function ($p0, $p1) { var $0 = $p1 || this.defaultErrorMessage; if (Boolean.isInstanceOfType($p0)) { return ($p0) ? null : $0; } if (String.isInstanceOfType($p0)) { return (($p0).length) ? $p0 : $0; } return null; }, $12: function () { var $0 = this.elements; return ($0.length > 0) ? $0[0].value : null; }, $13: function () { var $0 = this.elements; for (var $1 = 0; $1 < $0.length; $1++) { var $2 = $0[$1]; $2['__MVC_HasValidationFired'] = true; } }, $14: function () { if (!this.$A.length) { this.$C(); } else { this.$B(); } }, validate: function (eventName) {
    var $0 = this.validations; var $1 = []; var $2 = this.$12(); for (var $3 = 0; $3 < $0.length; $3++) {
        var $4 = $0[$3]; var $5 = Sys.Mvc.$create_ValidationContext(); $5.eventName = eventName; $5.fieldContext = this;
        $5.validation = $4; var $6 = $4.validator($2, $5); var $7 = this.$11($6, $4.fieldErrorMessage);
        if (!Sys.Mvc._ValidationUtil.$1($7)) { Array.add($1, $7); } 
    }
    this.$13();
    this.clearErrors();
    this.addErrors($1);
    this._changeState(this.elements[0].id, $1.length > 0);
    return $1;
} ,
_changeState: function ChageState(id, wasError) {
    var field = $("#" + id + "_field");
    if (wasError) {
        field.removeClass("ok");
        field.addClass("error");
        $('#' + id + "_errors").show();
    } else {
        field.addClass("ok");
        field.removeClass("error");
        $('#' + id + "_errors").hide();
    }
}
}