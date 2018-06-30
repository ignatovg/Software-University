function createCarList(strArr) {
    let data = new Map();

    for (let row of strArr) {
        let [carBrand, carModel, producedCars] = row.split(' | ');

        if(!data.has(carBrand)){
            data.set(carBrand,new Map());
        }
        if(!data.get(carBrand).has(carModel)){
            data.get(carBrand).set(carModel,0)
        }
        let oldQuantity = data.get(carBrand).get(carModel);
        data.get(carBrand).set(carModel, oldQuantity + Number(producedCars));
    }

    for (let [brand,models] of data) {
        console.log(brand);
        for (let [model, quantity] of models) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}

createCarList([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10',
]);