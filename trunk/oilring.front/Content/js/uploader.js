function ajaxUpload( _cfg ){

	var frameUpload;
	var formUpload;

	var frameUploadName = 'DataUploaderFrame'
	var formUploadName = 'DataUploaderForm'

	var el;
	var cln;
	var cloneIdPrefix = 'inputFileClone';


	function onFrameUpload() {
	    try {
	        var doc = frameUpload.contentDocument || frameUpload.contentWindow.document;

	        if (_cfg.onComplete != null)
	            _cfg.onComplete(doc.body.innerHTML);
	    }
	    catch (e) {
	        if (_cfg.onComplete != null)
	            _cfg.onComplete("Error upload file!");
	    }

	    frameUpload.parentNode.removeChild(frameUpload);
	}



	frameUpload = document.getElementById( frameUploadName );
	if( frameUpload == null ){

		// Create frame
		frameUpload = document.createElement('iframe');

		// prepare iframe
		frameUpload.setAttribute('id', frameUploadName );
		frameUpload.setAttribute('name', frameUploadName );
		frameUpload.setAttribute('width', '0');
		frameUpload.setAttribute('height', '0');
		frameUpload.setAttribute('border', '0');
		frameUpload.setAttribute('style', 'width: 0; height: 0; border: none; display:none;');

		document.body.appendChild(frameUpload);

		// IE bug :)
		window.frames[ frameUploadName ].name= frameUploadName;

		// Attach event
		if (frameUpload.addEventListener)
		    frameUpload.addEventListener('load', onFrameUpload, true)
		else
		    if (frameUpload.attachEvent)
		        frameUpload.attachEvent('on' + 'load', onFrameUpload);
		    else
		        alert('Strange browser error');


		
	}


	formUpload = document.getElementById( formUploadName );
	if( formUpload == null ){
		// Create form
		formUpload = document.createElement('form');

		// Set form state
		formUpload.setAttribute('id', formUploadName );
		formUpload.setAttribute('target', frameUploadName );
		formUpload.setAttribute('method', 'post');
		formUpload.setAttribute('enctype', 'multipart/form-data' );
		formUpload.setAttribute('encoding', 'multipart/form-data' );
		formUpload.setAttribute('style', 'display:none;');

		document.body.appendChild( formUpload );
	}

	// Set new form action
	formUpload.setAttribute('action', _cfg.formAction );

	// Clear chlid nodes
	formUpload.innerHTML = '';


	// Add new elements into form
	for(var i=0; i<_cfg.inputs.length;i++ ){
	    el = _cfg.inputs[i];
	    if (!el) continue;
		cln = document.createElement('input');

		cln.setAttribute('id', cloneIdPrefix + i );

		el.parentNode.replaceChild(cln, el);
		formUpload.appendChild( el );
	}


	if( _cfg.onBeforeSubmit != null )
		_cfg.onBeforeSubmit();

	// Submit
	formUpload.submit();

	if( _cfg.onAfterSubmit != null )
		_cfg.onAfterSubmit();


	for(var i=0; i<_cfg.inputs.length;i++ ){
		el = document.getElementById( cloneIdPrefix + i );
		if (el) {
		    el.parentNode.replaceChild(_cfg.inputs[i], el);
		}
	}
}


