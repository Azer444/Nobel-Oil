
$(function () {

    InitializeEditor();

    $('#Name_EN').on('input', function () {
        $('#Slug').val(slug($(this).val()));
    });

    $('.custom-file input').change(function (e) {
        var files = [];
        for (var i = 0; i < $(this)[0].files.length; i++) {
            files.push($(this)[0].files[i].name);
        }
        $(this).next('.custom-file-label').html(files.join(', '));
    });
});


//Editor

function InitializeEditor() {
    if ($(".parameter-description").length > 0) {
        tinymce.init({
            selector: "textarea.parameter-description",
            theme: "modern",
            menubar: false,
            statusbar: false,
            toolbar_items_size: 'small',
            fontsize_formats: "8pt 10pt 12pt 14pt 18pt 24pt 36pt",
            plugins: [
                "lists textcolor",
            ],
            readonly: 1,
            toolbar: "bold italic | fontsizeselect | bullist numlist | forecolor",
            style_formats: [
                { title: 'Bold text', inline: 'b' },
                { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
                { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
                { title: 'Example 1', inline: 'span', classes: 'example1' },
                { title: 'Example 2', inline: 'span', classes: 'example2' },
                { title: 'Table styles' },
                { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
            ]
        });
    }
}