function concatAndReverse(arr) {
    let result = arr.join('').split('').reverse().join('');
    console.log(result);
}

concatAndReverse(['I', 'am', 'student']);