function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_ryVnrbHV7';
    const kinveyUsername = 'joro';
    const kinveyPassword = 'joro';
    const base64 = btoa(`${kinveyUsername}:${kinveyPassword}`);
    const authHeader = {
        'Authorization': `Basic ${base64}`,
        'Content-type': 'application/json'
    };

    $('.load').click(loadAllCatches);
    $('.add').click(createCatch);

    function request(method, endpoint, data) {
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authHeader,
            data: JSON.stringify(data)
        });
    }

    //AJAX request to load all catches
    function loadAllCatches() {
        request('GET', '/biggestCatches')
            .then(displayAllCatches)
            .catch(handleError)
    }


    function displayAllCatches(data) {

        let catches = $('#catches');
        catches.empty();

        for (let el of data) {
            let divCatch = ($(`<div class="catch" data-id="${el._id}"></div>`));
            divCatch.append($('<label>Angler</label>'));
            divCatch.append($(`<input type="text" class="angler" value="${el['angler']}">`));
            divCatch.append($('<label>Weight</label>'));
            divCatch.append($(`<input type="number" class="weight" value="${Number(el['weight'])}">`));
            divCatch.append($('<label>Species</label>'));
            divCatch.append($(`<input type="text" class="species" value="${el['species']}"/>`));
            divCatch.append($('<label>Location</label>'));
            divCatch.append($(`<input type="text" class="location" value="${el['location']}"/>`));
            divCatch.append($('<label>Bait</label>'));
            divCatch.append($(`<input type="text" class="bait" value="${el['bait']}"/>`));
            divCatch.append($('<label>Capture Time</label>'));
            divCatch.append($(`<input type="number" class="captureTime" value="${el['captureTime']}"/>`));
            divCatch.append($(`<button class="update">Update</button>`).click(updateCatch));
            divCatch.append($(`<button class="delete">Delete</button>`).click(deleteCatch));

            catches.append(divCatch);
        }
    }

    //AJAX request to update a catch
    function updateCatch(event) {
        let catchEl = $(this).parent();
        let dataObj = createDataJSON(catchEl);

        request('PUT',`/biggestCatches/${catchEl.attr('data-id')}`,dataObj)
            .then(loadAllCatches)
            .catch(handleError)
    }


    //AJAX request to delete a catch
    function deleteCatch(event) {
        let catchID = $(this).parent().attr('data-id');
        request('DELETE',`/biggestCatches/${catchID}`)
            .then(loadAllCatches)
            .catch(handleError)
    }

    //AJAX request to create a catch
    function createCatch() {
        let catchEL = $("#addForm");
        let dataObj = createDataJSON(catchEL);

        request('POST','/biggestCatches',dataObj)
            .then(loadAllCatches)
            .catch(handleError);

    }
    
    function createDataJSON(catchEl) {
        return {
            angler: catchEl.find('.angler').val(),
            weight: +catchEl.find('.weight').val(),
            species: catchEl.find('.species').val(),
            location: catchEl.find('.location').val(),
            bait: catchEl.find('.bait').val(),
            captureTime: +catchEl.find('.captureTime').val(),
        };
    }

    function handleError(err) {
    alert(`ERROR: ${err.statusText}`)
    }

}