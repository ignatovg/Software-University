function attachEvents() {
    let inputValue = $('#townName');
    let towns = $('#towns option');
    $('#btnDelete').on('click',function (event) {
        let isDeleted = false;

        for (let town of towns) {
            console.log(town.text);
            if(town.text === inputValue.val()){
                town.remove();
                isDeleted =true;
            }
        }
        if(isDeleted){
            $('#result').text(`${inputValue.val()} deleted.`);
        }else {
            $('#result').text(`${inputValue.val()} not found.`);
        }
        $('#townName').val('');
    })
}

function attachEventsAuthor() {
    $('#btnDelete').click(function() {
        let townName = $('#townName').val();
        $('#townName').val('');
        let found = false;
        for (let option of $('#towns option'))
            if (option.textContent == townName) {
                found = true;
                option.remove();
            }
        if (found)
            $('#result').text(townName + " deleted.");
        else
            $('#result').text(townName + " not found.");
    });
}