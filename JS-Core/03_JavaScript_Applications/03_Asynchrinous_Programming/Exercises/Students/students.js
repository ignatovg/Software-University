function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_BJXTsSi-e';
    const kinveyUsername = 'guest';
    const kinveyPassword = 'guest';
    const authHeader = {
        'Authorization': 'Basic Z3Vlc3Q6Z3Vlc3Q=',
        'Content-Type': 'application/json'
    };
    loadData();

    $('#createBtn').click(createStudent);

    function request(method, endpoint, data) {
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authHeader,
            data: JSON.stringify(data)
        });
    }

    function loadData() {
        request('GET', '/students')
            .then(displayStudents)
            .catch(handleError)
    }

    function displayStudents(data) {

        let sortedData = data.sort((a, b) => {
            return a.ID - b.ID;
        });

        let table = $('#results');

        for (let studentObj of sortedData) {

            let tr = $('<tr>');
            tr.append($(`<th>${studentObj.ID}</th>`));
            tr.append($(`<th>${studentObj.FirstName}</th>`));
            tr.append($(`<th>${studentObj.LastName}</th>`));
            tr.append($(`<th>${studentObj.FacultyNumber}</th>`));
            tr.append($(`<th>${studentObj.Grade}</th>`));

            table.append(tr);
        }

    }

    //does not work - Bad Request, ID and Grade must be numbers.
    function createStudent(event) {
        let dataObj = {
            'ID':+(('#id').val()),
            'FirstName': $('#firstName').val(),
            'LastName': $('#lastName').val(),
            'FacultyNumber': $('#faculty').val(),
            'Grade': +($('#grade').val()),
        };
        console.log(dataObj);
        request('POST', '/students', dataObj)
            .then(loadData)
            .catch(handleError);
        console.log(dataObj);
    }

    function handleError(err) {
        //  alert('ERROR');
        console.log(err);
    }
}