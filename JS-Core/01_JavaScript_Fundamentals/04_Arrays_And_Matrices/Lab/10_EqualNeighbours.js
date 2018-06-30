
function equalPairsCount(matrix) {
    let pairsCount = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {

            if (matrix[row][col + 1] !== undefined && matrix[row][col + 1] === matrix[row][col]) {
                pairsCount++
            }
            if (row > 0) {

                 if (matrix[row-1][col] !== undefined && matrix[row-1][col] === matrix[row][col]) {
                    pairsCount++;
                 }
            }
        }
    }
    console.log(pairsCount);
}


equalPairsCount(
    [['2', '2', '5', '7', '4'],
        ['4', '0', '5', '3', '4'],
        ['2', '5', '5', '4', '2']]
);

console.log();

equalPairsCount([['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
);