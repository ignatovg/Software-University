class Circle {
    constructor(r){
        this.radius =r;
    }
}

let ci=new Circle(5);

console.log(ci);

function asCircle() {
    this.area = function () {
        return this.radius ** 2 * Math.PI;
    };
    this.perimeter = function () {
        return this.radius * 2 * Math.PI;
    };
    return this;
}

asCircle.call(Circle.prototype); // or ci
console.log(ci.area());