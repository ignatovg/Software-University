function attachEvents() {
    let baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook';
    let phonebookUl = $('#phonebook');

    $('#btnLoad').click(loadData);
    $('#btnCreate').click(createData);

    function loadData() {
        phonebookUl.empty();

        let req = {
            method: 'GET',
            url: baseUrl + '.json',
            success: displayData,
            error: displayError
        };
        $.ajax(req);
    }

    function createData() {
        let personInput = $('#person');
        let phoneInput = $('#phone');

        let dataToSend = {
            person: personInput.val(),
            phone: phoneInput.val()
        };

        let req = {
            method:'POST',
            url:baseUrl+'.json',
            data: JSON.stringify(dataToSend),
            contentType: 'application/json',
            success: loadData,
            error: displayError,
        };
        $.ajax(req);

        personInput.val('');
        phoneInput.val('');
    }

    function displayData(data) {
        for (let key in data) {
            let li = $(`<li>${data[key]['person']}: ${data[key]['phone']} </li>`);
            li.append($('<button>[Delete]</button>').click(() => deleteItem(key)));
            phonebookUl.append(li);
        }
    }

    function displayError(err) {
        phonebookUl.append($('<span>`Error`</span>'))
    }

    function deleteItem(key) {
        let req ={
            method:'DELETE',
            url:`${baseUrl}/${key}.json`,
            success:loadData,
            error:displayError
        };
        $.ajax(req);
    }
}