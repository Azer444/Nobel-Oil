$(function () {
    $(".news-section__card .news-section__card--title").each(function () {
        var text = $(this).text();
        if (text.length > 150) {
            $(this).text(text.substr(0, text.lastIndexOf(' ', 147)) + '');
        }
    });

    $(".news-section__card .news-section__card--info").each(function () {
        var text = $(this).children().eq(0).text();
        if (text.length > 200) {
            $(this).text(text.substr(0, text.lastIndexOf(' ', 197)) + '');
        }
        else {
            $(this).text(text + '');
        }
    });


})
