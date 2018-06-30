function printTriangle(n) {
    for (let i = 1; i <= n; i++) {
        console.log(printStar(i));
    }

    for (let i = n - 1; i >= 0; i--) {
        console.log(printStar(i));
    }

    function printStar(count) {
        return '*'.repeat(count);
    }
}

function printStar(count) {
    return '*'.repeat(count);
}

printTriangle(1);