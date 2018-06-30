function solve(inputStr) {
    let countriesMap = new Map();

    for (let line of inputStr) {
        let [country, town, cost] = line.split(' > ');
        cost = Number(cost);
        town = capitalizeFirstLetter(town);

        if (!countriesMap.has(country)) {
            countriesMap.set(country, new Map());
        }
        if (!countriesMap.get(country).has(town)) {
            countriesMap.get(country).set(town, cost);
        }
        let oldCost = countriesMap.get(country).get(town);
        if (oldCost > cost) {
            countriesMap.get(country).set(town, cost);
        }
    }

    let sortedMap = [...countriesMap.entries()].sort((a, b) => {
        let alphabeticalDiff = a[0].localeCompare(b[0]);

        return alphabeticalDiff;
    });


    for (let [country,value] of sortedMap) {
        let result = `${country} ->`;

        let sortTowns = [...value.entries()].sort((a,b)=> {
            return a[1] - b[1];
        });
        for (let [town,cost] of sortTowns) {
            result +=` ${town} -> ${cost}`
        }

        console.log(result);
    }

    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }
}

solve(
    ["Bulgaria > Sofia > 500",
        "Bulgaria > Sopot > 800",
        "France > Paris > 2000",
        "Albania > Tirana > 1000",
        "Bulgaria > Sofia > 200" ]


);

//Albania -> Tirana -> 1000
//Bulgaria -> Sofia -> 200 Sopot -> 800
//France -> Paris -> 2000
