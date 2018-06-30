let solutionMine = function () {
    let products = {
        apple: {carb: 1, flavour: 2},
        coke: {carb: 10, flavour: 20},
        burger: {carb: 5, fat: 7, flavour: 3},
        omelet: {protein: 5, fat: 1, flavour: 1},
        cheverme: {protein: 10, carb: 10, fat: 10, flavour: 10},
    };
    return function manager(inputStr) {
        let commandProcessor = {
            'restock': restock,
            'prepare': prepare,
            'report': report,
        };
        let command = inputStr[0];
        switch (command) {
            case 'restock':
                commandProcessor[command](inputStr[1], inputStr[2]);
                break;
            case 'prepare':
                commandProcessor[command](inputStr[1], inputStr[2]);
                break;
            case 'report':
                commandProcessor[command];
                break;
        }

        function restock(microelement, quantity) {
            commandProcessor.toString = function () {
                return 'restock';
            }

        }

        function prepare(recipe, quantity) {
            console.log('prepare');
        }

        function report() {
            console.log('report');
        }
    }
};

let solution = function () {
    let robot = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    let products = {
        apple: {carbohydrate: 1, flavour: 2},
        coke: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        omelet: {protein: 5, fat: 1, flavour: 1},
        cheverme: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10},
    };

    return function (inputString) {
        let inputData = inputString.split(' ');
        let command = inputData[0];

        if (command === 'restock') {
            let microElement = inputData[1];
            let quantity = Number(inputData[2]);
            robot[microElement] += quantity;
            return 'Success';

        } else if (command === 'report') {
            return `protein=${robot.protein} carbohydrate=${robot.carbohydrate} fat=${robot.fat} flavour=${robot.flavour}`;

        } else if (command === 'prepare') {
            let selectedProduct = inputData[1];
            let selectedProductQuantity = Number(inputData[2]);
            let currentProductStats = products[selectedProduct];

            for (let microElement in currentProductStats) {
                if (currentProductStats.hasOwnProperty(microElement)) {
                    let microElementQuantity = currentProductStats[microElement];
                    if (robot[microElement] < microElementQuantity * selectedProduct) {

                        return `Error: not enough ${microElement} in stock`;

                    }
                }
            }

            for (let microElement in currentProductStats) {
                if (currentProductStats.hasOwnProperty(microElement)) {
                    let microElementQuantity = currentProductStats[microElement];
                    robot[microElement] -= microElementQuantity * selectedProductQuantity;
                }
            }
            return 'Success';
        }
    }
};
solution = solution();
solution('restock carbohydrate 10');
solution('restock flavour 10');
solution('prepare apple 1');
solution('restock fat 10');
solution('prepare burger 1');
solution('report');

