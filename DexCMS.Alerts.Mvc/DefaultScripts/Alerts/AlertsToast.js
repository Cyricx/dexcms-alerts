$.ajax({
    url: '@Url.Content("/alerts/getalerts")',
    type: 'GET'
}).done(function (data) {
    if (data != null && data.length > 0) {
        var $alertBox = $('#alerts');
        $alertBox.show();
        for (var i = 0; i < data.length; i++) {
            $alertBox.append('<p><i class="fa fa-exclamation-triangle"></i>' + data[i].AlertText + '</p>');
        }
    }
});

var fixHeader = function () {
    var width = window.innerWidth - 20;
    $('header').css('width', width);
};

$(window).on('resize', fixHeader).on('load', fixHeader);