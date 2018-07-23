function getInfo() {
    let stopId = $('#stopId').val();
    let stopName = $('#stopName');
    let baseUrl = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
    let busesId = $('#buses');
    busesId.empty();

    let req = {
        method:'GET',
        url:baseUrl,
        success: displayData,
        error: displayError,
    };
    $.ajax(req);

    function displayData(data) {

        stopName.text(data.name);

        for (let key in data['buses']) {
            let li = $(`<li>Bus ${key} arrives in ${data['buses'][key]} minutes</li>`);
            busesId.append(li);
        }
    }
    function displayError(err) {
        stopName.text('Error');
    }
}