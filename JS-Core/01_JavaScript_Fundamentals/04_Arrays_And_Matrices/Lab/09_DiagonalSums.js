function getDiagonalSums(matrix) {
    let mainSum = 0, secondarySum = 0;
    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix.length - 1 - row];
    }
    console.log(`${mainSum} ${secondarySum}`);
}

getDiagonalSums([[20, 40],
    [10, 60]]
);