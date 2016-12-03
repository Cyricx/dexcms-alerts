$.ajax({
    url: DEXCMS_GLOBALS.ROOT_PATH + "/alerts/getalerts",
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