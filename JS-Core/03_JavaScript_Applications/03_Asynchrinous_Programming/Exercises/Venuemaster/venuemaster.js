function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com';
    const base64 = btoa('guest:pass');
    const authHeaders = {
        'Authorization': 'Basic ' + base64,
        'Content-Type': 'application/json',
    };

    $('#getVenues').click(getVenues);

    function request(method,endpoint,data) {
        return $.ajax({
            method:method,
            url:baseUrl+endpoint,
            headers:authHeaders,
            data:data,
        })
    }

    function getVenues(event) {
        let venueInput = $('#venueDate').val();

        request('POST',`/rpc/kid_BJ_Ke8hZg/custom/calendar?query=${venueInput}`)
            .then(getIds)
            .catch(handleError);

    }

    function getIds(data) {
        for (let key of data) {
            request('GET',`/appdata/kid_BJ_Ke8hZg/venues/${key}`)
                .then(displayData)
                .catch(handleError);
        }
    }

    function displayData(data) {
        let venueInfoDiv = $('#venue-info');
        venueInfoDiv.append($(`<div class="venue" id="${data._id}">`))
            .append($(`<span class="venue-name"><input class="info" type="button" value="More info">${data.name}</span>`).click(displayInfo))
            .append($(`<div class="venue-details" style="display: none;">`)
                .append($(`<table>`)
                    .append($(`<tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>`))
                    .append($(`<tr>`)
                        .append($(`<td class="venue-price">${data.price} lv</td>`))
                        .append($(`<td><select class="quantity">`)
                            .append($(`<option value="1">1</option>`))
                            .append($(`<option value="2">2</option>`))
                            .append($(`<option value="3">3</option>`))
                            .append($(`<option value="4">4</option>`))
                            .append($(`<option value="5">5</option>`)))
                        .append($(`</select></td>`))
                        .append($(`<td><input class="purchase" type="button" value="Purchase"></td>`).click(buyTickets)))
                    .append($(`</tr>`)))
                .append($(`</table>`))
                .append($(`<span class="head">Venue description:</span>`))
                .append($(`<p class="description">${data.description}</p>`))
                .append($(`<p class="description">Starting time: ${data.startingHour}</p>`)))
            .append($(`</div>`))
    }

    function displayInfo(event) {
        //hide all divs with class venue-details
        $(this).parent().find('.venue-details').css('display','none');
        //display only clicked div
       $(this).next().css('display','')

      // let venueDetails = $(this).parent().find('.venue-details');
      // venueDetails.css('display','')
    }

    function buyTickets(event) {
       let venueInfo = $('#venue-info');
       venueInfo.empty();
       //TODO buy tickets
    }
    function handleError(err) {
        alert('ERROR');
        console.log(err);
    }

}