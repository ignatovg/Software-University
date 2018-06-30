function aggregate(arr) {
    let tokens = [];
    let tows = [];
    let incomes = 0;
    for (let i = 0; i < arr.length; i++) {
        tokens = arr[i].split('|');
        tows.push(tokens[1].trim());
        incomes += Number(tokens[2]);
    }

    console.log(tows.join(', '));
    console.log(incomes);
}

aggregate(
    ['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);