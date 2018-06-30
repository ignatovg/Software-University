function calculateSales(strArr) {
    let towns = new Map();

    for (let row of strArr) {
        let [city, product, sales] = row.split(' -> ');
        let [amount, price] = sales.split(' : ');

        if (!towns.has(city)) {
            towns.set(city, new Map());
        }
        if (!towns.get(city).has(product)) {
            towns.get(city).set(product, 0);
        }
        let oldIncome = towns.get(city).get(product);
        towns.get(city).set(product, oldIncome + amount * price);
    }

    for (let kvp of towns) {
        console.log(`Town - ${kvp[0]}`);
        for (let [product,sales] of kvp[1]) {
            console.log(`$$$${product} : ${sales}`);
        }
    }
}

calculateSales([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3',

]);