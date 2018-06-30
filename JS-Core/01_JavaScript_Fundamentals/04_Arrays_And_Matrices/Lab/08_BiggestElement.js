let biggestElement = matrix => Math.max.apply(null, matrix
    .reduce((a, b) => a.concat(b)));



function bibestElementTwo(matrix) {
    let biggestNum = Number.NEGATIVE_INFINITY;
    matrix.forEach(r=>
        r.forEach(c=> biggestNum = Math.max(biggestNum, c)));
    return biggestNum;
}

console.log(bibestElementTwo([[20, 50, 10],
    [8, 33, 145]]
));