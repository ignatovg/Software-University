function attachGradientEvents() {
    document.getElementById('gradient').addEventListener('mousemove', onClick);
    document.getElementById('gradient').addEventListener('mouseout', mouseOut);

    function mouseOut() {
        document.getElementById('result').textContent = '0' + '%';
    }

    function onClick(event) {
        console.log(event);
        let x = event.offsetX;
        let percent = Math.floor((x / 300) * 100);
       document.getElementById('result').textContent = percent + '%';
    }
}

function attachGradientEventsLecturer() {
    document.getElementById('gradient').addEventListener('click', onClick);

    function onClick(event) {
        let x = event.offsetX;
        let percent = (x / this.clientWidth) * 100;
        document.getElementById('result').textContent = percent.toFixed(0) + '%';
    }
}