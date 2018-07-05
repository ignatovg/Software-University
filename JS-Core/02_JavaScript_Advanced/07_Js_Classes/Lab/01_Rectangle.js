function RectangleLegacyClass(width, height, color) {
    this.width = width;
    this.height = height;
    this.color = color;

    Rectangle.prototype.area = function () {
        return this.width * this.height;
    };
}

class Rectangle {
    constructor(width, height, color) {
        this.width = width;
        this.height = height;
        this.color = color;
    }

    calcArea() {
        return this.width * this.height;
    }
}

let rect = new Rectangle(2, 7, 'red');
console.log(rect.calcArea());