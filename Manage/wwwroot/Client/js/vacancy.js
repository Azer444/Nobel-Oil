//$(function () {

//    $('#apply-form').submit(function (e) {
//        e.preventDefault();

//        var fullName = $('#fullName').val();
//        var email = $('#email').val();
//        var vacancyId = $('#vacancyId').val();
//        var cv = $('#cv-form-file').val();

//        if (fullName == "" || email == "" || vacancyId == "" || cv == null) {
//            $('#apply-form #error-alert').removeClass('d-none');
//        }
//        else {

//            var data = new FormData(this);

//            $.ajax({
//                url: vacancyPostUrl,
//                data: data,
//                method: 'post',
//                cache: false,
//                contentType: false,
//                processData: false,
//                success: function () {
//                    $('#apply-form #error-alert').addClass('d-none');
//                    $('#apply-form #success-alert').removeClass('d-none');
//                    setTimeout(function () {
//                        $('#apply-form #success-alert').addClass("d-none");
//                    }, 3000)

//                    $('#apply-form').find("input, textarea").val("");
//                    $('.g-upload__label').text('');
//                },
//                error: function () {
//                    $('#apply-form #error-alert').removeClass('d-none');
//                }
//            })
//        }
//    })

//    $(document).on('click', '.apply-btn', function () {
//        $('#apply-form').find("input, textarea").val("");
//        var vacancyId = $(this).attr('id');
//        $('#apply-form #vacancyId').val(vacancyId);
//        var positionText = $(this).parents().eq(1).siblings().eq(0).children().eq(0).text();
//        $('#apply-form #position').val(positionText.trim());
//    })

//});

//$(function () {

//    $('#apply-form').submit(function (e) {
//        e.preventDefault();

//        var fullName = $('#fullName').val();
//        var email = $('#email').val();
//        var vacancyId = $('#vacancyId').val();
//        var cv = $('#cv-form-file').val();

//        if (fullName == "" || email == "" || vacancyId == "" || cv == null) {
//            $('#apply-form #error-alert').removeClass('d-none');
//        }
//        else {
//            const data = new FormData(this);
//            try {
//                $.ajax({
//                    url: '/en/career/apply',
//                    data: data,
//                    method: 'post',
//                    cache: false,
//                    contentType: false,
//                    processData: false,
//                    success: function () {
//                        $('#apply-form #error-alert').addClass('d-none');
//                        $('#apply-form #success-alert').removeClass('d-none');
//                        setTimeout(function () {
//                            $('#apply-form #success-alert').addClass("d-none");
//                        }, 3000)

//                        $('#apply-form').find("input, textarea").val("");
//                        $('.g-upload__label').text('');
//                    },
//                    error: function () {
//                        console.log("error");
//                        $('#apply-form #error-alert').removeClass('d-none');
//                    }
//                })
//            } catch (e) {
//                console.log(e);
//            }
//        }
//    })

//    $(document).on('click', '.apply-btn', function () {
//        $('#apply-form').find("input, textarea").val("");
//        var vacancyId = $(this).attr('id');
//        $('#apply-form #vacancyId').val(vacancyId);
//        var positionText = $(this).parents().eq(1).siblings().eq(0).children().eq(0).text();
//        $('#apply-form #position').val(positionText.trim());
//    });

//});

$(document).on('click', '.apply-btn', function () {
    //$('#apply-form').find("input, textarea").val("");
    var vacancyId = $(this).attr('id');
    $('#apply-form #vacancyId').val(vacancyId);
    var positionText = $(this).parents().eq(1).siblings().eq(0).children().eq(0).text();
    $('#apply-form #position').val(positionText.trim());
});

jqueryAjaxPost = (form) => {

    var fullName = $('#fullName').val();
    var email = $('#email').val();
    var vacancyId = $('#vacancyId').val();
    var cv = $('#cv-form-file').val();

    if (fullName == "" || email == "" || vacancyId == "" || cv == null) {
        $('#apply-form #error-alert').removeClass('d-none');
    }
    else {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function () {
                $('#apply-form #error-alert').addClass('d-none');
                $('#apply-form #success-alert').removeClass('d-none');
                setTimeout(function () {
                    $('#apply-form #success-alert').addClass("d-none");
                }, 3000)

                $('#apply-form').find("input, textarea").val("");
                $('.g-upload__label').text('');
            },
            error: function (e) {
                console.log(e);
                $('#apply-form #error-alert').removeClass('d-none');
            }
        });

    }
    // to prevent default form submit event
    return false;
};