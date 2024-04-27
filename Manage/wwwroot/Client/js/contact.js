$(function () {

    $('#contact-form').submit(function (e) {
        e.preventDefault();

        var fullName = $('#fullName').val();
        var email = $('#email').val();
        var phone = $('#phone').val();
        var subject = $('#subject').val();
        var message = $('#message').val();

        if (fullName == "" || email == "" || phone == "" || subject == "" || message == "") {
            $('#contact-form #error-alert').removeClass('d-none');
        }
        else {

            var data = new FormData(this);

            $.ajax({
                url: contactPostUrl,
                data: data,
                method: 'post',
                cache: false,
                contentType: false,
                processData: false,
                success: function () {
                    $('#contact-form #error-alert').addClass('d-none');
                    $('#contact-form #success-alert').removeClass('d-none');
                    setTimeout(function () {
                        $('#contact-form #success-alert').addClass("d-none");
                    }, 3000)

                    $('#contact-form').find("input, textarea").val("");
                },
                error: function () {
                    $('#contact-form #error-alert').removeClass('d-none');
                }
            })
        }
    })
});
