function solve() {
    let stopId = 'depot';
    let baseUrl = 'https://judgetests.firebaseio.com/schedule';
    let stopName = '';


    function depart() {

        let req = {
            method: 'GET',
            url: `${baseUrl}/${stopId}.json`,
            success: displayData,
            error: displayError,
        };
        $.ajax(req);
    }

    function arrive() {
        $('#info .info').text(`Arriving at ${stopName}`);

        $('#depart').prop('disabled', false);
        $('#arrive').prop('disabled', true);
    }

    function displayData(data) {
        stopName = data.name;

        $('#info .info').text(`Next stop ${stopName}`);
        stopId = data.next;
        $('#depart').prop('disabled', true);
        $('#arrive').prop('disabled', false);
    }

    function displayError(err) {
        $('#info .info').text(`Error`);
        $('#depart').prop('disabled', true);
        $('#arrive').prop('disabled', true);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();