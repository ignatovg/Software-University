function sumByTown(strArr) {
    let towns = {};
    for (let i = 0; i < strArr.length; i += 2) {
        let city = strArr[i];
        let income = Number(strArr[i + 1]);

        if (!towns.hasOwnProperty(city)) {
            towns[city] = 0;
        }
        towns[city] += income;
    }

    return JSON.stringify(towns);
}

sumByTown([
    'Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4'
]);