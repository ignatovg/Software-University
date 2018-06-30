function isOddOrEven(number) {
    if (!Number.isInteger(number)) {
        console.log('undefined');
    }
    else {
        let oddOrEven = number % 2 === 0 ? 'even' : 'odd';
        console.log(oddOrEven);
    }
}

isOddOrEven(5);
isOddOrEven(8);
isOddOrEven(8.3);
isOddOrEven('k');
