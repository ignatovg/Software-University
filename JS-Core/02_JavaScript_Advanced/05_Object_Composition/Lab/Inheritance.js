let fatherCar = {
    brand: 'BMW',
    model: 'X5',
    color: 'red',
    toString: function() { return `[brand: ${this.brand}, model: ${this.model}, color: ${this.color}]`; }
};

let myCar = Object.create(fatherCar);
myCar.brand = 'Audi';
myCar.color = 'blue';

let workCar =
    Object.create(fatherCar);
workCar.model = 'i3';
workCar.type = 'electric';
workCar.toString = function() {
    return `[brand: ${this.brand}, model: ${this.model}, color: ${this.color}, type: ${this.type}]`;
};


console.log('father car ' + fatherCar.toString());
console.log('my car ' + myCar.toString());
console.log('work car '+ workCar.toString());
console.log('------------');

console.log(Object.getPrototypeOf(fatherCar));
console.log(Object.getPrototypeOf(myCar));
