function attachEventsListeners() {

    document.getElementById('convert').addEventListener('click',onClick);

    function onClick(event) {
        let units = {
            'km': 1000,
            'm': 1,
            'cm': 0.01,
            'mm': 0.001,
            'mi': 1609.34,
            'yrd': 0.9144,
            'ft': 0.3048,
            'in': 0.0254,
        };
        let incomingDistance = Number(document.getElementById('inputDistance').value);
        let selectedFrom = document.getElementById('inputUnits').value;
        let selectedTo = document.getElementById('outputUnits').value;

       let result = incomingDistance * units[selectedFrom];
       result = result / units[selectedTo];

       document.getElementById('outputDistance').value = result;
    }
}