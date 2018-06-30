function townsToJSON(strArr) {
    strArr.shift();
    let towns = [];
    for (let row of strArr) {
        let townTokens = row.split('|')
            .filter(e => e !== '')
            .map(e => e.trim());

        let town = {
            Town: townTokens[0],
            Latitude: Number(townTokens[1]),
            Longitude: Number(townTokens[2])
        }
        towns.push(town);
    }
    return JSON.stringify(towns);
}

//console.log(townsToJSON(['| Town | Latitude | Longitude |',
//    '| Sofia | 42.696552 | 23.32601 |',
//    '| Beijing | 39.913818 | 116.363625 |']
//));

function scoreToHTML(json) {
    let html = '<table>\n';
    html += '  <tr><th>name</th><th>score</th></tr>\n';

    let scores = JSON.parse(json);

    for (let score of scores) {
        html += '   <tr>';
        html += `<td>${score.name}</td>`;
        html += `<td>${score.score}</td>`;

        html += '</tr>\n';
    }

    html += '</table>';
    console.log(html);
}

// scoreToHTML('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');

function sumTowns(strArr) {
    let towns = {};

    for (let i = 0; i < strArr.length; i += 2) {
        let town = strArr[i];
        let value = Number(strArr[i + 1]);
        if (!towns.hasOwnProperty(town)) {
            towns[town] = 0;
        }
        towns[town] += value;
    }

    console.log(JSON.stringify(towns));
}

//sumTowns(['Sofia', '20','Varna','3','Sofia','5','Varna','4']);

function townPopulation(strArr) {
    let towns = new Map();
    for (let row of strArr) {
        let [name, pop] = row.split(' <-> ');
        if (!towns.has(name)) {
            towns.set(name, 0);
        }
        towns.set(name, towns.get(name) + Number(pop));
    }
    [...towns].forEach(([town, pop]) => console.log(`${town} : ${pop}`))
}

//townPopulation(['Sofia <-> 1200000','Montana <-> 20000','New York <-> 10000000','Washington <-> 2345000','Las Vegas <-> 1000000']);


function cityMarkets(strArr) {
    let summary = new Map();

    for (let row of strArr) {
        let [town, product, sales] = row.split(' -> ');
        sales = sales.split(' : ').reduce((a, b) => a * b);
        //verify town exists
        if (!summary.has(town)) {
            summary.set(town, new Map());
        }
        //verify product exists
        if (!summary.get(town).has(product)) {
            summary.get(town).set(product, 0)
        }
        let oldSales = summary.get(town).get(product);
        summary.get(town).set(product, oldSales + sales);
    }

    for (let [town, products] of summary) {
        console.log(`Town - ${town}`);
        for (let [product, sales] of products) {
            console.log(`$$$${product} : ${sales}`);
        }
    }
}

// cityMarkets([
//     'Sofia -> Laptops HP -> 200 : 2000',
//     'Sofia -> Raspberry -> 200000 : 1500',
//     'Sofia -> Audi Q7 -> 200 : 100000',
//     'Montana -> Portokals -> 200000 : 1',
//     'Montana -> Qgodas -> 20000 : 0.2',
//     'Montana -> Chereshas -> 1000 : 0.3',
//     'Montana -> Chereshas -> 100 : 45',
//]);

function uniqueWords(strArr) {
    let unique = new Set();
    let text = strArr.join('\n');
    let words = text.split(/\W+/)
        .filter(e => e !== '')
        .map(e => e.toLowerCase())
        .forEach(e => unique.add(e));

    console.log([...unique].join(', '));
}