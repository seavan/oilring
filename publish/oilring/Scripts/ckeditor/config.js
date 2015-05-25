/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	config.language = 'ru';
    // config.uiColor = '#AADC6E';
	config.extraPlugins = 'equation';

    config.toolbar = [
                        ['Cut','Copy','Paste','PasteText','PasteFromWord'],
                        ['Undo','Redo', 'Find','Replace','SelectAll','RemoveFormat'],
                        ['Link','Unlink','Anchor'],
                        ['equation', '-', 'Table', 'Smiley'],
                        ['TextColor','BGColor'],
                        ['Maximize'],
                        '/',
                        ['Bold','Italic','Underline','Strike','-','Subscript','Superscript'],
                        ['NumberedList','BulletedList','-','Outdent','Indent','Blockquote'],
                        ['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],
                        '/',
                        ['Styles','Format','Font','FontSize']
                ];
};
