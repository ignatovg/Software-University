function loadTitle() {

    $(document).ajaxError(function (event, req, settings) {
        $('#text').text(`Error loading data: ${req.status} (${req.statusText})`);
    });

    $('#text').load('text.html');

}