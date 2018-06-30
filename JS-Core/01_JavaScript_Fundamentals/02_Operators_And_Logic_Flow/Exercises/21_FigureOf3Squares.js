function printSquare(n) {
    let length = n % 2 === 0 ? n - 1 : n;

    let result = '';

    if (length <= 3) {
        let dash = '-'.repeat(n - 2);
        result += `+${dash}+${dash}+\n`;
        result += `+${dash}+${dash}+\n`;
        result += `+${dash}+${dash}+\n`;

        return result;
    }

    let dash = '-'.repeat(n - 2);

    //top
    result += `+${dash}+${dash}+\n`;

    //middle
    for (let row = 1; row <= length - 2; row++) {
        if (Number.parseInt(length / 2) === row) {
            result += `+${dash}+${dash}+\n`;
            continue;
        }

        let space = ' '.repeat(n - 2);
        result += `|${space}|${space}|${space}\n`;

    }
    //bottom
    result += `+${dash}+${dash}+\n`;

    return result;
}


//console.log(printSquare(4));
console.log(printSquare(6));
//console.log(printSquare(6));
//console.log(printSquare(7));