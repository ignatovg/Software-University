function solve(dataRows) {
    let matrix = [];
    for (let i = 0; i < dataRows.length - 1; i++) {
        matrix.push(dataRows[i].split(' ').map(Number));
    }

    let coordinates = dataRows[dataRows.length - 1].split(' ');
    let bunnyDamage = 0;
    let bunnyKills = 0;
    for (let token of coordinates) {
        let [row, col] = token.split(',').map(Number);
        if (matrix[row][col] > 0) {
            bunnyDamage += matrix[row][col];
            bunnyKills++;
            explode(row, col, matrix);
        }

    }

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if(matrix[row][col] > 0){
                bunnyDamage += matrix[row][col];
                bunnyKills++;
            }
        }
    }
    console.log(bunnyDamage);
    console.log(bunnyKills);
    console.log(matrix.map(row => row.join(' ')).join('\n'));
    function explode(row, col, matrix) {
        /*
        let startRow = Math.max(0,row - 1);
        let endRow = Math.min(matrix.length, row + 1);
        let startCol = Math.max(0, col - 1);
        let endCol = Math.min(matrix.length, col - 1);
        */
        let bunnyDamage = matrix[row][col];
        for (let i = row - 1; i <= row + 1; i++) {
            for (let j = col - 1; j <= col + 1; j++) {
                if (isInside(i, j, matrix)) {
                    matrix[i][j] -= bunnyDamage;
                }
            }
        }
    }

    function isInside(row, col, matrix) {
        return row >= 0 && row < matrix.length
            && col >= 0 && col < matrix[row].length;
    }
}

solve([
    '10 10 10',
    '10 10 10',
    '10 10 10',
    '0,0'
]);