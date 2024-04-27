

$('#contactsubmit-form').on("submit", function (e) {
    e.preventDefault();

    var data = new FormData(this);

    console.log(data)

    $.ajax({
        url: postUrl,
        data: data,
        method: 'post',
        cache: false,
        contentType: false,
        processData: false,
        success: function () {
            $('#alert-box-danger').hide();
            $('#alert-box-success').html("Mesaj uğurla göndərildi")
            $('#alert-box-success').show();
                
            //Reset form
            this.reset();
        },
        error: function () {
            $('#alert-box-success').hide();
            $('#alert-box-danger').show();

            $('#alert-box-danger').html("Mesaj göndərilməsində problem var")
        }
    })
    
})