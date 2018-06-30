function isMagicMatrix(matrix) {

    let rowsSum = 0;
    let currentColSum = 0;

    for (let row = 0; row < matrix.length; row++) {
       rowsSum += matrix[row][0];
    }

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix.length; col++) {
            currentColSum+=matrix[row][col];
        }
        if(rowsSum !== currentColSum){
            return false;
        }
        currentColSum = 0;
    }
    return true;
}

function solve(input){
    let sumRow  = input[0].reduce((a,b) => a+b);

    for (let row = 0; row < input.length; row++) {
        let sumCol = 0;
        for (let col = 0; col < input.length; col++) {
            sumCol += input[row][col];
        }

        if (sumCol !== sumRow){
            console.log(false);
            return;
        }

    }
    console.log(true);
}

console.log(solve(
    [[11, 32, 45],
        [21, 0, 1],
        [21, 1, 1]]

));