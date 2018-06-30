function townsToJSON(strArr) {
    strArr.shift();
    let towns = [];
    for (let row of strArr) {
        let [city, latitude, longitude] = row.split('|')
            .filter(e => e !== '')
            .map(e => e.trim());

        let town = {
            Town: city,
            Latitude: Number(latitude),
            Longitude: Number(longitude)
        };
        towns.push(town);
    }
    return JSON.stringify(towns);
}

console.log(townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));
;