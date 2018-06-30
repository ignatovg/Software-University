function timer() {
    $('#start-timer').click(startTimer);
    $('#stop-timer').click(stopTimer);

    let timer = null;
    let seconds = 0;
    let minutes = 0;
    let hours = 0;

    function stopTimer(event) {
        clearInterval(timer);
        timer = null;
    }

    function startTimer(event) {
        if (timer === null) {
            timer = setInterval(moveSeconds, 1000);
        }
    }

    function moveSeconds() {
        seconds += 1;
        if (seconds === 60) {
            minutes++;
            seconds = 0;
        }
        if(minutes === 60){
            hours++;
            minutes = 0;
        }
        $('#hours').text((Array.from('0' + hours)).splice(-2).join(''));
        $('#minutes').text((Array.from('0' + minutes)).splice(-2).join(''));
        $('#seconds').text((Array.from('0' + seconds)).splice(-2).join(''));
    }
}