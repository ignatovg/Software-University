function assembleCar(inputCar) {
    let storage = {
        smallEngine: {power: 90, volume: 1800},
        normalEngine: {power: 120, volume: 2400},
        monsterEngine: {power: 200, volume: 3500},

    };
    let carriageStorage = {
        hatchback: {type: 'hatchback', color: ''},
        coupe: {type: 'coupe', color: ''}
    };

    let newCar = {};

    newCar['model'] = inputCar.model;
    newCar['engine'] = pickEngine(inputCar.power);
    newCar['carriage'] = pickCarriage(inputCar.carriage, inputCar.color);
    newCar['wheels'] = pickWheels(inputCar.wheelsize);

    return newCar;

    function pickWheels(wheelsSize) {
        let wheelsArr = [];
        wheelsSize = Math.floor(wheelsSize);
        if (wheelsSize % 2 === 0) {
            wheelsSize--;
        }
        for (let i = 0; i < 4; i++) {
            wheelsArr.push(wheelsSize);
        }
        return wheelsArr;
    }

    function pickCarriage(carriage, color) {
        let result = carriageStorage[carriage];
        result['color'] = color;

        return result;
    }

    function pickEngine(currentPower) {
        if (currentPower <= storage.smallEngine.power) {
            return storage.smallEngine;
        } else if (currentPower <= storage.normalEngine.power) {
            return storage.normalEngine;
        } else {
            return storage.monsterEngine;
        }
    }
}

function assembleCarLecturer(initialCarParts) {
    let modifiedCar = {};
    let engine;

    if (initialCarParts.power <= 90) {
        engine = {
            power: 90,
            volume: 1800
        }
    } else if (initialCarParts.power <= 120) {
        engine = {
            power: 120,
            volume: 2400
        }
    } else if (initialCarParts.power <= 200) {
        engine = {
            power: 200,
            volume: 3500
        }
    }

    let wheels = [];
    if(initialCarParts.wheelsize % 2 ===0){
        initialCarParts.wheelsize--;
    }

    for (let i = 0; i < 4; i++) {
        wheels.push(initialCarParts.wheelsize)
    }

    modifiedCar.model = initialCarParts.model;
    modifiedCar.engine = engine;
    modifiedCar.carriage = {
        type: initialCarParts.carriage,
        color: initialCarParts.color,
    };
    modifiedCar.wheels = wheels;
    return modifiedCar
}

assembleCarLecturer(
    {
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
);
console.log();
assembleCar(
    {
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
);