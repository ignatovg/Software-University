function cookByNumbers(inputArr) {

    let calc = (a, op) => op(a);
    let chop = num => num / 2;
    let dice = num => Math.sqrt(num);
    let spice = num => num + 1;
    let bake = num => num * 3;
    let fillet = num => num - (num * 0.20);

    let startingNum = inputArr[0];

    for (let i = 1; i < inputArr.length; i++) {
        startingNum = returnCommand(startingNum,i);
        console.log(startingNum);
    }

    function returnCommand(startingNumber, possition) {
        switch (inputArr[possition]) {
            case 'chop':
                return calc(startingNumber, chop);
            case 'dice':
                return calc(startingNumber, dice);
            case 'spice':
                return calc(startingNumber, spice);
            case 'bake':
                return calc(startingNumber, bake);
            case 'fillet':
                return calc(startingNumber, fillet);
        }
    }
}

//cookByNumbers([32, 'chop', 'chop', 'chop', 'chop', 'chop']);
cookByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);