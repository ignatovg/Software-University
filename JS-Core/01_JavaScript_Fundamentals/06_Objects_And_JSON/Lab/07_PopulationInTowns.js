function calculatePopulation(strArr) {

    let towns = new Map();
    for (let row of strArr) {
        let [city, population] = row.split(' <-> ');
        if(!towns.has(city)){
            towns.set(city,0)
        }
        towns.set(city, towns.get(city) + Number(population));
    }

    for (let [city, pop] of towns) {
        console.log(`${city} : ${pop}`);
    }
}

calculatePopulation([
'Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']

)