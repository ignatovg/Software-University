function quadraticEquation(a, b, c) {
    let d = b * b - 4 * a * c;

    if (d > 0) {
        let x1 = (-b + Math.sqrt(d)) / (2 * a);
        let x2 = (-b - Math.sqrt(d)) / (2 * a);

        console.log(Math.min(x1, x2));
        console.log(Math.max(x1, x2));

    } else if (d === 0) {
        let x12 = -b / (2 * a);
        console.log(x12);

    } else if (d < 0) {
        console.log('No');
    }
}

quadraticEquation([6, 11, -35]);
quadraticEquation([1, -12, 36]);
quadraticEquation([5, 2, 1]);