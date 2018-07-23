function attachEvents() {
    let baseUrl = 'https://messenger-f2368.firebaseio.com/messenger.json';
    let messagesArea = $('#messages');
    let authorInput = $('#author');
    let messagesInput = $('#content');
    $('#submit').click(sendInformation);
    $('#refresh').click(() => loadData());


    function loadData() {
        let req = {
            method: 'GET',
            url: baseUrl,
            success: displayData,
            error: displayError,
        };
        $.ajax(req);

        authorInput.val('');
        messagesInput.val('');
    }


    function displayData(data) {

        let result = '';
        for (let key in data) {
            result += (`${data[key]['author']}: ${data[key]['content']}\n`);
        }
        messagesArea.text(result.trim());
    }

    function displayError(err) {
        messagesArea.text('Error');
    }

    function sendInformation(event) {
        let dataToSend = {
            author:authorInput.val(),
            content:messagesInput.val(),
            timestamp: Date.now()
        };
        let req = {
            method: 'POST',
            url: baseUrl,
            contentType:'application/json',
            data: JSON.stringify(dataToSend),
            success: loadData(),
            error: displayError,
        };
        $.ajax(req);
        console.log();
        console.log(messagesInput.val());
    }
}