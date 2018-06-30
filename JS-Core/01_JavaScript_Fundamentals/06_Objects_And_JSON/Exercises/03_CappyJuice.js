function makeJuiceBottles(strArr) {
    let juices = new Map();
    let bottles = new Map();

    for (let row of strArr) {
        let juiceTokens = row.split(' => ');
        let juiceName = juiceTokens[0];
        let juiceQuantity = Number(juiceTokens[1]);

        if (!juices.has(juiceName)) {
            juices.set(juiceName, 0);
        }
        let oldQuantity = juices.get(juiceName);
        juices.set(juiceName, oldQuantity + juiceQuantity);

        //check for bottles
        if(juices.get(juiceName) >= 1000){
            let bottle = parseInt(juices.get(juiceName) / 1000);
            juices.set(juiceName, juices.get(juiceName) % 1000);

            if(!bottles.has(juiceName)){
                bottles.set(juiceName,0);
            }
            bottles.set(juiceName, bottles.get(juiceName) + bottle);
        }
    }

    for (let [juice,bottle] of bottles) {
        console.log(`${juice} => ${bottle}`);
    }
}

makeJuiceBottles([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789',

]);