function attachEvents() {

    $('#submit').click(function (event) {
        let locationInput = $('#location');
        let forecastDiv = $('#forecast');
        let currentCondition = $('#current');
        let upcoming = $('#upcoming');

        $.get('https://judgetests.firebaseio.com/locations.json')
            .then(getLocationData)
            .catch(displayError);


        function getLocationData(data) {
            let isCode= false;

            for (let obj of data) {
                if (obj.name === locationInput.val()) {
                    forecastDiv.css('display', '');
                    getWeather(obj.code);
                    getThreeDayForecastWeather(obj.code);
                    isCode=true;
                    return;
                }
            }
             if(!isCode){
                 displayError();
             }

            function getThreeDayForecastWeather(code) {
                $.get(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
                    .then(displayTheeDaysWeather)
                    .catch(displayError);

                function displayTheeDaysWeather(data) {
                    upcoming.empty();

                    //append title
                    upcoming.append($('<div class="label">Three-day forecast</div>'));
                    for (let objRow of data.forecast) {
                        console.log(objRow);

                        let upcomingSpan = $('<span class="upcoming"></span>');

                        //append symbol
                        upcomingSpan.append($(`<span class="symbol">${getSymbols(objRow.condition)}</span>`));

                        //append degrees
                        upcomingSpan.append($(`<span class="forecast-data">${objRow.high}${getSymbols('Degrees')}/${objRow.low}${getSymbols('Degrees')}</span>`));

                        //append weather
                        upcomingSpan.append($(`<span class="forecast-data">${objRow.condition}</span>`));

                        //append upcomingSpan to upcoming div
                        upcoming.append(upcomingSpan);
                    }
                }
            }

            function getWeather(code) {
                $.get(`https://judgetests.firebaseio.com/forecast/today/${code}.json`)
                    .then(displayWeather)
                    .catch(displayError);

                function displayWeather(data) {

                    currentCondition.empty();

                    //append condition symbol
                    currentCondition.append($(`<span class="condition symbol">${getSymbols(data.forecast.condition)}</span>`));

                    //append condition
                    let spanCondition = $('<span class="condition"></span>');

                    //append city's name
                    spanCondition.append($(`<span class="forecast-data">${data.name}</span>`));

                    //append degrees
                    let degree = data.forecast;
                    spanCondition.append($(`<span class="forecast-data">${degree.high}${getSymbols('Degrees')}/${degree.low}${getSymbols('Degrees')}</span>`));

                    //append weather
                    spanCondition.append($(`<span class="forecast-data">${data.forecast.condition}</span>`));

                    //append spanCondition to currentCondition
                    currentCondition.append(spanCondition);
                }
            }

            function getSymbols(symbol) {
                let symbols = {
                    'Sunny': '&#x2600;', // ☀
                    'Partly sunny': '&#x26C5;', // ⛅
                    'Overcast': '&#x2601;', // ☁
                    'Rain': '&#x2614;', // ☂
                    'Degrees': '&#176;',   // °
                };
                return symbols[symbol];
            }

        }

        function displayError(err) {
            let forecast = $('#forecast');
            forecast.css('display','');
            forecast.empty();
            forecast.text('Error');
            console.log('error');
        }
    })
}