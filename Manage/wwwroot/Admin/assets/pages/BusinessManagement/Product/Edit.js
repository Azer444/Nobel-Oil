
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


$("#subcategory").on("change", function () {
    subCategoryId = parseInt($(this).val())
    console.log(url)
    $.ajax({
        method: "GET",
        url: url + "?id=" + subCategoryId,
        success: function (response) {
            $('#parameter-section').html('');
            response = JSON.parse(response);
            for (var i = 0; i < response.data.length; i++) {
                let parameter = GetParamater(response.data[i], i)
                $("#parameter-section").append(parameter);
                InitializeEditor();
            }
        }
    });
});


function AddParameter(data) {

}

function GetParamater(data, row) {
    let section =
        `<div class="row">
        <div class="col-12">
            <div class="card">
                <h5 class="card-header">${data.Name_EN}</h5>
                <div class="card-body">
                    <div class="row">
                        <input form="product-create" name="ProductParameters[${row}].ParameterId" type="hidden" value="${data.Id}">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-control-label">Description (AZ)</label>
                                <textarea name="ProductParameters[${row}].Description_AZ" class="form-control form-control parameter-description" form="product-create"></textarea>
                                <span class="invalid-feedback" style="display:block"></span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-control-label">Description (RU)</label>
                                <textarea name="ProductParameters[${row}].Description_RU" class="form-control form-control parameter-description" form="product-create"></textarea>
                                <span class="invalid-feedback" style="display:block"></span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-control-label">Description (EN)</label>
                                <textarea name="ProductParameters[${row}].Description_EN" class="form-control form-control parameter-description" form="product-create"></textarea>
                                <span class="invalid-feedback" style="display:block"></span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-control-label">Description (TR)</label>
                                <textarea name="ProductParameters[${row}].Description_TR" class="form-control form-control parameter-description" form="product-create"></textarea>
                                <span class="invalid-feedback" style="display:block"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-control-label">Value</label>
                                <input name="ProductParameters[${row}].Value" class="form-control form-control" form="product-create">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>`

    return section
}
