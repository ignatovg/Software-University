function solve(inputArr, sortMethod) {

    let ascendingComparator = function (a, b) {
        return a - b;
    };

    let descendingComparator = function (a, b) {
        return b - a;
    };

    let sortingStrategies = {
        'asc': ascendingComparator,
        'desc': descendingComparator,
    };
    return inputArr.sort(sortingStrategies[sortMethod]);
}

function sortArray(array, orderType) {
    if (orderType === 'asc') {
        return (array.sort((a, b) => a - b));
    } else {
        return (array.sort((a, b) => b - a));
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log();
console.log(solve([14, 7, 17, 6, 8], 'desc'));