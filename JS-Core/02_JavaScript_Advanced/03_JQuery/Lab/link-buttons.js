function attachEventsLecturer() {
    $('a.button').on('click', clicked);

    function clicked(event) {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }
}

function attachEvents() {
    $('a.button').on('click','onClick');

    function onClick(event) {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }
}