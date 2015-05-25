/*
jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        // CAUTION: Needed to parenthesize options.path and options.domain
        // in the following expressions, otherwise they evaluate to undefined
        // in the packed version for some reason...
        var path = options.path ? '; path=' + (options.path) : '';
        var domain = options.domain ? '; domain=' + (options.domain) : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};

var X_CSRFToken = $.cookie('csrftoken');
*/


$(function(){

	// autohide
	var $fields = $('label._autohide ~ input, label._autohide ~ textarea');
	var hdr = function () { $('label[for="' + this.getAttribute('id') + '"]').toggle( this.value == ''); };


	$fields.live('focus', function () { $('label._autohide[for="' + this.getAttribute('id') + '"]').hide(); });
	$fields.live('blur', hdr);
	$fields.live('change', hdr);

	$fields.each(hdr);

	// a
	$('a[href=#]').attr('href', 'javascript:void("empty link");');


    $.fn.switchSibClass = function( _class ){
        this.addClass( _class ).siblings().removeClass( _class );
    };


	$.fn.unselectable = function() {
		return this.each(function() {
			var $node = $(this);


			if ($.browser.msie) {						// IE
				$node.each( function(){
					this.ondrag = function(){ return false; };
					this.onselectstart = function(){ return (false); };
				});

			} else if($.browser.opera) {
				$node.attr('unselectable', 'on');

			} else {
				$node
					.css('-moz-user-select', 'none')		// FF
					.css('-khtml-user-select', 'none')		// Safari, Google Chrome
					.css('user-select', 'none');			// CSS 3
			}

		});
	};


	;
});

