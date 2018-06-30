function printSquare(count = 5) {

    for (let i = 0; i < count; i++) {
        console.log(printStar(count));
    }

    function printStar(size) {
        return '* '.repeat(size);
    }
}

printSquare();