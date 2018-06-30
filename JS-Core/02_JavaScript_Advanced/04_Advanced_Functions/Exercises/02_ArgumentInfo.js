function result() {
    let summary = new Map();
    for (let i = 0; i < arguments.length; i++) {
        let obj = arguments[i];
        let type = typeof obj;
        console.log(type + ': ' + obj);

        if (!summary.has(type)) {
            summary.set(type, 0);
        }
        summary.set(type, summary.get(type) + 1)
    }

    let sortedArr = [...summary].sort((a, b) => b[1] - a[1]);
    for (let elem of sortedArr) {
        console.log(`${elem[0]} = ${elem[1]}`);
    }
}

result('cat', 42, function () {
    console.log('Hello world!');
});