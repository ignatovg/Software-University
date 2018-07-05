class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    get radius(){
        return this._radius;
    };
    set radius(radius){
        if(radius<= 0 ){
            throw new RangeError('Radius must be positive')
        }

        this._radius = radius;
    }

    get diameter() {
        return this.radius * 2;
    }
    set diameter(diameter){

        this.radius = diameter/2;
    }

    get area() {
        return Math.PI * this.radius ** 2;
    }
}

let c = new Circle(5);
console.log(c.diameter);
console.log(c.area);
c.diameter = -2;