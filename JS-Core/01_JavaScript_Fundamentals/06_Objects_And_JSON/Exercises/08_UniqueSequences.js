function solve(inputArr) {
    let result = [];
    for (let i = 0; i < inputArr.length; i++) {
        let currentRow = JSON.parse(inputArr[i])
            .map(Number)
            .sort((a, b) => b - a);
        let currentSum = currentRow.reduce((a, b) => a + b);

        if (!result.find(ar => ar.reduce((a, b) => a + b) === currentSum)) {
            result.push(currentRow);
        }
    }
    result.sort((a, b) => a.length - b.length)
        .forEach(arr => console.log(`[${arr.join(', ')}]`));
}

function secondSolve(inputArr) {
    let uniqueSequence = [];
    for (let dataRow of inputArr) {
        let numArr = JSON.parse(dataRow)
            .map(Number)
            .sort(sortByDescending);
        let curSum = numArr.reduce((a, b) => a + b);

        if (uniqueSequence
            .find(arr => arr
                .reduce((a, b) => a + b) === curSum)) {
            uniqueSequence.push(numArr);
        }
    }
    uniqueSequence.sort((a,b) => a.length > b.length);


    function sortByDescending(a, b) {
        return b - a;
    }
}

secondSolve([
    '[-3, -2, -1, 0, 1, 2, 3, 4]',
    '[10, 1, -17, 0, 2, 13]',
    '[4, -3, 3, -2, 2, -1, 1, 0]',
]);