$(document).ready(function () {
    $('body').on('click', '.ajax-button', function () {

        var url = $(this).data('url');

        $.get(url, function (data) {

            $('.about-content').html(data);
        });
    });
});