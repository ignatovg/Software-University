let result = (function solve() {
    let currentID = 'depot';
    let name ='';

    function depart() {
        let req = {
            method: 'GET',
            url: `https://judgetests.firebaseio.com/schedule/${currentID}.json`,
            success: departBus,
            error: displayError,
        };
        $.ajax(req);
    }

    function displayError(err) {
        $('#info .info').text(`Error`);
        $('#depart').prop('disabled',true);
        $('#arrive').prop('disabled',true);
    }
    function departBus(stopInfo) {
        name = stopInfo.name;
        $('#info .info').text(`Next stop ${name}`);
        currentID = stopInfo.next;
        $('#depart').prop('disabled',true);
        $('#arrive').prop('disabled',false);
    }

    function arrive() {
        $('#info .info').text(`Arriving at ${name}`);
        $('#depart').prop('disabled',false);
        $('#arrive').prop('disabled',true);
    }

    return {
        depart,
        arrive
    };

})();
