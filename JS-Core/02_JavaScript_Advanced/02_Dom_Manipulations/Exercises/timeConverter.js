function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', clickedDays);
    document.getElementById('hoursBtn').addEventListener('click', clickedHours);
    document.getElementById('minutesBtn').addEventListener('click', clickedMinutes);
    document.getElementById('secondsBtn').addEventListener('click', clickedSeconds);

    function clickedDays() {
        let daysInput = Number(document.getElementById('days').value);

        document.getElementById('hours').value = daysInput * 24;
        document.getElementById('minutes').value = daysInput * 24 * 60;
        document.getElementById('seconds').value = daysInput * 24 * 60 * 60;
    }

    function clickedHours() {
        let hoursInput = Number(document.getElementById('hours').value);

        document.getElementById('days').value = hoursInput / 24;
        document.getElementById('minutes').value = hoursInput * 60;
        document.getElementById('seconds').value = hoursInput * 60 * 60;
    }

    function clickedMinutes() {
        let minutesInput = Number(document.getElementById('minutes').value);

        document.getElementById('days').value = minutesInput / 24 / 60;
        document.getElementById('hours').value = minutesInput / 60;
        document.getElementById('seconds').value = minutesInput * 60 ;
    }

    function clickedSeconds() {
        let secondsInput = Number(document.getElementById('seconds').value);

        document.getElementById('days').value = secondsInput / 24 / 60 / 60;
        document.getElementById('hours').value = secondsInput / 60 / 60;
        document.getElementById('minutes').value = secondsInput / 60 ;
    }
}