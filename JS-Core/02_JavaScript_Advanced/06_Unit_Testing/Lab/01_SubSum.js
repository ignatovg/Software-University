function subsum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr)) {
       throw new Error('Input is not an array')
    }
    if (startIndex < 0) {
        startIndex = 0;
        throw new RangeError('StartIndex is outside the bounds of array')
    }
    if (endIndex >= arr.length) {
        endIndex = arr.length - 1;
        throw new RangeError('EndIndex is outside the bounds of array')
    }

    let sum = 0;
    for (let i = startIndex; i <= endIndex; i++) {
        sum += Number(arr[i]);
    }
    return sum;
}

console.log(subsum([10, 20, 30, 40], -1, 2));//60
console.log(subsum([10, 20, 30, 40], 1, 20));//90
console.log(subsum([10, 20, 30, 40], 1, 2));//50
console.log(subsum('pesho', 3, 4));//NaN
console.log(subsum({}, 3, 4));//Nan
console.log(subsum(['10', '20', '30'], 1, 2));//50
console.log(subsum([1.1, 1.1, 1.1], -1, 20));//50
