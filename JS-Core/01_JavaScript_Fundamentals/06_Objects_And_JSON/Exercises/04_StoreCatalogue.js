function createCatalogue(strArr) {
    let catalogue = [];
    for (let row of strArr) {
         let [name, quantity] = row.split(' : ');
        catalogue.push(`${name}: ${quantity}`);
    }
    catalogue.sort(compare);

    //print
    let char = catalogue[0][0];
    console.log(char);
    for (let str of catalogue) {
        if (char !== str[0]) {
            char = str[0];
            console.log(char);
        }
        console.log(`  ${str}`);
    }

    function compare(a, b) {
        a = a.toLowerCase();
        b = b.toLowerCase();
        if (a < b) {
            return -1;
        }
        if (a > b) {
            return 1;
        }
        return 0;
    }
}

function secondSolution(strArr) {
    let catalogue = [];
    for (let row of strArr) {
        let [name, quantity] = row.split(' : ');
        catalogue.push({name: name, quantity: quantity});
    }
    catalogue.sort(compare);

    //print
    let char = catalogue[0].name[0];
    console.log(char);
    for (let obj of catalogue) {

        if (char !== obj.name[0]) {
            char = obj.name[0];
            console.log(char);
        }
        console.log(`  ${obj.name}: ${obj.quantity}`);
    }

    function compare(a, b) {
        a = a.name.toLowerCase();
        b = b.name.toLowerCase();
        if (a < b) {
            return -1;
        }
        if (a > b) {
            return 1;
        }
        return 0;
    }
}

secondSolution([
    `Banana : 2`,
    `Rubic's Cube : 5`,
    `Raspberry P : 4999`,
    `Rolex : 100000`,
    `Rollon : 10`,
    `Rali Car : 2000000`,
    `Pesho : 0.000001`,
    `Barrel : 10`,

]);