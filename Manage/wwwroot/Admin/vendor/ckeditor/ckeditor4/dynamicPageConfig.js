CKEDITOR.editorConfig = function (config) {
	config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
		{ name: 'forms', groups: ['forms'] },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
		{ name: 'links', groups: ['links'] },
		{ name: 'insert', groups: ['insert'] },
		'/',
		{ name: 'styles', groups: ['styles'] },
		{ name: 'colors', groups: ['colors'] },
		{ name: 'tools', groups: ['tools'] },
		{ name: 'others', groups: ['others'] },
		{ name: 'about', groups: ['about'] }
	];

	config.removeButtons = 'Replace,Find,Scayt,Radio,Bold,CopyFormatting,Source,Save,NewPage,ExportPdf,Preview,Print,Templates,Cut,About,ShowBlocks,Copy,Paste,PasteText,PasteFromWord,TextField,Textarea,Select,Button,ImageButton,HiddenField,RemoveFormat,Italic,Underline,Strike,Subscript,Superscript,Iframe,PageBreak,SpecialChar,Table,Image,CreateDiv,Blockquote,Form,Checkbox,Language';
};